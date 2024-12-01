using System;
using GameOff2024.Common.Data.DataStore;

namespace GameOff2024.Common.Domain.Repository
{
    public sealed class SoundRepository
    {
        private readonly BgmTable _bgmTable;
        private readonly SeTable _seTable;

        public SoundRepository(BgmTable bgmTable, SeTable seTable)
        {
            _bgmTable = bgmTable;
            _seTable = seTable;
        }

        public BgmVO Find(Bgm bgm)
        {
            var record = _bgmTable.records.Find(x => x.bgm == bgm);
            if (record == null || record.bgmVO.clip == null)
            {
                // TODO: Exception
                throw new Exception();
            }

            return record.bgmVO;
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