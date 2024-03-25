using System.Net;

namespace Elasticsearch.API.Dto
{
    public record ResponseDTO<T>
    {
        public T? Data { get; set; }
        public List<string>? Errors { get; set; }
        public HttpStatusCode StatusCode { get; set; }

        public static ResponseDTO<T> Success(T data, HttpStatusCode statusCode)
        {
            return new ResponseDTO<T> { Data = data, StatusCode = statusCode };
        }

        public static ResponseDTO<T> Error(List<string> error, HttpStatusCode statusCode)
        {
            return new ResponseDTO<T> { Errors = error, StatusCode = statusCode };
        }
    }
}
