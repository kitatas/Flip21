using GameOff2024.Common.Presentation.View.Button;
using R3;
using TMPro;
using UnityEngine;

namespace GameOff2024.Game.Presentation.View
{
    public sealed class UserConfigView : MonoBehaviour
    {
        [SerializeField] private TMP_InputField inputField = default;
        [SerializeField] private CommonButtonView decision = default;

        public void Init(string userName)
        {
            SetName(userName);
        }

        public void SetName(string userName)
        {
            inputField.text = userName;
        }

        public Observable<string> decisionName => decision.OnClick().Select(_ => inputField.text);
    }
}