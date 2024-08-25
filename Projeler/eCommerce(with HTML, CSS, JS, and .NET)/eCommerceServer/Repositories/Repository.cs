using eCommerceServer.Context;

namespace eCommerceServer.Repositories;

public sealed class Repository<T>(
    ApplicationDbContext context)//primary constructor kullanırsak başka constructor oluşturamıyoruz. Ve readonly özelliği eklemiyor
{
    public async Task CreateAsync(T entity, CancellationToken cancellationToken = default)
    {
        await Task.CompletedTask;

    }

    public async Task<List<T>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        await Task.CompletedTask;
        return new List<T>();
    }
}
