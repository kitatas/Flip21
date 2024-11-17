namespace GameOff2024.Game.Data.Entity
{
    public sealed class ActionStatusEntity
    {
        public bool isStand { get; private set; }

        public ActionStatusEntity()
        {
            isStand = false;
        }

        public void SetStand(bool value) => isStand = value;
    }
}