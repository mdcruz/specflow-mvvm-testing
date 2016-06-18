using System.ComponentModel;

namespace WpfMvvmExample.Model
{
    public class Character : NotifyPropertyChange
    {
        private string _characterName;
        private House? _houseName;
        private Status? _status;

        public string CharacterName 
        {
            get { return _characterName; }
            set
            {
                _characterName = value;
                OnPropertyChanged("CharacterName");
            }
        }

        public House? HouseName
        {
            get { return _houseName; }
            set
            {
                _houseName = value;
                OnPropertyChanged("HouseName");
            }
        }

        public Status? Status
        {
            get { return _status; }
            set
            {
                _status = value;
                OnPropertyChanged("Status");
            }
        }

        
    }
}
