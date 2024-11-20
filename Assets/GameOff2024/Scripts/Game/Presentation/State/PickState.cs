using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using GameOff2024.Game.Domain.UseCase;

namespace GameOff2024.Game.Presentation.State
{
    public sealed class PickState : BaseState
    {
        private readonly SkillUseCase _skillUseCase;

        public PickState(SkillUseCase skillUseCase)
        {
            _skillUseCase = skillUseCase;
        }

        public override GameState state => GameState.Pick;

        public override async UniTask InitAsync(CancellationToken token)
        {
            await UniTask.Yield(token);
        }

        public override async UniTask<GameState> TickAsync(CancellationToken token)
        {
            var isComplete = await _skillUseCase.LotAsync(token);
            if (isComplete == false)
            {
                // TODO: Exception
                throw new Exception();
            }

            return GameState.Bet;
        }
    }
}