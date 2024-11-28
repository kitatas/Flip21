using GameOff2024.Game.Domain.UseCase;
using GameOff2024.Game.Presentation.View;
using R3;
using VContainer.Unity;

namespace GameOff2024.Game.Presentation.Presenter
{
    public sealed class UserConfigPresenter : IStartable
    {
        private readonly UserConfigUseCase _userConfigUseCase;
        private readonly UserConfigView _userConfigView;

        public UserConfigPresenter(UserConfigUseCase userConfigUseCase, UserConfigView userConfigView)
        {
            _userConfigUseCase = userConfigUseCase;
            _userConfigView = userConfigView;
        }

        public void Start()
        {
            _userConfigView.Init(_userConfigUseCase.currentName);

            _userConfigView.decisionName
                .SubscribeAwait(async (x, token) =>
                {
                    var isSuccess = await _userConfigUseCase.UpdateUserNameAsync(x, token);
                    if (isSuccess)
                    {

                    }
                    else
                    {
                        _userConfigView.SetName(_userConfigUseCase.currentName);
                    }
                })
                .AddTo(_userConfigView);
        }
    }
}