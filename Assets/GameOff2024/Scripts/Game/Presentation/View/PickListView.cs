using UnityEngine;

namespace GameOff2024.Game.Presentation.View
{
    public sealed class PickListView : MonoBehaviour
    {
        [SerializeField] private PickView[] pickViews = default;

        public void Render(int index, SkillVO skill)
        {
            pickViews[index].Render(skill);
        }
    }
}