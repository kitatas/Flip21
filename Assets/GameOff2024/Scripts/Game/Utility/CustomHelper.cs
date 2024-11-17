using System.Collections.Generic;
using System.Linq;
using UniEx;

namespace GameOff2024.Game.Utility
{
    public static class HandHelper
    {
        public static int GetHandScore(this List<HandVO> hands)
        {
            var ranks = hands.Select(x => x.card.rank).ToList();

            var score = ranks.Where(x => x.IsBetween(2, 10)).Sum();

            // J, Q, K
            score += ranks.Count(x => x > 10) * 10;

            // A
            var aceCount = ranks.Count(x => x == 1);
            score += aceCount * 11;

            // A を 11 で扱わない場合
            while (aceCount > 0 && score > HandConfig.BUST_THRESHOLD)
            {
                aceCount--;
                score -= 10;
            }

            return score;
        }
    }
}