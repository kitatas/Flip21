using UnityEngine;

namespace GameOff2024.Common.Presentation.View
{
    public sealed class SoundView : MonoBehaviour
    {
        [SerializeField] private AudioSource seSource = default;

        public void PlaySe(SeVO seVO)
        {
            seSource.PlayOneShot(seVO.clip);
        }
    }
}