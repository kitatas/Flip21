using System;
using GameOff2024.Common.Data.DataStore;

namespace GameOff2024.Common.Domain.Repository
{
    public sealed class SoundRepository
    {
        private readonly SeTable _seTable;

        public SoundRepository(SeTable seTable)
        {
            _seTable = seTable;
        }

        public SeVO Find(Se se)
        {
            var record = _seTable.records.Find(x => x.se == se);
            if (record == null || record.seVO.clip == null)
            {
                // TODO: Exception
                throw new Exception();
            }

            return record.seVO;
        }
    }
}