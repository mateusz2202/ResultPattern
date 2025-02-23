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


