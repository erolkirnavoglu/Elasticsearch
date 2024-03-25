using Elasticsearch.API.Models;

namespace Elasticsearch.API.Dto
{
    public record ProductDTO(string name,decimal price,int stock,ProductFeatureDTO feature)
    {
        public Product CreateProduct()
        {
            return new Product
            {
                 Name = name,
                 Price = price,
                 Stock = stock,
                 Feature=new ProductFeature()
                 {
                     Width=feature.width, 
                     Height=feature.height,
                     Color=feature.Color
                 }
            };
        }
    }
    public record ProductFeatureDTO(int? width,int? height,EColor? Color)
    { }
}
