using WpfMvvmExampleView.Facade;

namespace WpfMvvmExampleTest.TestFixtures
{
    public class ViewApp
    {
        public static CharacterViewModelFacade CharacterView
        {
            get { return new CharacterViewModelFacade(); }
        }
    }
}
