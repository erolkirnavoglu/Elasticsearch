using Elasticsearch.API.Dto;
using Elasticsearch.API.Models;
using Elasticsearch.API.Repositories;
using Nest;
using System.Net;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Elasticsearch.API.Services
{
    public class ProductServices
    {
        private readonly ProductRepository _repository;
        public ProductServices(ProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResponseDTO<ProductResponseDTO>> SaveAsync(ProductDTO request)
        {
            var response = await _repository.SaveAsync(request.CreateProduct());
            if (response == null)
            {
                return ResponseDTO<ProductResponseDTO>.Error(new List<string> { "Kayıt esnasında bir hata meydana geldi" }, System.Net.HttpStatusCode.InternalServerError);
            }

            return ResponseDTO<ProductResponseDTO>.Success(response.CreateDTO(), System.Net.HttpStatusCode.Created);
        }
        public async Task<ResponseDTO<List<ProductResponseDTO>>> GetAllAsync()
        {
            var products = await _repository.GetAllAsync();

            var proList = products.Select(p =>
                    new ProductResponseDTO(p.Id, p.Name, p.Price, p.Stock,
                    new ProductFeatureDTO(p.Feature?.Width, p.Feature?.Height, p.Feature?.Color))).ToList();


            return ResponseDTO<List<ProductResponseDTO>>.Success(proList, System.Net.HttpStatusCode.OK);


        }

        public async Task<ResponseDTO<ProductResponseDTO>> GetById(string id)
        {
            var product= await _repository.GetById(id);
            if(product==null)
            {
                return ResponseDTO<ProductResponseDTO>.Error(new List<string> { "Ürün bulunamadı"},HttpStatusCode.NotFound);
            }
            return ResponseDTO<ProductResponseDTO>.Success(product.CreateDTO(), System.Net.HttpStatusCode.OK);
        }
        public async Task<ResponseDTO<bool>> UpdateAsync(ProductUpdateDTO productUpdate)
        {
            var isSuccess=await _repository.UpdateAsync(productUpdate);
            if(!isSuccess)
            {
                return ResponseDTO<bool>.Error(new List<string> { "Ürün güncellenemedi" }, HttpStatusCode.InternalServerError);
            }
            return ResponseDTO<bool>.Success(true, System.Net.HttpStatusCode.OK);

        }

        public async Task<ResponseDTO<bool>> DeleteAsync(string id)
        {
            var isSuccess = await _repository.DeleteAsync(id);
            if (!isSuccess)
            {
                return ResponseDTO<bool>.Error(new List<string> { "Ürün silinemedi" }, HttpStatusCode.InternalServerError);
            }
            return ResponseDTO<bool>.Success(true, System.Net.HttpStatusCode.OK);
        }
    }
}
