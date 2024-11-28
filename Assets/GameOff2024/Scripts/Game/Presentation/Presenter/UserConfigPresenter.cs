using GameOff2024.Common.Domain.UseCase;
using GameOff2024.Game.Domain.UseCase;
using GameOff2024.Game.Presentation.View;
using R3;
using VContainer.Unity;

namespace GameOff2024.Game.Presentation.Presenter
{
    public sealed class UserConfigPresenter : IStartable
    {
        private readonly LoadUseCase _loadUseCase;
        private readonly UserConfigUseCase _userConfigUseCase;
        private readonly UserConfigView _userConfigView;

        public UserConfigPresenter(LoadUseCase loadUseCase, UserConfigUseCase userConfigUseCase,
            UserConfigView userConfigView)
        {
            _loadUseCase = loadUseCase;
            _userConfigUseCase = userConfigUseCase;
            _userConfigView = userConfigView;
        }

        public void Start()
        {
            _userConfigView.Init(_userConfigUseCase.currentName);

            _userConfigView.decisionName
                .SubscribeAwait(async (x, token) =>
                {
                    _loadUseCase.Set(true);
                    var isSuccess = await _userConfigUseCase.UpdateUserNameAsync(x, token);
                    if (isSuccess)
                    {

                    }
                    else
                    {
                        _userConfigView.SetName(_userConfigUseCase.currentName);
                    }

                    _loadUseCase.Set(false);
                })
                .AddTo(_userConfigView);
        }
    }
}