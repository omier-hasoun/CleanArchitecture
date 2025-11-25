namespace Infrastructure.Data.LinkEntities;

public sealed class UserRoles
{
    public Guid UserId { get; private set; }
    public Guid RoleId { get; private set; }
    private UserRoles()
    { }
}
