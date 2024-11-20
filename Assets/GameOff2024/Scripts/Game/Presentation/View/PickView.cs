using GameOff2024.Game.Utility;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace GameOff2024.Game.Presentation.View
{
    public sealed class PickView : MonoBehaviour
    {
        [SerializeField] private Image icon = default;
        [SerializeField] private TextMeshProUGUI description = default;

        public void Render(SkillVO skill)
        {
            icon.sprite = skill.icon;
            description.text = string.Format(skill.skill.ToDescription(), skill.value);
        }
    }
}