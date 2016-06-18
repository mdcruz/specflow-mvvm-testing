using System.Collections.Generic;

namespace WpfMvvmExample.ViewModel
{
    public interface ICharacterViewModel
    {
        void Save();
        void ClearCharacter();
        void SetUpTestData(IList<string> houseList, IList<string> statusList);
    }
}
