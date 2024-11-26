using System;

namespace GameOff2024.Common.Utility
{
    public static class CustomExtension
    {
        public static string ToKey(this Ranking ranking)
        {
            return ranking switch
            {
                Ranking.Turn => PlayFabConfig.RANKING_KEY_TURN,
                _ => throw new Exception(),
            };
        }
    }
}