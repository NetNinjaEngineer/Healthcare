namespace Healthcare.Domain.Abstractions;
public class Result<T>
{
    public bool IsSuccess { get; }
    public T Value { get; }
    public Error Error { get; }

    private Result(bool isSuccess, T value, Error error)
    {
        IsSuccess = isSuccess;
        Value = value;
        Error = error;
    }

    public static Result<T> Success(T value)
    {
        return new Result<T>(true, value, Error.None);
    }

    public static Result<T> Success()
    {
        return new Result<T>(true, default!, Error.None);
    }

    public static Result<T> Failure(Error error)
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

    public Error GetError()
    {
        if (IsFailure)
        {
            return Error;
        }

        throw new InvalidOperationException("Cannot access error on a successful result.");
    }

    public Result<TOut> Then<TOut>(Func<T, Result<TOut>> continuation)
    {

        if (!IsSuccess)
            return new Result<TOut>(false, default!, Error);

        return continuation(Value);

    }

    public Result<U> Map<U>(Func<T, U> selector)
    {
        if (!IsSuccess)
        {
            return new Result<U>(false, default!, Error);
        }

        return Result<U>.Success(selector(Value));
    }



}