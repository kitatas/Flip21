using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.Linq;
using GameOff2024.Game.Domain.UseCase;
using GameOff2024.Game.Presentation.View.Modal;
using R3;
using VContainer.Unity;

namespace GameOff2024.Game.Presentation.Presenter
{
    public sealed class ModalPresenter : IStartable, IDisposable
    {
        private readonly ModalUseCase _modalUseCase;
        private readonly List<BaseModalView> _modalViews;
        private readonly CancellationTokenSource _tokenSource;

        public ModalPresenter(ModalUseCase modalUseCase, IEnumerable<BaseModalView> modalViews)
        {
            _modalUseCase = modalUseCase;
            _modalViews = modalViews.ToList();
            _tokenSource = new CancellationTokenSource();
        }

        public void Start()
        {
            InitAsync(_tokenSource.Token).Forget();
        }

        private async UniTaskVoid InitAsync(CancellationToken token)
        {
            await Enumerable.Select(_modalViews, x => x.InitAsync(token))
                .ToUniTaskAsyncEnumerable()
                .ForEachAsync(x => x.Forget(), cancellationToken: token);

            _modalUseCase.gameModal
                .Subscribe(x => ShowAsync(x, token).Forget())
                .AddTo(token);
        }

        private async UniTaskVoid ShowAsync(GameModal modal, CancellationToken token)
        {
            try
            {
                var currentModal = _modalViews.Find(x => x.modal == modal);
                if (currentModal == null)
                {
                    // TODO: Exception
                    throw new Exception();
                }

                await currentModal.ShowAsync(token);
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