using Grace.DependencyInjection;

namespace Validation.Core
{
    public static class Startup
    {
        public static DependencyInjectionContainer RegisterCoreDependencies(this DependencyInjectionContainer container)
        {
            return container;
        }
    }
}