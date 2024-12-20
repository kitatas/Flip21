using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using GameOff2024.Game.Domain.UseCase;
using GameOff2024.Game.Presentation.View;

namespace GameOff2024.Game.Presentation.State
{
    public sealed class LoseState : BaseState
    {
        private readonly BetUseCase _betUseCase;
        private readonly ChipUseCase _chipUseCase;
        private readonly ModalUseCase _modalUseCase;
        private readonly SkillUseCase _skillUseCase;
        private readonly TableView _tableView;

        public LoseState(BetUseCase betUseCase, ChipUseCase chipUseCase, ModalUseCase modalUseCase,
            SkillUseCase skillUseCase, TableView tableView)
        {
            _betUseCase = betUseCase;
            _chipUseCase = chipUseCase;
            _modalUseCase = modalUseCase;
            _skillUseCase = skillUseCase;
            _tableView = tableView;
        }

        public override GameState state => GameState.Lose;

        public override async UniTask InitAsync(CancellationToken token)
        {
            await UniTask.Yield(token);
        }

        public override async UniTask<GameState> TickAsync(CancellationToken token)
        {
            await _tableView.OpenEnemyHandsAsync(token);

            var chip = _betUseCase.betValue * _skillUseCase.lostChipRate * -1.0f;
            _chipUseCase.Add(chip + _betUseCase.betValue);

            var isComplete = await _modalUseCase.SetUpAsync(GameModal.Lose, token);
            if (isComplete == false)
            {
                // TODO: Exception
                throw new Exception();
            }

            return _chipUseCase.current > 0 ? GameState.Bet : GameState.Finish;
        }
    }
}