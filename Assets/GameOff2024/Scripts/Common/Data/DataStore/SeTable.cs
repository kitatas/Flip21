using System.Collections.Generic;
using UnityEngine;

namespace GameOff2024.Common.Data.DataStore
{
    [CreateAssetMenu(fileName = nameof(SeTable), menuName = "DataTable/" + nameof(SeTable))]
    public sealed class SeTable : ScriptableObject
    {
        [SerializeField] private List<SeData> data = default;

        public List<SeData> records => data;
    }
}