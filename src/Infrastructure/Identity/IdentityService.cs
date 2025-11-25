


namespace Infrastructure.Identity;

public sealed class IdentityService
(UserManager<User> userManager)
: IIdentityService
{
    private readonly UserManager<User> _userManager = userManager;

    public Result<UserDto> CreateNewUser(string? Username, string? Email, string? Password)
    {
        throw new NotImplementedException();
    }

}
