using System.Collections.Generic;
using System.Linq;
using GameOff2024.Game.Data.DataStore;

namespace GameOff2024.Game.Domain.Repository
{
    public sealed class CardRepository
    {
        private readonly CardTable _cardTable;

        public CardRepository(CardTable cardTable)
        {
            _cardTable = cardTable;
        }

        public IEnumerable<CardVO> FindsAll()
        {
            return _cardTable.records.Select(x => x.cardVO);
        }
    }
}