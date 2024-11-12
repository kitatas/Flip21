using System;
using GameOff2024.Game.Data.DataStore;

namespace GameOff2024.Game.Domain.Repository
{
    public sealed class SuitRepository
    {
        private readonly SuitTable _suitTable;

        public SuitRepository(SuitTable suitTable)
        {
            _suitTable = suitTable;
        }

        public SuitData Find(Suit suit)
        {
            var record = _suitTable.records.Find(x => x.suit == suit);
            if (record == null || record.suitVO.icon == null)
            {
                // TODO: Exception
                throw new Exception();
            }

            return record;
        }
    }
}