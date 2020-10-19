using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DRMusicLib;

namespace DRMusicRecordsREST.Managers
{
    public class MusicRecordManager
    {
        private static List<MusicRecord> MusicRecords = new List<MusicRecord>
        {
            new MusicRecord("Running with the Wolves", "Aurora",
                2016, 300, 
                false),
            new MusicRecord("Uprising", "Muse", 2004,
                400, true)
        };
        public IList<MusicRecord> GetAllRecords()
        {
            return MusicRecords;
        }
    }
}
