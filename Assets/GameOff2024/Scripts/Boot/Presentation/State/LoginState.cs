using System.Threading;
using Cysharp.Threading.Tasks;
using GameOff2024.Boot.Domain.UseCase;
using GameOff2024.Boot.Presentation.View;
using GameOff2024.Common.Domain.UseCase;

namespace GameOff2024.Boot.Presentation.State
{
    public sealed class LoginState : BaseState
    {
        private readonly LoadUseCase _loadUseCase;
        private readonly LoginUseCase _loginUseCase;
        private readonly RegisterView _registerView;

        public LoginState(LoadUseCase loadUseCase, LoginUseCase loginUseCase, RegisterView registerView)
        {
            _loadUseCase = loadUseCase;
            _loginUseCase = loginUseCase;
            _registerView = registerView;
        }

        public override BootState state => BootState.Login;

        public override async UniTask InitAsync(CancellationToken token)
        {
            _registerView.InitAsync(token).Forget();
            await UniTask.Yield(token);
        }

        public override async UniTask<BootState> TickAsync(CancellationToken token)
        {
            _loadUseCase.Set(true);
            var isSuccess = await _loginUseCase.LoginAsync(token);
            if (isSuccess == false)
            {
                await RegisterAsync(token);
            }

            _loadUseCase.Set(false);
            return BootState.Check;
        }

        private async UniTask RegisterAsync(CancellationToken token)
        {
            while (true)
            {
                _loadUseCase.Set(false);
                var userName = await _registerView.DecisionAsync(token);

                _loadUseCase.Set(true);
                var isSuccess = await _loginUseCase.RegisterAsync(userName, token);
                if (isSuccess)
                {
                    break;
                }
            }
        }
    }
}