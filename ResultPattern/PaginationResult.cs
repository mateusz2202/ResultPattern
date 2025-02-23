using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ResultPattern;

public class PaginationResult<T> : MessageResult, IMessagePaginationResult<T>
{
    public PaginationResult()
    {
        Data = [];
        PageSize = 1;
    }
    public List<T> Data { get; set; }
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public int TotalItems { get; set; }
    public int TotalPages => (int)Math.Ceiling((double)TotalItems / PageSize);
    public bool HasPreviousPage => PageNumber > 1;
    public bool HasNextPage => PageNumber < TotalPages;

    public new static PaginationResult<T> Fail() => new() { Succeeded = false };

    public new static PaginationResult<T> Fail(string message) => new() { Succeeded = false, Messages = [message] };

    public new static PaginationResult<T> Fail(List<string> messages) => new() { Succeeded = false, Messages = messages };

    public new static Task<PaginationResult<T>> FailAsync() => Task.FromResult(Fail());

    public new static Task<PaginationResult<T>> FailAsync(string message) => Task.FromResult(Fail(message));

    public new static Task<PaginationResult<T>> FailAsync(List<string> messages) => Task.FromResult(Fail(messages));

    public new static PaginationResult<T> Success() => new() { Succeeded = true };

    public new static PaginationResult<T> Success(string message) => new() { Succeeded = true, Messages = [message] };

    public static PaginationResult<T> Success(List<T> items, Pager pager, int totalItems)
        => new()
        {
            Succeeded = true,
            Data = items,
            PageNumber = pager.PageNumber,
            PageSize = pager.PageSize,
            TotalItems = totalItems
        };

    public static PaginationResult<T> Success(List<T> items, Pager pager, int totalItems, string message)
        => new()
        {
            Succeeded = true,
            Data = items,
            PageNumber = pager.PageNumber,
            PageSize = pager.PageSize,
            TotalItems = totalItems,
            Messages = [message]
        };

    public static PaginationResult<T> Success(List<T> items, Pager pager, int totalItems, List<string> messages)
        => new()
        {
            Succeeded = true,
            Data = items,
            PageNumber = pager.PageNumber,
            PageSize = pager.PageSize,
            TotalItems = totalItems,
            Messages = messages
        };

    public new static Task<PaginationResult<T>> SuccessAsync()
        => Task.FromResult(Success());

    public new static Task<PaginationResult<T>> SuccessAsync(string message)
        => Task.FromResult(Success(message));

    public static Task<PaginationResult<T>> SuccessAsync(List<T> items, Pager pager, int totalItems)
        => Task.FromResult(Success(items, pager, totalItems));

    public static Task<PaginationResult<T>> SuccessAsync(List<T> items, Pager pager, int totalItems, string message)
        => Task.FromResult(Success(items, pager, totalItems, message));
}