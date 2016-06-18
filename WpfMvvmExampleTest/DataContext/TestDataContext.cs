using WpfMvvmExampleView.Model;

namespace WpfMvvmExampleTest.DataContext
{
    public class TestDataContext
    {
        public CharacterModel CharacterModel { get; set; }

        public TestDataContext()
        {
            CharacterModel = new CharacterModel();
        }
    }
}
