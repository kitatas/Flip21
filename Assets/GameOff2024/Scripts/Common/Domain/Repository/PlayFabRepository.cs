using System;
using System.Collections.Generic;
using System.Linq;
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

        public UserVO FetchUser(LoginResult response)
        {
            // TODO: Exception
            var payload = response.InfoResultPayload;
            if (payload == null)
            {
                throw new Exception();
            }

            // TODO: Exception
            var userData = payload.UserData;
            if (userData == null)
            {
                throw new Exception();
            }

            var profile = payload.PlayerProfile;
            var userId = profile == null ? "" : profile.PlayerId;
            var userName = profile == null ? "" : profile.DisplayName;
            return new UserVO(userId, userName);
        }

        public async UniTask<bool> UpdateUserNameAsync(UserNameVO userNameVO, CancellationToken token)
        {
            // TODO: Exception
            await PlayFabHelper.CallApiAsync<UpdateUserTitleDisplayNameRequest, UpdateUserTitleDisplayNameResult>(
                PlayFabRequestData.UpdateUserTitleDisplayNameRequest(userNameVO),
                PlayFabClientAPI.UpdateUserTitleDisplayName,
                e => new Exception(),
                new Exception(),
                token
            );

            return true;
        }

        public async UniTask SendRankingAsync(RecordVO recordVO, CancellationToken token)
        {
            await PlayFabHelper.CallApiAsync<UpdatePlayerStatisticsRequest, UpdatePlayerStatisticsResult>(
                PlayFabRequestData.UpdatePlayerStatisticsRequest(recordVO),
                PlayFabClientAPI.UpdatePlayerStatistics,
                _ => throw new Exception(),
                new Exception(),
                token
            );
        }

        public async UniTask<IEnumerable<RankingVO>> GetRankingAsync(RecordVO recordVO, CancellationToken token)
        {
            var response = await PlayFabHelper.CallApiAsync<GetLeaderboardRequest, GetLeaderboardResult>(
                PlayFabRequestData.GetLeaderboardRequest(recordVO.rankingKey),
                PlayFabClientAPI.GetLeaderboard,
                _ => new Exception(),
                new Exception(),
                token
            );

            var leaderboard = response.Leaderboard;
            if (leaderboard == null)
            {
                throw new Exception();
            }

            return leaderboard
                .Select(x => new RankingVO(x, recordVO));
        }
    }
}