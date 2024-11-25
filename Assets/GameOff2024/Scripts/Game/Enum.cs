namespace GameOff2024.Game
{
    public enum GameState
    {
        None = 0,
        Pick = 1,
        Bet = 2,
        Deal = 3,
        Action = 4,
        Lose = 5,
        Win = 6,
        Draw = 7,
    }

    public enum Suit
    {
        None = 0,
        Clover = 1,
        Diamond = 2,
        Heart = 3,
        Spade = 4,
    }

    public enum GameModal
    {
        None = 0,
        Top = 1,
        Bet = 2,
        Lose = 3,
        Win = 4,
        Draw = 5,
    }

    public enum Skill
    {
        None = 0,
        ChipGetUp = 1,
        ChipLostDown = 2,
        ChipGetLostUp = 3,
        ChipGetLostDown = 4,
    }

    public enum UserAction
    {
        None = 0,
        Hit = 1,
        Stand = 2,
        Upset = 3,
    }

    public enum BattleResult
    {
        None = 0,
        Win = 1,
        Lose = 2,
        Draw = 3,
    }
}