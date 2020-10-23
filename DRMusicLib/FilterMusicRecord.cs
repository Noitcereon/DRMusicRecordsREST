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
