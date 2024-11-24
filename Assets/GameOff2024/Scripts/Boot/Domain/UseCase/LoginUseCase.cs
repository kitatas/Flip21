using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using GameOff2024.Common;
using GameOff2024.Common.Data.Entity;
using GameOff2024.Common.Domain.Repository;
using PlayFab.ClientModels;

namespace GameOff2024.Boot.Domain.UseCase
{
    public sealed class LoginUseCase
    {
        private readonly UserEntity _userEntity;
        private readonly PlayFabRepository _playFabRepository;
        private readonly SaveRepository _saveRepository;

        public LoginUseCase(UserEntity userEntity, PlayFabRepository playFabRepository, SaveRepository saveRepository)
        {
            _userEntity = userEntity;
            _playFabRepository = playFabRepository;
            _saveRepository = saveRepository;
        }

        public async UniTask<bool> LoginAsync(CancellationToken token)
        {
            var response = await LoginOrCreateAsync(token);
            var user = _playFabRepository.FetchUser(response);
            _userEntity.Set(user);

            // 名前が空であれば未登録ユーザー
            return _userEntity.IsInvalidName();
        }

        private async UniTask<LoginResult> LoginOrCreateAsync(CancellationToken token)
        {
            var saveData = _saveRepository.Load();

            // 新規ユーザー
            if (string.IsNullOrEmpty(saveData.uid))
            {
                var (uid, response) = await CreateUserAsync(token);
                _saveRepository.SaveUid(uid);
                return response;
            }
            else
            {
                return await _playFabRepository.LoginUserAsync(saveData.uid, token);
            }
        }

        private async UniTask<(string, LoginResult)> CreateUserAsync(CancellationToken token)
        {
            while (true)
            {
                var uid = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 20);
                var response = await _playFabRepository.LoginUserAsync(uid, token);

                // 新規作成できなければ、uidを再生成する
                if (response.NewlyCreated)
                {
                    return (uid, response);
                }

                await UniTask.Yield(token);
            }
        }

        public async UniTask<bool> RegisterAsync(string name, CancellationToken token)
        {
            var userName = new UserNameVO(name);
            var isSuccess = await _playFabRepository.UpdateUserNameAsync(userName, token);
            if (isSuccess)
            {
                // 再ログインでユーザーデータをキャッシュする
                await LoginAsync(token);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}