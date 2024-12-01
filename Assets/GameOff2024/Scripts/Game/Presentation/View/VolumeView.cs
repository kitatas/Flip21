using GameOff2024.Common;
using R3;
using R3.Triggers;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace GameOff2024.Game.Presentation.View
{
    public sealed class VolumeView : MonoBehaviour
    {
        [SerializeField] private Slider bgm = default;
        [SerializeField] private Slider se = default;

        public void Init((float bgm, float se) volume)
        {
            bgm.value = volume.bgm;
            se.value = volume.se;
        }

        public Observable<float> bgmVolume => bgm.OnValueChangedAsObservable();
        public Observable<float> seVolume => se.OnValueChangedAsObservable();

        public Observable<Se> releaseVolume => releaseBgmVolume
            .Merge(releaseSeVolume)
            .Select(_ => Se.Button);

        private Observable<PointerEventData> releaseBgmVolume => bgm.OnPointerUpAsObservable();
        private Observable<PointerEventData> releaseSeVolume => se.OnPointerUpAsObservable();
    }
}