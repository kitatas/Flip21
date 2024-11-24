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
    }
}