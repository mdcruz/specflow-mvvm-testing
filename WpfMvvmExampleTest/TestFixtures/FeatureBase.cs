using TechTalk.SpecFlow;
using WpfMvvmExampleTest.DataContext;

namespace WpfMvvmExampleTest.TestFixtures
{
    [Binding]
    public class FeatureBase : TestFixture
    {
        protected TestDataContext _testDataContext;

        public FeatureBase(TestDataContext testDataContext)
        {
            _testDataContext = testDataContext;
        }

        [BeforeFeature]
        public static void BeforeFeature()
        {
            CreateMef();
        }
    }
}
