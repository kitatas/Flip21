namespace GameOff2024.Common
{
    public sealed class ProjectConfig
    {
        public const int MAJOR_VERSION = 1;
        public const int MINOR_VERSION = 0;
    }
    
    public sealed class SaveConfig
    {
        public const string ES3_KEY = "";
    }

    public sealed class PlayFabConfig
    {
        public const string TITLE_ID = "";
        public const string RANKING_KEY_TURN = "";

        public const int MIN_NAME_LENGTH = 3;
        public const int MAX_NAME_LENGTH = 10;
        public const int SHOW_MAX_RANKING = 100;
    }

    public sealed class ModalConfig
    {
        public const float DURATION = 0.25f;
        public const float ACTIVATE_BLUR_VALUE = 1.5f;
        public const float DEACTIVATE_BLUR_VALUE = 3.0f;
    }

    public sealed class ButtonConfig
    {
        public const float DURATION = 0.1f;
    }
}