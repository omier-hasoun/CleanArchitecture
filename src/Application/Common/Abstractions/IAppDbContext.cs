namespace Application.Common.Abstractions;

public interface IAppDbContext
{
    // add your Entities


    Task<int> SaveChangesAsync(CancellationToken token);
}
