



namespace Application.Common.Abstractions;

public interface IIdentityService
{
    public Result<UserDto> CreateNewUser(string? Username, string? Email, string? Password);
}
