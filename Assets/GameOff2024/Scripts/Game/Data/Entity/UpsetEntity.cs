namespace GameOff2024.Game.Data.Entity
{
    public sealed class UpsetEntity
    {
        public int index { get; private set; }
        public bool isUpset { get; private set; }

        public void SetUp(int value)
        {
            index = value;
            SetUpset(false);
        }

        public void SetUpset(bool value)
        {
            isUpset = value;
        }
    }
}