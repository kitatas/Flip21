using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using GameOff2024.Common.Data.DataStore;
using GameOff2024.Common.Utility;
using PlayFab;
using PlayFab.ClientModels;

namespace GameOff2024.Common.Domain.Repository
{
    public sealed class PlayFabRepository
    {
        public PlayFabRepository()
        {
            PlayFabSettings.staticSettings.TitleId = PlayFabConfig.TITLE_ID;
        }

        public async UniTask<LoginResult> LoginUserAsync(string uid, CancellationToken token)
        {
            // TODO: Exception
            return await PlayFabHelper.CallApiAsync<LoginWithCustomIDRequest, LoginResult>(
                PlayFabRequestData.LoginWithCustomIDRequest(uid),
                PlayFabClientAPI.LoginWithCustomID,
                _ => new Exception(),
                new Exception(),
                token
            );
        }
    }
}