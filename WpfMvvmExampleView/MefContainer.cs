using System.ComponentModel.Composition.Hosting;

namespace WpfMvvmExampleView
{
    public class MefContainer
    {
        private static CompositionContainer _compositionContainer;

        public static void SetContainer(CompositionContainer compositionContainer)
        {
            _compositionContainer = compositionContainer;
        }

        public static T Resolve<T>()
        {
            return _compositionContainer.GetExportedValue<T>();
        } 
    }    
}
