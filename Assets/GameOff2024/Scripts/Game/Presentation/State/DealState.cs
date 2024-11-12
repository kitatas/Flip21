using System.Threading;
using Cysharp.Threading.Tasks;
using GameOff2024.Game.Domain.UseCase;

namespace GameOff2024.Game.Presentation.State
{
    public sealed class DealState : BaseState
    {
        private readonly DealUseCase _dealUseCase;

        public DealState(DealUseCase dealUseCase)
        {
            _dealUseCase = dealUseCase;
        }

        public override GameState state => GameState.Deal;

        public override async UniTask<GameState> TickAsync(CancellationToken token)
        {
            _dealUseCase.SetUp();

            await UniTask.Yield(token);
            return GameState.None;
        }
    }
}