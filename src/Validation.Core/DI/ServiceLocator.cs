using Grace.DependencyInjection;

namespace Validation.Core.DI
{
    public static class ServiceLocator
    {
        public static DependencyInjectionContainer Instance { get; private set; }

        public static void Create(DependencyInjectionContainer container)
        {
            Instance = container;
        }
    }
}