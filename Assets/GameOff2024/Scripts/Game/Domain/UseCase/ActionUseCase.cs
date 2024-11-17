using GameOff2024.Game.Data.Entity;

namespace GameOff2024.Game.Domain.UseCase
{
    public sealed class ActionUseCase
    {
        private readonly ActionStatusEntity _player;

        public ActionUseCase()
        {
            _player = new ActionStatusEntity();
        }

        public void SetPlayerStand(bool value) => _player.SetStand(value);

        public bool IsPlayerStand() => _player.isStand;
    }
}