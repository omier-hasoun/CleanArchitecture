namespace Application.Features.Users;

public sealed record UserDto
(
    Guid Id,
    string UserName,
    string Email,
    bool Lockedout,
    bool TwoFactorEnabled,
    DateTimeOffset? LockoutEnd = null
);
