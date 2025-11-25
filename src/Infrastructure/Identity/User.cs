
namespace Infrastructure.Identity;

public class User : IdentityUser<Guid>
{
    public ICollection<UserRole> Roles { get; set; } = [];
    private User()
    {

    }
    private User(string userName, string email, string passwordHash, Guid id = default)
    {
        Id = id == default ? Guid.CreateVersion7() : id;
        UserName = userName;
        Email = email;
        PasswordHash = passwordHash;
    }

    public static Result<User> Create(string userName, string email, string passwordHash, Guid id = default)
    {

        ArgumentException.ThrowIfNullOrWhiteSpace(userName);
        ArgumentException.ThrowIfNullOrWhiteSpace(email);
        ArgumentException.ThrowIfNullOrWhiteSpace(passwordHash);

        return new User(userName, email, passwordHash, id);
    }
}
