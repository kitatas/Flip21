using GameOff2024.Common.Presentation.View.Button;
using GameOff2024.Game.Utility;
using R3;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace GameOff2024.Game.Presentation.View
{
    public sealed class PickView : MonoBehaviour
    {
        [SerializeField] private CommonButtonView button = default;
        [SerializeField] private Image icon = default;
        [SerializeField] private TextMeshProUGUI description = default;

        public Observable<int> OnClick(int index)
        {
            return button.OnClick().Select(_ => index);
        }

        public void Render(SkillVO skill)
        {
            icon.sprite = skill.icon;
            description.text = string.Format(skill.skill.ToDescription(), skill.value);
        }
    }
}