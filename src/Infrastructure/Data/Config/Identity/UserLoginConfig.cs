
namespace Infrastructure.Data.Config.Identity;

public sealed class UserLoginConfig : IEntityTypeConfiguration<UserLogin>
{
    public void Configure(EntityTypeBuilder<UserLogin> builder)
    {
        builder.HasKey(x => new { x.LoginProvider, x.ProviderKey });

        builder.Property(x => new { x.LoginProvider, x.ProviderKey })
               .ValueGeneratedNever();


    }
}
