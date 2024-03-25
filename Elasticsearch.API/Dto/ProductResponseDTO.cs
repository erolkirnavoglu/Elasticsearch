using Elasticsearch.API.Models;

namespace Elasticsearch.API.Dto
{
    public record ProductResponseDTO(string Id, string Name, decimal Price, int Stock, ProductFeatureDTO? Feature)
    {

    }
}
