
using Infrastructure.Data.Config;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Infrastructure.Data;

public class AppDbContext : IdentityDbContext, IAppDbContext
{
    public override async Task<int> SaveChangesAsync(CancellationToken ct)
    {
        return await base.SaveChangesAsync(ct);
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}
