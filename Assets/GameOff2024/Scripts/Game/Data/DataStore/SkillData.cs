using UnityEngine;

namespace GameOff2024.Game.Data.DataStore
{
    [CreateAssetMenu(fileName = nameof(SkillData), menuName = "DataTable/" + nameof(SkillData))]
    public sealed class SkillData : ScriptableObject
    {
        [SerializeField] private Skill skillType = default;
        [SerializeField] private Sprite skillIcon = default;
        [SerializeField] private int min = default;
        [SerializeField] private int max = default;

        public Skill skill => skillType;
        public SkillVO skillVO => new(skillType, skillIcon, Random.Range(min, max));
    }
}