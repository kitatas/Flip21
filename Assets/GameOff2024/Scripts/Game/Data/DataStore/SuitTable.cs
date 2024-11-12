using System.Collections.Generic;
using UnityEngine;

namespace GameOff2024.Game.Data.DataStore
{
    [CreateAssetMenu(fileName = nameof(SuitTable), menuName = "DataTable/" + nameof(SuitTable))]
    public sealed class SuitTable : ScriptableObject
    {
        [SerializeField] private List<SuitData> data = default;

        public List<SuitData> records => data;
    }
}