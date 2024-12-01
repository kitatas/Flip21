using System.Threading;
using Cysharp.Threading.Tasks;
using GameOff2024.Common;
using GameOff2024.Common.Presentation.View.Button;
using GameOff2024.Common.Presentation.View.Modal;
using TMPro;
using UnityEngine;

namespace GameOff2024.Boot.Presentation.View
{
    public sealed class RegisterView : BaseModalView
    {
        [SerializeField] private CommonButtonView button = default;
        [SerializeField] private TMP_InputField inputField = default;

        public async UniTask<string> DecisionAsync(CancellationToken token)
        {
            inputField.text = "user" + $"{Random.Range(0, 1000000):000000}";

            await (
                ShowAsync(ModalConfig.DURATION, token),
                TweenBlurAsync(ModalConfig.DEACTIVATE_BLUR_VALUE, ModalConfig.DURATION, token)
            );
            await button.OnClickAsync(token);
            await HideAsync(ModalConfig.DURATION, token);

            return inputField.text;
        }
    }
}