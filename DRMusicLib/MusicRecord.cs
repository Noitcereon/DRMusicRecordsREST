using System;
using System.Collections.Generic;
using System.Text;

namespace DRMusicLib
{
    public class MusicRecord
    {
        private string _title;
        private string _artist;
        private int _yearOfPublication;
        private int _durationInSeconds;
        private bool _isCertifiedPlatinum;

        public MusicRecord()
        {

        }
        public MusicRecord(string title, string artist, int yearOfPublication, int durationInSeconds, bool isCertifiedPlatinum)
        {
            Title = title;
            Artist = artist;
            YearOfPublication = yearOfPublication;
            DurationInSeconds = durationInSeconds;
            IsCertifiedPlatinum = isCertifiedPlatinum;
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

        public int YearOfPublication
        {
            get => _yearOfPublication;
            set => _yearOfPublication = value;
        }

        public int DurationInSeconds
        {
            get => _durationInSeconds;
            set => _durationInSeconds = value;
        }

        public bool IsCertifiedPlatinum
        {
            get => _isCertifiedPlatinum;
            set => _isCertifiedPlatinum = value;
        }

        public override string ToString()
        {
            return $"{Title} - {Artist}";
        }
    }

}
