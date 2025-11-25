using Application.Features.Identity.Get;

namespace Application.Features.Users;

public sealed class UserAccountOptions
{
    public int MinUserNameLength { get { return 6; } }
    public int MaxUserNameLength { get { return 18; } }
    public int MinPasswordLength { get { return 6; } }
    public int MaxPasswordLength { get { return 40; } }
    public bool PasswordRequiresDigit { get { return true; } }

    private UserAccountOptions()
    {
        if (MinPasswordLength > MaxPasswordLength || MinUserNameLength > MaxUserNameLength)
            throw new InvalidOperationException("Min length cannot be greater than max length");

    }
}
