using System.Collections.Generic;
using UnityEngine;

namespace GameOff2024.Common.Data.DataStore
{
    [CreateAssetMenu(fileName = nameof(BgmTable), menuName = "DataTable/" + nameof(BgmTable))]
    public sealed class BgmTable : ScriptableObject
    {
        [SerializeField] private List<BgmData> data = default;

        public List<BgmData> records => data;
    }
}