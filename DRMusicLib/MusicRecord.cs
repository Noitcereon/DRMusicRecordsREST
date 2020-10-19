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
            _title = title;
            _artist = artist;
            _yearOfPublication = yearOfPublication;
            _durationInSeconds = durationInSeconds;
            _isCertifiedPlatinum = isCertifiedPlatinum;
        }

        public string Title => _title;
        public string Artist => _artist;
        public int YearOfPublication => _yearOfPublication;
        public int DurationInSeconds => _durationInSeconds;
        public bool IsCertifiedPlatinum => _isCertifiedPlatinum;

        public override string ToString()
        {
            return $"{Title} - {Artist}";
        }
    }

}
