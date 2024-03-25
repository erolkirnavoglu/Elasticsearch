namespace Elasticsearch.API.Dto
{
    public record ProductUpdateDTO(string id,string name, decimal price, int stock, ProductFeatureDTO feature)
    {
    }
}
