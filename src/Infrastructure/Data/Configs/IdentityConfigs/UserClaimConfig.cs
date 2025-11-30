
namespace Infrastructure.Data.Configs.IdentityConfigs;

public sealed class UserClaimConfig : IEntityTypeConfiguration<UserClaim>
{
    public void Configure(EntityTypeBuilder<UserClaim> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
               .ValueGeneratedNever();

        // builder.HasOne(x => x.Claims)
        //        .WithOne()
        //        .HasForeignKey(x => x.UserId)
        //        .IsRequired()
        //        .OnDelete(DeleteBehavior.Cascade);

        builder.ToTable("UserClaims");

    }
}
