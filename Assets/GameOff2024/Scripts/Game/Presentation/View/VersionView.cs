using GameOff2024.Common;
using TMPro;
using UnityEngine;

namespace GameOff2024.Game.Presentation.View
{
    public sealed class VersionView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI version = default;

        private void Awake()
        {
            version.text = $"ver. {ProjectConfig.MAJOR_VERSION}.{ProjectConfig.MINOR_VERSION}";
        }
    }
}