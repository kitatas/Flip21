using GameOff2024.Common;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace GameOff2024.Game.Presentation.View
{
    public sealed class RecordView : MonoBehaviour
    {
        [SerializeField] private Image background = default;
        [SerializeField] private TextMeshProUGUI rank = default;
        [SerializeField] private TextMeshProUGUI userName = default;
        [SerializeField] private TextMeshProUGUI score = default;

        public void Render(RankingVO rankingVO)
        {
            if (rankingVO.isSelf)
            {
                background.color = new Color(1.0f, 0.5f, 0.5f, 1.0f);
            }

            rank.text = $"{rankingVO.rank}";
            userName.text = $"{rankingVO.name}";
            score.text = $"{rankingVO.score}";
        }
    }
}