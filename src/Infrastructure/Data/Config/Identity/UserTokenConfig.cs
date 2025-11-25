
namespace Infrastructure.Data.Config.Identity;

public sealed class UserTokenConfig : IEntityTypeConfiguration<UserToken>
{
    public void Configure(EntityTypeBuilder<UserToken> builder)
    {
        builder.HasKey(x => new { x.UserId, x.LoginProvider, x.Name });

        builder.Property(x => new { x.UserId, x.LoginProvider, x.Name })
               .ValueGeneratedNever();
    }
}
