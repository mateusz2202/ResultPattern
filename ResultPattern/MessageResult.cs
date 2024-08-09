using System.Collections.Generic;
using System.Threading.Tasks;

namespace ResultPattern;

public class MessageResult : IMessageResult
{
    public MessageResult()
    {
    }

    public List<string> Messages { get; set; } = [];

    public bool Succeeded { get; set; }

    public static IMessageResult Fail() => new MessageResult { Succeeded = false };

    public static IMessageResult Fail(string message) => new MessageResult { Succeeded = false, Messages = [message] };

    public static IMessageResult Fail(List<string> messages) => new MessageResult { Succeeded = false, Messages = messages };

    public static Task<IMessageResult> FailAsync() => Task.FromResult(Fail());

    public static Task<IMessageResult> FailAsync(string message) => Task.FromResult(Fail(message));

    public static Task<IMessageResult> FailAsync(List<string> messages) => Task.FromResult(Fail(messages));

    public static IMessageResult Success() => new MessageResult { Succeeded = true };

    public static IMessageResult Success(string message) => new MessageResult { Succeeded = true, Messages = [message] };

    public static Task<IMessageResult> SuccessAsync() => Task.FromResult(Success());

    public static Task<IMessageResult> SuccessAsync(string message) => Task.FromResult(Success(message));
}

public class Result<T> : MessageResult, IMessageResult<T>
{
    public Result()
    {
    }

    public T Data { get; set; }

    public new static Result<T> Fail() => new() { Succeeded = false };

    public new static Result<T> Fail(string message) => new() { Succeeded = false, Messages = [message] };

    public new static Result<T> Fail(List<string> messages) => new() { Succeeded = false, Messages = messages };

    public new static Task<Result<T>> FailAsync() => Task.FromResult(Fail());

    public new static Task<Result<T>> FailAsync(string message) => Task.FromResult(Fail(message));

    public new static Task<Result<T>> FailAsync(List<string> messages) => Task.FromResult(Fail(messages));

    public new static Result<T> Success() => new() { Succeeded = true };

    public new static Result<T> Success(string message) => new() { Succeeded = true, Messages = [message] };

    public static Result<T> Success(T data) => new() { Succeeded = true, Data = data };

    public static Result<T> Success(T data, string message) => new() { Succeeded = true, Data = data, Messages = [message] };

    public static Result<T> Success(T data, List<string> messages) => new() { Succeeded = true, Data = data, Messages = messages };

    public new static Task<Result<T>> SuccessAsync() => Task.FromResult(Success());

    public new static Task<Result<T>> SuccessAsync(string message) => Task.FromResult(Success(message));

    public static Task<Result<T>> SuccessAsync(T data) => Task.FromResult(Success(data));

    public static Task<Result<T>> SuccessAsync(T data, string message) => Task.FromResult(Success(data, message));
}
