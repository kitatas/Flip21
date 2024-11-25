namespace GameOff2024.Common.Data.Entity
{
    public sealed class UserEntity
    {
        public UserVO user { get; private set; }

        public void Set(UserVO value) => user = value;

        public bool IsValidName()
        {
            if (user?.name == null) return false;
            if (user.name.IsInvalid()) return false;
            return true;
        }
    }
}