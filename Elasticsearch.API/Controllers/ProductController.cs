using Elasticsearch.API.Dto;
using Elasticsearch.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Elasticsearch.API.Controllers
{

    public class ProductController : BaseController
    {
        private readonly ProductServices _services;
        public ProductController(ProductServices services) 
        { 
            _services = services;
        }
        [HttpPost]
        public async Task<IActionResult> Save(ProductDTO request)
        {
            return CreateActionResult(await _services.SaveAsync(request));
                
        }

        [HttpPut]
        public async Task<IActionResult> Update(ProductUpdateDTO request)
        {
            return CreateActionResult(await _services.UpdateAsync(request));

        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return CreateActionResult(await _services.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            return CreateActionResult(await _services.GetById(id));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            return CreateActionResult(await _services.DeleteAsync(id));
        }
    }
}
