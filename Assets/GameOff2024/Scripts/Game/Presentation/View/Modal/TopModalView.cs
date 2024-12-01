using System.Threading;
using Cysharp.Threading.Tasks;
using GameOff2024.Common;
using GameOff2024.Common.Presentation.View.Button;
using R3;
using UnityEngine;

namespace GameOff2024.Game.Presentation.View.Modal
{
    public sealed class TopModalView : GameModalView
    {
        [SerializeField] private CommonButtonView option = default;
        [SerializeField] private CommonButtonView information = default;
        [SerializeField] private CommonButtonView hint = default;
        [SerializeField] private OptionModalView optionModalView = default;
        [SerializeField] private InformationModalView informationModalView = default;
        [SerializeField] private HintModalView hintModalView = default;

        public override GameModal modal => GameModal.Top;

        public override async UniTask InitAsync(CancellationToken token)
        {
            optionModalView.InitAsync(token).Forget();
            option.OnClick()
                .Subscribe(_ => optionModalView.PopAsync(ModalConfig.DURATION, token).Forget())
                .AddTo(optionModalView);

            informationModalView.InitAsync(token).Forget();
            information.OnClick()
                .Subscribe(_ => informationModalView.PopAsync(ModalConfig.DURATION, token).Forget())
                .AddTo(informationModalView);

            hintModalView.InitAsync(token).Forget();
            hint.OnClick()
                .Subscribe(_ => hintModalView.PopAsync(ModalConfig.DURATION, token).Forget())
                .AddTo(hintModalView);

            await UniTask.Yield(token);
        }
    }
}