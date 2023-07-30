namespace AntiDotNET.Application.Models.Common;

public class OperationResult
{
    public bool IsSuccess { get; set; }
    public bool IsNotFound { get; set; }
    public bool IsException { get; set; }
    public string Message { get; set; }
}
public class OperationResult<TResult> : OperationResult
{
    public TResult Result { get; set; }

    public static OperationResult<TResult> SuccessResult(TResult result) => 
        new() { Result = result, IsSuccess = true };

    public static OperationResult<TResult> NotFoundResult(string message) =>
        new() { IsNotFound = true, IsSuccess = false, Message = message};

    public static OperationResult<TResult> ExceptionResult(string message) =>
        new() { IsException = true, IsSuccess = false, Message = message };
}