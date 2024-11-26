using System.Threading;
using Cysharp.Threading.Tasks;
using GameOff2024.Common;
using GameOff2024.Common.Domain.Repository;
using GameOff2024.Game.Data.Entity;

namespace GameOff2024.Game.Domain.UseCase
{
    public sealed class RankingUseCase
    {
        private readonly TurnEntity _turnEntity;
        private readonly PlayFabRepository _playFabRepository;

        public RankingUseCase(TurnEntity turnEntity, PlayFabRepository playFabRepository)
        {
            _turnEntity = turnEntity;
            _playFabRepository = playFabRepository;
        }

        public async UniTask SendTurnScoreAsync(CancellationToken token)
        {
            var record = new RecordVO(Ranking.Turn, _turnEntity.count);
            await _playFabRepository.SendRankingAsync(record, token);
        }
    }
}