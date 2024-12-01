using GameOff2024.Common.Utility;
using UniEx;
using UnityEngine;

namespace GameOff2024.Common
{
    public sealed class UserVO
    {
        public readonly string uid;
        public readonly UserNameVO name;

        public UserVO(string uid, string name)
        {
            this.uid = uid;
            this.name = new UserNameVO(name);
        }
    }

    public sealed class UserNameVO
    {
        public readonly string value;

        public UserNameVO(string value)
        {
            this.value = value;
        }

        public bool IsInvalid()
        {
            return
                string.IsNullOrEmpty(value) ||
                string.IsNullOrWhiteSpace(value) ||
                value.Length.IsBetween(PlayFabConfig.MIN_NAME_LENGTH, PlayFabConfig.MAX_NAME_LENGTH) == false;
        }
    }

    public sealed class BgmVO
    {
        public readonly AudioClip clip;

        public BgmVO(AudioClip clip)
        {
            this.clip = clip;
        }
    }

    public sealed class SeVO
    {
        public readonly AudioClip clip;

        public SeVO(AudioClip clip)
        {
            this.clip = clip;
        }
    }

    public sealed class RecordVO
    {
        public readonly string uid;
        public readonly Ranking ranking;
        public readonly int value;

        public RecordVO(string uid, Ranking ranking)
        {
            this.uid = uid;
            this.ranking = ranking;
        }

        public RecordVO(Ranking ranking, int value)
        {
            this.ranking = ranking;
            this.value = value;
        }

        public string rankingKey => ranking.ToKey();
        public int sendValue => value * -1;
    }

    public sealed class RankingVO
    {
        public readonly int rank;
        public readonly string name;
        public readonly int score;
        public readonly bool isSelf;

        public RankingVO(PlayFab.ClientModels.PlayerLeaderboardEntry entry, RecordVO record)
        {
            rank = entry.Position + 1;
            name = entry.DisplayName;
            score = entry.Profile.Statistics?.Find(x => x.Name == record.rankingKey)?.Value * -1 ?? 0;
            isSelf = entry.PlayFabId.Equals(record.uid);
        }
    }
}