using System.Collections.Generic;

namespace ResultPattern;

public interface IMessageResult
{
    List<string> Messages { get; set; }

    bool Succeeded { get; set; }
}

public interface IMessageResult<out T> : IMessageResult
{
    T Data { get; }
}
public interface IMessagePaginationResult<T> : IMessageResult
{
    List<T> Data { get; }
}