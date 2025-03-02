using Lambda.Common.Domain;

namespace Lambda.Common.Application.Exceptions;

public sealed class LambdaException(
    string requestName, 
    Error? error = default, 
    Exception? innerException = default) : Exception("Application exception", innerException)
{
    public string RequestName { get; } = requestName;

    public Error? Error { get; } = error;
}
