using System.Net;
namespace WebApi.Models;

public class ResultModel<T>
{
     public T? Response { get; set; }
    public bool Success { get; set; } = false;
    public List<string> Errors { get; set; } = [];
    public HttpStatusCode HttpStatusCode { get; set; } = HttpStatusCode.BadRequest;

    internal void SuccessResult(T value)
    {
        HttpStatusCode = HttpStatusCode.OK;
        Success = true;
        Response = value;
    }
}
