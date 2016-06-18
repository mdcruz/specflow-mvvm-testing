using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.IO;
using System.Reflection;
using WpfMvvmExampleView;

namespace WpfMvvmExampleTest.TestFixtures
{
    public class TestFixture
    {
        public static void CreateMef()
        {
            var directory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var catalog = new AggregateCatalog(new AssemblyCatalog(Assembly.GetExecutingAssembly()));

            catalog.Catalogs.Add(new DirectoryCatalog(directory, "WpfMvvmExample.exe"));

            var container = new CompositionContainer(catalog);
            container.ComposeParts();

            MefContainer.SetContainer(container);
        }
    }
}
