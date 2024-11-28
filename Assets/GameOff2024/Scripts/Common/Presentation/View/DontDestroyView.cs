using UnityEngine;

namespace GameOff2024.Common.Presentation.View
{
    public sealed class DontDestroyView : MonoBehaviour
    {
        private static DontDestroyView _instance;

        private void Awake()
        {
            if (_instance)
            {
                Destroy(gameObject);
            }
            else
            {
                _instance = this;
                DontDestroyOnLoad(gameObject);
            }
        }
    }
}