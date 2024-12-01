using System.Threading;
using Cysharp.Threading.Tasks;
using GameOff2024.Common;
using GameOff2024.Game.Domain.UseCase;
using GameOff2024.Game.Presentation.View.Modal;

namespace GameOff2024.Game.Presentation.State
{
    public sealed class ResultState : BaseState
    {
        private readonly RankingUseCase _rankingUseCase;
        private readonly RankingModalView _rankingModalView;

        public ResultState(RankingUseCase rankingUseCase, RankingModalView rankingModalView)
        {
            _rankingUseCase = rankingUseCase;
            _rankingModalView = rankingModalView;
        }

        public override GameState state => GameState.Result;

        public override async UniTask InitAsync(CancellationToken token)
        {
            _rankingModalView.HideAsync(0.0f, token).Forget();
            await UniTask.Yield(token);
        }

        public override async UniTask<GameState> TickAsync(CancellationToken token)
        {
            var records = await _rankingUseCase.FetchTurnRankingAsync(token);
            _rankingModalView.SetUp(records);

            await _rankingModalView.PopAsync(ModalConfig.DURATION, token);

            return GameState.Finish;
        }
    }
}