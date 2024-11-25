using System.Threading;
using Cysharp.Threading.Tasks;
using GameOff2024.Boot.Domain.UseCase;
using GameOff2024.Boot.Presentation.View;

namespace GameOff2024.Boot.Presentation.State
{
    public sealed class LoginState : BaseState
    {
        private readonly LoginUseCase _loginUseCase;
        private readonly RegisterView _registerView;

        public LoginState(LoginUseCase loginUseCase, RegisterView registerView)
        {
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
            var isSuccess = await _loginUseCase.LoginAsync(token);
            if (isSuccess == false)
            {
                await RegisterAsync(token);
            }

            return BootState.Check;
        }

        private async UniTask RegisterAsync(CancellationToken token)
        {
            while (true)
            {
                var userName = await _registerView.DecisionAsync(token);
                var isSuccess = await _loginUseCase.RegisterAsync(userName, token);
                if (isSuccess)
                {
                    break;
                }
            }
        }
    }
}