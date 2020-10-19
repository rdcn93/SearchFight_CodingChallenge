using LightInject;

namespace SearchFight_CodingChallenge.Services
{
    public static class DependencyInjectionConfig
    {
        public static ServiceContainer ServContainer { get; set; }

        public static void ConfigureServices()
        {
            ServContainer = new ServiceContainer();

            ServContainer.Register<ISearchService, SearchService>();
        }
    }
}
