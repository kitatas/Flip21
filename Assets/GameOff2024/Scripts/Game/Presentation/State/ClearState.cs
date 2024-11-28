using System.Threading;
using Cysharp.Threading.Tasks;
using GameOff2024.Common.Domain.UseCase;
using GameOff2024.Common.Utility;
using GameOff2024.Game.Domain.UseCase;

namespace GameOff2024.Game.Presentation.State
{
    public sealed class ClearState : BaseState
    {
        private readonly LoadUseCase _loadUseCase;
        private readonly RankingUseCase _rankingUseCase;

        public ClearState(LoadUseCase loadUseCase, RankingUseCase rankingUseCase)
        {
            _loadUseCase = loadUseCase;
            _rankingUseCase = rankingUseCase;
        }

        public override GameState state => GameState.Clear;

        public override async UniTask InitAsync(CancellationToken token)
        {
            await UniTask.Yield(token);
        }

        public override async UniTask<GameState> TickAsync(CancellationToken token)
        {
            _loadUseCase.Set(true);
            await _rankingUseCase.SendTurnScoreAsync(token);

            // ランキング反映待ち
            await UniTaskHelper.DelayAsync(1.0f, token);

            _loadUseCase.Set(false);
            return GameState.Result;
        }
    }
}