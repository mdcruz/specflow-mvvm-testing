using System.Linq;
using WpfMvvmExample.Model;
using WpfMvvmExample.ViewModel;
using WpfMvvmExampleView.Model;
using WpfMvvmExampleView.Utils;

namespace WpfMvvmExampleView.Facade
{
    public class CharacterViewModelFacade
    {
        private readonly CharacterViewModel _characterViewModel;

        public CharacterViewModelFacade()
        {
            _characterViewModel = (CharacterViewModel)MefContainer.Resolve<ICharacterViewModel>();
        }

        public void FillCharacterDetails(CharacterModel characterDetail)
        {
            _characterViewModel.Character.CharacterName = characterDetail.Name;
            _characterViewModel.Character.HouseName = EnumUtil.Parse<House>(characterDetail.House);
            _characterViewModel.Character.Status = EnumUtil.Parse<Status>(characterDetail.Status);
        }

        public void AddCharacter()
        {
            _characterViewModel.Save();
        }

        public bool IsCharacterAdded(CharacterModel characterDetail)
        {
            var character = _characterViewModel.Characters.Where(c => c.CharacterName == characterDetail.Name
                && c.HouseName == EnumUtil.Parse<House>(characterDetail.House) && c.Status == EnumUtil.Parse<Status>(characterDetail.Status));

            return character != null ? true : false;
        }

        public int GetCharacterOfTheSameDetailsCount(CharacterModel characterDetail)
        {
            return _characterViewModel.Characters.Where(c => c.CharacterName == characterDetail.Name
                && c.HouseName == EnumUtil.Parse<House>(characterDetail.House) && c.Status == EnumUtil.Parse<Status>(characterDetail.Status)).Count();
        }

        public string GetErrorMessage()
        {
            return _characterViewModel.ErrorMessage;
        }
    }
}
