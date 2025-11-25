namespace Application.Features.Users.ChangeUserName;


public sealed record ChangeUserNameCommand
(
Guid UserId,
string NewUserName,
string Password
) : IRequest<Result<Updated>>;
