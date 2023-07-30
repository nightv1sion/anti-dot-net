using System.Diagnostics;
using Microsoft.AspNetCore.Http;

namespace AntiDotNET.Presentation.WebFramework.Models;

public class RequestApiResult
{
    public bool IsSuccess { get; set; }
    public int StatusCode { get; set; }
    public string? Message { get; set; }
    public string RequestId { get; set; }

    public RequestApiResult(bool isSuccess, int statusCode, string? message = null)
    {
        IsSuccess = isSuccess;
        StatusCode = statusCode;
        Message = message;
        RequestId = Activity.Current?.TraceId.ToHexString() ?? string.Empty;
    }
}

public class RequestApiResult<TData> : RequestApiResult
{
    public TData Data { get; set; }

    public RequestApiResult(bool isSuccess, int statusCode, TData data, string? message = null) 
        : base(isSuccess, statusCode, message)
    {
        Data = data;
    }
}