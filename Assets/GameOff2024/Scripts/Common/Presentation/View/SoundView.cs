using UnityEngine;

namespace GameOff2024.Common.Presentation.View
{
    public sealed class SoundView : MonoBehaviour
    {
        [SerializeField] private AudioSource bgmSource = default;
        [SerializeField] private AudioSource seSource = default;

        public void PlayBgm(BgmVO bgmVO)
        {
            bgmSource.clip = bgmVO.clip;
            bgmSource.Play();
        }

        public void PlaySe(SeVO seVO)
        {
            seSource.PlayOneShot(seVO.clip);
        }
    }
}