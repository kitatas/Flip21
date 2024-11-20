namespace GameOff2024.Game
{
    public sealed class GameConfig
    {
        public const GameState INIT_STATE = GameState.Pick;
        public const int INIT_CARD_NUM = 2;

        public const int CLEAR_THRESHOLD = 100;
    }

    public sealed class CardConfig
    {
        public const int MAX_RANK = 13;

        public static readonly Suit[] SUITS =
        {
            Suit.Clover,
            Suit.Diamond,
            Suit.Heart,
            Suit.Spade,
        };

        public const float DEAL_SPEED = 0.5f;
        public const float ROTATE_SPEED = 0.25f;
        public const float HAND_INTERVAL = 240.0f;
    }

    public sealed class HandConfig
    {
        public const int BUST_THRESHOLD = 21;
    }

    public sealed class PickConfig
    {
        public const int MAX_NUM = 3;

        public static readonly Skill[] SKILLS =
        {
            Skill.ChipGetUp,
            Skill.ChipLostDown,
            Skill.ChipGetLostUp,
            Skill.ChipGetLostDown,
        };
    }

    public sealed class ChipConfig
    {
        public const int INIT_VALUE = 10;
    }

    public sealed class ModalConfig
    {
        public const float DURATION = 0.25f;
    }
}