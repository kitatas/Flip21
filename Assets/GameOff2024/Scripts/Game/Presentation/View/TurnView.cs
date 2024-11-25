using TMPro;
using UnityEngine;

namespace GameOff2024.Game.Presentation.View
{
    public sealed class TurnView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI count = default;

        public void Render(int value)
        {
            count.text = $"{value}";
        }
    }
}