// Copyright (c) ScaleFS LLC; used with permission
// Licensed under the MIT License

using System.Diagnostics;

namespace ScaleFS.Primitives;

public interface IWin32Error
{
    public record Win32Error(ushort Win32ErrorCode) : IWin32Error;

    public static IWin32Error FromInt32(int value)
    {
        Debug.Assert(value >= 0 && value <= ushort.MaxValue, "WIN32 ERROR CODES must be in the range of 0 to UInt16.MaxValue");
        return new IWin32Error.Win32Error((ushort)value);
    }

    public static IWin32Error FromUInt32(uint value)
    {
        Debug.Assert(value >= 0 && value <= ushort.MaxValue, "WIN32 ERROR CODES must be in the range of 0 to UInt16.MaxValue");
        return new IWin32Error.Win32Error((ushort)value);
    }
}
