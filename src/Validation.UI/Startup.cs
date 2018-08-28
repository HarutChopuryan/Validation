using Grace.DependencyInjection;
using Grace.DependencyInjection.Lifestyle;
using Validation.UI.ViewModels.Main;
using Validation.UI.ViewModels.Main.Implementation;

namespace Validation.UI
{
    public static class Startup
    {
        public static DependencyInjectionContainer RegisterUIDependencies(this DependencyInjectionContainer container)
        {
            container.Add(block => block.Export<MainViewModel>().As<IMainViewModel>().UsingLifestyle(new SingletonLifestyle()));
            container.Add(block => block.Export<CountryPickerViewModel>().As<ICountryPickerViewModel>().UsingLifestyle(new SingletonLifestyle()));
            return container;
        }
    }
}