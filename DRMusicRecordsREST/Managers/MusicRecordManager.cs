using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DRMusicLib;

namespace DRMusicRecordsREST.Managers
{
    public class MusicRecordManager
    {
        private static readonly List<MusicRecord> MusicRecords = new List<MusicRecord>
        {
            new MusicRecord("Running with the Wolves", "Aurora",
                2015, 300, 
                false),
            new MusicRecord("Uprising", "Muse", 2009,
                400, true)
        };
        public IList<MusicRecord> GetAllRecords()
        {
            return MusicRecords;
        }

        public List<MusicRecord> SearchRecords(string SearchQuery)
        {
            List<MusicRecord> Output = new List<MusicRecord>();



            return Output;

        }
        //public List<MusicRecord> SearchRecords(string searchQuery)
        //{
        //    List<MusicRecord> output = new List<MusicRecord>();
        //    List<MusicRecord> tempRecordsForSearch = new List<MusicRecord>();

        //    tempRecordsForSearch = MusicRecords.FindAll(x => x.Title.Contains(searchQuery));

        //    if (tempRecordsForSearch.Count > 0)
        //    {
        //        foreach (var record in tempRecordsForSearch)
        //        {
        //            output.Add(record);
        //        }
        //    }
        //    if (MusicRecords.FindAll(x => x.Artist.Contains(searchQuery)).Count > 0)
        //    {

        //    }

        //    if (MusicRecords.FindAll(x=> x.DurationInSeconds))
        //    {
                
        //    }

        //    if (MusicRecords.FindAll(x => x.IsCertifiedPlatinum = ))
        //    {
                
        //    }

        //    return output;
        //}

        //private List<MusicRecord> FindMusicRecordByProperty(string searchQuery, string property)
        //{
        //    MusicRecords.FindAll(x => x.property.Contains(searchQuery)).Count > 0
        //}
    }
}
