namespace Shared.Results;

/// <summary>
///  Used in case you want to filter objects
///  that are inheriting IResult
/// </summary>
public interface IResult
{
    bool IsSuccess { get; }
    bool IsFailure { get; }

}

public interface IResult<out TValue> : IResult
{
    List<Error>? Errors { get; }
    TValue Value { get; }

}
