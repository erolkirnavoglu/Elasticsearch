using Elasticsearch.API.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Elasticsearch.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        [NonAction]
        public IActionResult CreateActionResult<T>(ResponseDTO<T> reponse)
        { 
            if(reponse.StatusCode==System.Net.HttpStatusCode.NoContent) 
                return new ObjectResult(null) { StatusCode= reponse.StatusCode.GetHashCode() };

            return new ObjectResult(reponse) { StatusCode = reponse.StatusCode.GetHashCode() };
            
        }
    }
}
