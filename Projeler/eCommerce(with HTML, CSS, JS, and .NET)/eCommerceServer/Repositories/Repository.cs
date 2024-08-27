using eCommerceServer.Context;
using Microsoft.EntityFrameworkCore;

namespace eCommerceServer.Repositories;

public abstract class Repository<T>(
    ApplicationDbContext context)
    where T : class
{
    public async Task CreateAsync(T entity, CancellationToken cancellationToken = default)
    {
        await context.Set<T>().AddAsync(entity, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
    }

    public async Task<List<T>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        List<T> response = await context.Set<T>().AsNoTracking().ToListAsync(cancellationToken);
        return response;
    }
}
