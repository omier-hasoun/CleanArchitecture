namespace Shared.Helpers;

public static class TypeCastingHelper
{
    public static bool TryToGuid<TType>(TType Type, out Guid value)
    {
        if (Type is Guid val)
        {
            value = val;
            return true;
        }

        value = default;
        return false;
    }

    public static bool TryToInt<TType>(TType Type, out int value)
    {
        if (Type is int val)
        {
            value = val;
            return true;
        }

        value = default;
        return false;
    }

    public static bool TryToLong<TType>(TType Type, out long value)
    {
        if (Type is long val)
        {
            value = val;
            return true;
        }

        value = default;
        return false;
    }


    public static bool TryToString<TType>(TType Type, out string? value)
    {
        if (Type is string val)
        {
            value = val;
            return true;
        }

        value = default;
        return false;
    }
}
