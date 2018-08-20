using Grace.DependencyInjection;
using Validation.UI.ViewModels.Main;
using Validation.UI.ViewModels.Main.Implementation;

namespace Validation.Forms
{
    public static class Startup
    {
        public static DependencyInjectionContainer RegisterFormsDependencies(this DependencyInjectionContainer container)
        {
            return container;
        }
    }
}