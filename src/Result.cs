// Copyright (c) ScaleFS LLC; used with permission
// Licensed under the MIT License

namespace ScaleFS.Primitives;

public readonly struct Result<TValue, TError>
{
     public readonly TValue? Value { get; init; }
     public readonly TError? Error { get; init; }

     public bool IsOk => this.Value is not null;
     public bool IsError => this.Error is not null;

     // NOTE: we use implicit conversions to convert the OkResult<TValue>/ErrorResult<TError> created by the caller into the Result<TValue, TError> type expected to be returned from function calls
     public static implicit operator Result<TValue, TError>(OkResult<TValue> okResult) => new Result<TValue, TError>() { Value = okResult.Value };
     public static implicit operator Result<TValue, TError>(ErrorResult<TError> errorResult) => new Result<TValue, TError>() { Error = errorResult.Error };
}

public readonly struct OkResult<TValue>
{
     public readonly TValue Value { get; init; }
     public OkResult(TValue value)
     {
          this.Value = value;
     }
}

public readonly struct ErrorResult<TError>
{
     public readonly TError Error { get; init; }
     public ErrorResult(TError error)
     {
          this.Error = error;
     }
}
public static class Result
{
     public static OkResult<Unit> OkResult()
     {
          return new OkResult<Unit>(new Unit());
     }

     public static OkResult<TValue> OkResult<TValue>(TValue value)
     {
          return new OkResult<TValue>(value);
     }

     //

     public static ErrorResult<Unit> ErrorResult()
     {
          return new ErrorResult<Unit>(new Unit());
     }

     public static ErrorResult<TError> ErrorResult<TError>(TError error)
     {
          return new ErrorResult<TError>(error);
     }
}
