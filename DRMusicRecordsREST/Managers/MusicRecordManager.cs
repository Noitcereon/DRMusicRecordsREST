using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using DRMusicLib;

namespace DRMusicRecordsREST.Managers
{
    public class MusicRecordManager
    {
        private static List<MusicRecord> MusicRecords = new List<MusicRecord>
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
       
        public string AddRecord(MusicRecord musicRecord)
        {
            MusicRecords.Add(musicRecord);

            return $"Record added: {musicRecord.Title} - {musicRecord.Artist}";
        }

        public int DeleteRecord(string artist, string title)
        {
            MusicRecord recordToDelete = MusicRecords.Find(x => x.Title == title && x.Artist == artist);
            if (recordToDelete == null)
            {
                return 0;
            }
            
            MusicRecords.Remove(recordToDelete);
            return 1;
        }

        public int UpdateRecord(string artist, string title, MusicRecord musicRecord)
        {
            MusicRecord recordToUpdate = MusicRecords.Find(x => x.Title == title && x.Artist == artist);
            if (recordToUpdate == null)
            {
                return 0;
            }

            MusicRecords.Remove(recordToUpdate);
            MusicRecords.Add(musicRecord);
            return 1;
        }
    }
}
