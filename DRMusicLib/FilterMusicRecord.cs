using System;
using System.Collections.Generic;
using System.Text;

namespace DRMusicLib
{
    public class FilterMusicRecord
    {
        private string _title;
        private string _artist;
        private int _durationInSeconds;

        public FilterMusicRecord(string title, string artist, int durationInSeconds)
        {
            _title = title;
            _artist = artist;
            _durationInSeconds = durationInSeconds;
        }

        public FilterMusicRecord()
        {
            _title = "";
            _artist = "";
            _durationInSeconds = 0;
        }

        public string Title
        {
            get => _title;
            set => _title = value;
        }

        public string Artist
        {
            get => _artist;
            set => _artist = value;
        }

        public int DurationInSeconds
        {
            get => _durationInSeconds;
            set => _durationInSeconds = value;
        }
    }
}
