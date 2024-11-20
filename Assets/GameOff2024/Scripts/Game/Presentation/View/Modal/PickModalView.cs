using System.Collections.Generic;
using System.Linq;
using GameOff2024.Common.Presentation.View.Modal;
using R3;
using UnityEngine;

namespace GameOff2024.Game.Presentation.View.Modal
{
    public sealed class PickModalView : BaseModalView
    {
        [SerializeField] private PickView[] pickViews = default;

        public void Render(int index, SkillVO skill)
        {
            pickViews[index].Render(skill);
        }

        public List<Observable<int>> OnClicks()
        {
            return pickViews
                .Select((x, i) => x.OnClick(i))
                .ToList();
        }
    }
}