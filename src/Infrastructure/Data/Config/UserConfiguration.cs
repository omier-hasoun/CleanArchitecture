
namespace Infrastructure.Data.Config;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
               .ValueGeneratedNever();

        builder.Property(x => x.Email)
               .HasColumnType("VARCHAR(254)")
               .IsRequired();

        builder.Property(x => x.NormalizedEmail)
               .HasColumnType("VARCHAR(254)")
               .IsRequired();

        builder.Property(x => x.ConcurrencyStamp)
               .HasColumnType("CHAR(36)")
               .IsRequired();

        builder.Property(x => x.SecurityStamp)
               .HasColumnType("CHAR(36)")
               .IsRequired();

        builder.Property(x => x.LockoutEnd)
               .IsRequired(false);

        builder.Property(x => x.PasswordHash)
               .HasColumnType("VARCHAR(100)")// password hash length is 69 chars!
               .IsRequired();
        builder.Property(x => x.PasswordHash)
       .HasColumnType("VARCHAR(100)")// password hash length is 69 chars!
       .IsRequired();


        builder.Ignore(x => x.PhoneNumber);
        builder.Ignore(x => x.PhoneNumberConfirmed);
    }
}
