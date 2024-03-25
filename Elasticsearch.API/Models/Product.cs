using Elasticsearch.API.Dto;
using Nest;

namespace Elasticsearch.API.Models
{
    public class Product
    {
        [PropertyName("_id")]
        public string Id { get; set; } = null!;
        public string Name { get; set; } = null!;
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }
        public ProductFeature? Feature { get; set; }

        public ProductResponseDTO CreateDTO()
        {
            if (Feature == null)
            {
                return new ProductResponseDTO(Id, Name, Price, Stock, null);
            }

            return new ProductResponseDTO(Id = Id, Name = Name, Price = Price, Stock = Stock, new ProductFeatureDTO(Feature.Width, Feature.Height, Feature.Color));
        }
    }
}

