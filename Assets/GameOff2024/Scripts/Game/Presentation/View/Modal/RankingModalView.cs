using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using GameOff2024.Common;
using GameOff2024.Common.Presentation.View.Button;
using GameOff2024.Common.Presentation.View.Modal;
using UnityEngine;

namespace GameOff2024.Game.Presentation.View.Modal
{
    public sealed class RankingModalView : BaseModalView
    {
        [SerializeField] private RecordView recordView = default;
        [SerializeField] private Transform viewport = default;
        [SerializeField] private CommonButtonView decision = default;

        public void SetUp(IEnumerable<RankingVO> records)
        {
            foreach (var record in records)
            {
                var view = Instantiate(recordView, viewport);
                view.Render(record);
            }
        }

        public async UniTask PopAsync(float duration, CancellationToken token)
        {
            await (
                ShowAsync(duration, token),
                TweenBlurAsync(ModalConfig.ACTIVATE_BLUR_VALUE, duration, token)
            );
            await decision.OnClickAsync(token);
            await (
                HideAsync(duration, token),
                TweenBlurAsync(ModalConfig.DEACTIVATE_BLUR_VALUE, duration, token)
            );
        }
    }
}