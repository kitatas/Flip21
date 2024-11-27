using GameOff2024.Common;
using TMPro;
using UnityEngine;

namespace GameOff2024.Game.Presentation.View
{
    public sealed class RecordView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI rank = default;
        [SerializeField] private TextMeshProUGUI userName = default;
        [SerializeField] private TextMeshProUGUI score = default;

        public void Render(RankingVO rankingVO)
        {
            rank.text = $"{rankingVO.rank}";
            userName.text = $"{rankingVO.name}";
            score.text = $"{rankingVO.score}";
        }
    }
}