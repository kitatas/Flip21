using System.Threading;
using Cysharp.Threading.Tasks;
using GameOff2024.Boot.Domain.UseCase;

namespace GameOff2024.Boot.Presentation.State
{
    public sealed class LoginState : BaseState
    {
        private readonly LoginUseCase _loginUseCase;

        public LoginState(LoginUseCase loginUseCase)
        {
            _loginUseCase = loginUseCase;
        }

        public override BootState state => BootState.Login;

        public override async UniTask InitAsync(CancellationToken token)
        {
            await UniTask.Yield(token);
        }

        public override async UniTask<BootState> TickAsync(CancellationToken token)
        {
            var isSuccess = await _loginUseCase.LoginAsync(token);
            if (isSuccess == false)
            {
                await RegisterAsync(token);
            }

            return BootState.None;
        }

        private async UniTask RegisterAsync(CancellationToken token)
        {
            while (true)
            {
                var userName = "test name";
                // TODO: 入力

                var isSuccess = await _loginUseCase.RegisterAsync(userName, token);
                if (isSuccess)
                {
                    break;
                }
            }
        }
    }
}