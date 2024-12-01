using System.Collections.Generic;
using PlayFab.ClientModels;

namespace GameOff2024.Common.Data.DataStore
{
    public sealed class PlayFabRequestData
    {
        public static LoginWithCustomIDRequest LoginWithCustomIDRequest(string uid)
        {
            return new LoginWithCustomIDRequest
            {
                CustomId = uid,
                CreateAccount = true,
                InfoRequestParameters = new GetPlayerCombinedInfoRequestParams
                {
                    GetUserData = true,
                    GetPlayerProfile = true,
                },
            };
        }

        public static UpdateUserTitleDisplayNameRequest UpdateUserTitleDisplayNameRequest(UserNameVO userNameVO)
        {
            return new UpdateUserTitleDisplayNameRequest
            {
                DisplayName = userNameVO.value,
            };
        }

        public static UpdatePlayerStatisticsRequest UpdatePlayerStatisticsRequest(RecordVO recordVO)
        {
            return new UpdatePlayerStatisticsRequest
            {
                Statistics = new List<StatisticUpdate>
                {
                    new StatisticUpdate()
                    {
                        StatisticName = recordVO.rankingKey,
                        Value = recordVO.sendValue,
                    },
                },
            };
        }

        public static GetLeaderboardRequest GetLeaderboardRequest(string statisticName)
        {
            return new GetLeaderboardRequest
            {
                StatisticName = statisticName,
                ProfileConstraints = new PlayerProfileViewConstraints
                {
                    ShowDisplayName = true,
                    ShowStatistics = true,
                },
                MaxResultsCount = PlayFabConfig.SHOW_MAX_RANKING,
            };
        }
    }
}