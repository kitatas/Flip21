using TMPro;
using UnityEngine;

namespace GameOff2024.Game.Presentation.View
{
    public sealed class SkillView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI chipGetRate = default;
        [SerializeField] private TextMeshProUGUI chipLostRate = default;

        public void Render((int get, int lost) value)
        {
            chipGetRate.text = $"{value.get.ToString()}";
            chipLostRate.text = $"{value.lost.ToString()}";
        }
    }
}