
namespace Infrastructure.Data.Configs.IdentityConfigs;

public sealed class RoleClaimConfig : IEntityTypeConfiguration<RoleClaim>
{
    public void Configure(EntityTypeBuilder<RoleClaim> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
               .ValueGeneratedOnAdd();

        builder.Property(x => x.ClaimType)
               .HasColumnType("VARCHAR(30)")
               .IsRequired();

        builder.Property(x => x.ClaimValue)
               .HasColumnType("VARCHAR(128)")
               .IsRequired();

        // builder.HasOne<

        builder.ToTable("RoleClaims");
    }
}
