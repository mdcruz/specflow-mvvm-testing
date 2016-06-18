using FluentAssertions;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;
using WpfMvvmExampleTest.DataContext;
using WpfMvvmExampleTest.TestFixtures;
using WpfMvvmExampleView.Model;

namespace WpfMvvmExampleTest.StepDefinitions
{
    [Binding]
    public class AddCharacterSteps : FeatureBase
    {
        public AddCharacterSteps(TestDataContext testDataContext) : base(testDataContext) { }

        [Given(@"I have provided the following details:")]
        public void GivenIProvidedHaveTheFollowingDetails(IEnumerable<CharacterModel> characterDetails)
        {
            _testDataContext.CharacterModel = characterDetails.FirstOrDefault();
            ViewApp.CharacterView.FillCharacterDetails(characterDetails.FirstOrDefault());
        }

        [Given(@"I have added the following character in my list:")]
        public void GivenIHaveAddedTheFollowingCharacterInMyList(IEnumerable<CharacterModel> characterDetails)
        {
            GivenIProvidedHaveTheFollowingDetails(characterDetails);
            WhenIAddTheCharacter();
            ThenIShouldBeAbleToSeeItInTheCharacterList();
        }

        [When(@"I add the character")]
        public void WhenIAddTheCharacter()
        {
            ViewApp.CharacterView.AddCharacter();
        }

        [When(@"I add the same character again")]
        public void WhenIAddTheSameCharacterAgain()
        {
            ViewApp.CharacterView.FillCharacterDetails(_testDataContext.CharacterModel);
            WhenIAddTheCharacter();
        }

        [Then(@"I should be able to see it in the character list")]
        public void ThenIShouldBeAbleToSeeItInTheCharacterList()
        {
            ViewApp.CharacterView.IsCharacterAdded(_testDataContext.CharacterModel).Should().BeTrue();
        }

        [Then(@"I should see the message ""(.*)""")]
        public void ThenIShouldSeeTheMessage(string errorMessage)
        {
            ViewApp.CharacterView.GetErrorMessage().Should().Be(errorMessage);
        }

        [Then(@"I should not be able to see it again in the character list")]
        public void ThenIShouldNotBeAbleToSeeItInTheCharacterList()
        {
            ViewApp.CharacterView.GetCharacterOfTheSameDetailsCount(_testDataContext.CharacterModel).Should().Be(1);
        }

    }
}
