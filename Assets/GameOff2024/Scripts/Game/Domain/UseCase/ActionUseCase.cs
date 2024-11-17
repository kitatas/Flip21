using GameOff2024.Game.Data.Entity;

namespace GameOff2024.Game.Domain.UseCase
{
    public sealed class ActionUseCase
    {
        private readonly ActionStatusEntity _player;
        private readonly ActionStatusEntity _enemy;

        public ActionUseCase()
        {
            _player = new ActionStatusEntity();
            _enemy = new ActionStatusEntity();
        }

        public void SetPlayerStand(bool value) => _player.SetStand(value);
        public void SetEnemyStand(bool value) => _enemy.SetStand(value);

        public void SetUp()
        {
            SetPlayerStand(false);
            SetEnemyStand(false);
        }

        public bool IsPlayerStand() => _player.isStand;
        public bool IsEnemyStand() => _enemy.isStand;
        public bool IsAllStand() => IsPlayerStand() && IsEnemyStand();
    }
}