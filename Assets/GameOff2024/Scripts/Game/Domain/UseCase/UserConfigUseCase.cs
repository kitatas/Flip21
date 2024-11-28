using System.Threading;
using Cysharp.Threading.Tasks;
using GameOff2024.Common;
using GameOff2024.Common.Data.Entity;
using GameOff2024.Common.Domain.Repository;

namespace GameOff2024.Game.Domain.UseCase
{
    public sealed class UserConfigUseCase
    {
        private readonly UserEntity _userEntity;
        private readonly PlayFabRepository _playFabRepository;

        public UserConfigUseCase(UserEntity userEntity, PlayFabRepository playFabRepository)
        {
            _userEntity = userEntity;
            _playFabRepository = playFabRepository;
        }

        public string currentName => _userEntity.user.name.value;

        public async UniTask<bool> UpdateUserNameAsync(string name, CancellationToken token)
        {
            var userName = new UserNameVO(name);
            var isSuccess = await _playFabRepository.UpdateUserNameAsync(userName, token);
            if (isSuccess)
            {
                _userEntity.SetName(name);
            }

            return isSuccess;
        }
    }
}