using Grace.DependencyInjection;
using Validation.UI.ViewModels.Main;
using Validation.UI.ViewModels.Main.Implementation;

namespace Validation.UI
{
    public static class Startup
    {
        public static DependencyInjectionContainer RegisterUIDependencies(this DependencyInjectionContainer container)
        {
            container.Add(block => block.Export<MainViewModel>().As<IMainViewModel>());
            container.Add(block => block.Export<CountryPickerViewModel>().As<ICountryPickerViewModel>());
            return container;
        }
    }
}