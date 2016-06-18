using System.Collections.Generic;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using WpfMvvmExampleView.Model;

namespace WpfMvvmExampleTest.TestFixtures
{
    [Binding]
    public class ArgumentConversion
    {
        [StepArgumentTransformation]
        public IEnumerable<CharacterModel> ConvertTableToCharacterModel(Table table)
        {
            return table.CreateSet<CharacterModel>();
        }
    }
}
