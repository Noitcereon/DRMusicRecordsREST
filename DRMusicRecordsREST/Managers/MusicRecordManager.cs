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
                420, true),
            new MusicRecord("Knights of Cydonia", "Muse", 2006,
                480, true),
            new MusicRecord("Moon Walker", "Safri Duo", 2003,
                509, false),
            new MusicRecord("Roundabout", "Yes", 1980, 720, true)
        };
        public IList<MusicRecord> GetAllRecords()
        {
            return MusicRecords;
        }

        public List<MusicRecord> SearchRecords(FilterMusicRecord searchQuery)
        {
            List<MusicRecord> output = new List<MusicRecord>();
            List<MusicRecord> tempSearchList;
            
            tempSearchList = MusicRecords.FindAll(x => x.Title.Contains(searchQuery.Title));
            if (tempSearchList.Count > 0 &&  !String.IsNullOrWhiteSpace(searchQuery.Title)) 
            {
                output = CheckForDuplicateAndAdd(tempSearchList, output);
            }
            // TODO: search in tempList instead of MusicRecords (with null/0 check.)
            tempSearchList = MusicRecords.FindAll(x => x.Artist.Contains(searchQuery.Artist));
            if (tempSearchList.Count > 0 && !String.IsNullOrWhiteSpace(searchQuery.Artist))
            {
                output = CheckForDuplicateAndAdd(tempSearchList, output);
            }

            tempSearchList = MusicRecords.FindAll(x => x.DurationInSeconds < searchQuery.DurationInSeconds);
            if (tempSearchList.Count > 0 && searchQuery.DurationInSeconds > 0)
            {
               output = CheckForDuplicateAndAdd(tempSearchList, output);
            }

            return output;
        }

        private List<MusicRecord> CheckForDuplicateAndAdd(List<MusicRecord> filteredRecordList, List<MusicRecord> currentOutput)
        {
            foreach (MusicRecord record in filteredRecordList)
            {
                if (currentOutput.Contains(record))
                {
                    continue;
                }
                currentOutput.Add(record);
            }

            return currentOutput;
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
