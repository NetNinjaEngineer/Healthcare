namespace Healthcare.Domain.Abstractions;
public class Result<T>
{
    public bool IsSuccess { get; }
    public T Value { get; }
    public string Error { get; }

    private Result(bool isSuccess, T value, string error)
    {
        IsSuccess = isSuccess;
        Value = value;
        Error = error;
    }

    public static Result<T> Success(T value)
    {
        return new Result<T>(true, value, string.Empty);
    }

    public static Result<T> Failure(string error)
    {
        return new Result<T>(false, default!, error);
    }

    public bool IsFailure => !IsSuccess;

    public T GetValue()
    {
        if (IsSuccess)
        {
            return Value;
        }

        throw new InvalidOperationException("Cannot access value on a failed result.");
    }

    public string GetError()
    {
        if (IsFailure)
        {
            return Error;
        }

        throw new InvalidOperationException("Cannot access error on a successful result.");
    }
}

public class Result
{
    public bool IsSuccess { get; }
    public string Error { get; }
    private Result(bool isSuccess, string error)
    {
        IsSuccess = isSuccess;
        Error = error;
    }

    public bool IsFailure => !IsSuccess;

    public static Result Success() => new(true, string.Empty);

    public static Result Failure(string error) => new(false, error);

}