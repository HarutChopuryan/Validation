using Grace.DependencyInjection;

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