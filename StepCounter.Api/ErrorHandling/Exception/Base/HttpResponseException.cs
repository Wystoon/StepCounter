namespace StepCounter.Api.ErrorHandling.Exception.Base;

public class HttpResponseException(int statusCode, object? value = null) : System.Exception
{
    public int StatusCode { get; } = statusCode;

    public object? Value { get; } = value;
}