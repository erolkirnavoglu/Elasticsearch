using Elasticsearch.Net;
using Nest;

namespace Elasticsearch.API.Extension
{
    public static class ElasticExtension
    {
        public static void AddElastic(this IServiceCollection services,IConfiguration configuration)
        {
            var pool = new SingleNodeConnectionPool(new Uri(configuration.GetSection("Elastic")["Url"]!));
            var settings = new ConnectionSettings(pool);
            //settings.BasicAuthentication("", ""); username,password
            var client = new ElasticClient(settings);
            services.AddSingleton(client);
        }
    }
}
