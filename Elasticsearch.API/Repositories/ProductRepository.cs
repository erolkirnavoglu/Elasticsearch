using Elasticsearch.API.Dto;
using Elasticsearch.API.Models;
using Nest;

namespace Elasticsearch.API.Repositories
{
    public class ProductRepository
    {
        private readonly ElasticClient _client;
        public ProductRepository(ElasticClient client)
        {
            _client = client;

        }

        public async Task<Product?> SaveAsync(Product product)
        {
            product.Created = DateTime.Now;
            var response = await _client.IndexAsync(product, x => x.Index("products_elastic").Id(Guid.NewGuid().ToString()));
            if (!response.IsValid) return null;
            product.Id = response.Id;
            return product;
        }
        public async Task<IReadOnlyCollection<Product>> GetAllAsync()
        {
            var result = await _client.SearchAsync<Product>
                                 (s => s.Index("products_elastic")
                                .Query(q => q.MatchAll()));

            foreach (var hit in result.Hits) hit.Source.Id = hit.Id;

            return result.Documents;
        }
        public async Task<Product> GetById(string id)
        {
            var response = await _client.GetAsync<Product>(id, x => x.Index("products_elastic"));
            response.Source.Id = response.Id;
            return response.Source;
        }
        public async Task<bool> UpdateAsync(ProductUpdateDTO productUpdate)
        {
            var response = await _client.UpdateAsync<Product, ProductUpdateDTO>(productUpdate.id,
                x => x.Index("products_elastic").Doc(productUpdate));
            return response.IsValid;
        }
        public async Task<bool> DeleteAsync(string id)
        {
            var response = await _client.DeleteAsync<Product>(id, x => x.Index("products_elastic"));
            return response.IsValid;
        }
    }
}
