namespace Application.Models;

public class MinimalApiResponse<TId>
{
    public bool Success { get; set; }
    public string Message { get; set; } = string.Empty;

    /// <summary>
    /// The ID of the created resource.
    /// </summary>
    public TId RecordId { get; set; }

    /// <summary>
    /// Additional optional data to return after creation.
    /// </summary>
    public object? Data { get; set; }

    public static MinimalApiResponse<TId> Ok(TId id, string? message = null, object? data = null)
    {
        return new MinimalApiResponse<TId>
        {
            Success = true,
            Message = message ?? "Created successfully.",
            RecordId = id,
            Data = data
        };
    }

    public static MinimalApiResponse<TId> Fail(string message)
    {
        return new MinimalApiResponse<TId>
        {
            Success = false,
            Message = message
        };
    }
}