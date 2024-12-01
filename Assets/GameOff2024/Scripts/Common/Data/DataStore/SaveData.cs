namespace GameOff2024.Common.Data.DataStore
{
    public sealed class SaveData
    {
        public string uid;
        public float bgm;
        public float se;

        public static SaveData Create()
        {
            return new SaveData
            {
                uid = "",
                bgm = 0.5f,
                se = 0.5f,
            };
        }
    }
}