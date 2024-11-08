using TMPro;
using UnityEngine;

namespace GameOff2024.Game.Presentation.View
{
    public sealed class ChipView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI chip = default;

        public void Render(int value)
        {
            chip.text = $"{value}";
        }
    }
}