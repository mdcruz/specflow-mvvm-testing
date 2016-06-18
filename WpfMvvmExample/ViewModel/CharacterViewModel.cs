using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel.Composition;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using WpfMvvmExample.Model;

namespace WpfMvvmExample.ViewModel
{
    [Export(typeof(ICharacterViewModel))]
    public class CharacterViewModel : NotifyPropertyChange, ICharacterViewModel
    {
        private ObservableCollection<Character> _characters;
        private IList<string> _statusList;
        private IList<string> _houseList;
        private Character _character;
        private ICommand _addCommand;
        private ICommand _cancelCommand;
        private string _errorMessage;

        public ObservableCollection<Character> Characters
        {
            get { return _characters; }
            set
            {
                _characters = value;
                OnPropertyChanged("Characters");
            }
        }

        public Character Character
        {
            get { return _character; }
            set
            {
                _character = value;
                OnPropertyChanged("Character");
            }
        }

        public IList<string> StatusList
        {
            get { return _statusList; }
        }

        public IList<string> HouseList
        {
            get { return _houseList; }
        }

        public string ErrorMessage
        {
            get { return _errorMessage; }
            set
            {
                _errorMessage = value;
                OnPropertyChanged("ErrorMessage");
            }
        }

        public ICommand AddCommand
        {
            get
            {
                if (_addCommand == null)
                {
                    _addCommand = new RelayCommand(Save, CanSave);
                }

                return _addCommand;
            }
        }

        public ICommand CancelCommand
        {
            get
            {
                if (_cancelCommand == null)
                {
                    _cancelCommand = new RelayCommand(ClearCharacter, CanSave);
                }

                return _cancelCommand;
            }
        }

        [ImportingConstructor]
        public CharacterViewModel()
        {
            _character = new Character();
            _characters = new ObservableCollection<Character>();
            _statusList = new List<string>();
            _houseList = new List<string>();

            Characters.CollectionChanged += new NotifyCollectionChangedEventHandler(Characters_CollectionChanged);
            SetUpTestData(_houseList, _statusList);
        }

        public void Save()
        {
            var existingCharacters = Characters.Where(x => x.CharacterName.Equals(Character.CharacterName, StringComparison.OrdinalIgnoreCase))
                .FirstOrDefault();

            if(existingCharacters == null)
            {
                if (string.IsNullOrEmpty(Character.CharacterName) || Character.HouseName == null || Character.Status == null)
                    ErrorMessage = "Please fill in all fields";

                else
                {
                    Characters.Add(Character);
                    Character = new Character();
                }
            }

            else
            {
                ErrorMessage = "Character already exists";
            }          
        }

        public void ClearCharacter()
        {
            Character.HouseName = null;
            Character.CharacterName = string.Empty;
            Character.Status = null;
        }

        public void SetUpTestData(IList<string> houseList, IList<string> statuses)
        {
            statuses.Add(Status.Alive.ToString());
            statuses.Add(Status.Deceased.ToString());
            statuses.Add(Status.Unknown.ToString());

            houseList.Add(House.Stark.ToString());
            houseList.Add(House.Baratheon.ToString());
            houseList.Add(House.Lannister.ToString());
            houseList.Add(House.Greyjoy.ToString());
            houseList.Add(House.Tully.ToString());
            houseList.Add(House.Tyrell.ToString());
            houseList.Add(House.Targaryen.ToString());
        }

        private void Characters_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            OnPropertyChanged("Characters");
        }

        private bool CanSave()
        {
            return true;
        }
    }
}
