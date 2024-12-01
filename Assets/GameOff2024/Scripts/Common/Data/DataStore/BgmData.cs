using UnityEngine;

namespace GameOff2024.Common.Data.DataStore
{
    [CreateAssetMenu(fileName = nameof(BgmData), menuName = "DataTable/" + nameof(BgmData))]
    public sealed class BgmData : ScriptableObject
    {
        [SerializeField] private Bgm bgmType = default;
        [SerializeField] private AudioClip audioClip = default;

        public Bgm bgm => bgmType;
        public BgmVO bgmVO => new BgmVO(audioClip);
    }
}