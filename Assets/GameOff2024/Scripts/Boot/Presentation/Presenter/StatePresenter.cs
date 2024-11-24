using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.Linq;
using GameOff2024.Boot.Domain.UseCase;
using GameOff2024.Boot.Presentation.State;
using R3;
using VContainer.Unity;

namespace GameOff2024.Boot.Presentation.Presenter
{
    public sealed class StatePresenter : IStartable, IDisposable
    {
        private readonly StateUseCase _stateUseCase;
        private readonly List<BaseState> _states;
        private readonly CancellationTokenSource _tokenSource;

        public StatePresenter(StateUseCase stateUseCase, IEnumerable<BaseState> states)
        {
            _stateUseCase = stateUseCase;
            _states = states.ToList();
            _tokenSource = new CancellationTokenSource();
        }

        public void Start()
        {
            InitAsync(_tokenSource.Token).Forget();
        }

        private async UniTaskVoid InitAsync(CancellationToken token)
        {
            await Enumerable.Select(_states, x => x.InitAsync(token))
                .ToUniTaskAsyncEnumerable()
                .ForEachAsync(x => x.Forget(), cancellationToken: token);

            _stateUseCase.state
                .Subscribe(x => ExecAsync(x, token).Forget())
                .AddTo(token);

            _stateUseCase.Set(BootConfig.INIT_STATE);
        }

        private async UniTaskVoid ExecAsync(BootState state, CancellationToken token)
        {
            try
            {
                var currentState = _states.Find(x => x.state == state);
                if (currentState == null)
                {
                    // TODO: Exception
                    throw new Exception();
                }

                var nextState = await currentState.TickAsync(token);
                _stateUseCase.Set(nextState);
            }
            catch (Exception e)
            {
                // TODO: retry
                throw;
            }
        }

        public void Dispose()
        {
            _tokenSource?.Cancel();
            _tokenSource?.Dispose();
        }
    }
}