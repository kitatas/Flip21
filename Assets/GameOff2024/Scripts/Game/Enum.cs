namespace GameOff2024.Game
{
    public enum GameState
    {
        None = 0,
        Bet = 2,
        Deal = 3,
        Action = 4,
        Lose = 5,
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
        Bet = 1,
        Lose = 2,
    }

    public enum UserAction
    {
        None = 0,
        Hit = 1,
        Stand = 2,
    }
}