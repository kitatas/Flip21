using System.Collections.Generic;
using UnityEngine;

namespace GameOff2024.Game.Data.DataStore
{
    [CreateAssetMenu(fileName = nameof(SkillTable), menuName = "DataTable/" + nameof(SkillTable))]
    public sealed class SkillTable : ScriptableObject
    {
        [SerializeField] private List<SkillData> data = default;

        public List<SkillData> records => data;
    }
}