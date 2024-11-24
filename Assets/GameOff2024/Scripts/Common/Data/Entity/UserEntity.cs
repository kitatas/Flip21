namespace GameOff2024.Common.Data.Entity
{
    public sealed class UserEntity
    {
        public UserVO user { get; private set; }

        public void Set(UserVO value) => user = value;

        public bool IsInvalidName() => user != null && !string.IsNullOrEmpty(user.name.value);
    }
}