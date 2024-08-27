using eCommerceServer.Models;
using eCommerceServer.Repositories;

namespace eCommerceServer.Service;

public sealed class CategoryService(CategoryRepository categoryRepository)
{
    public async Task<List<Category>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var response = await categoryRepository.GetAllAsync(cancellationToken);
        return response;
    }

    public async Task CreateAsync(string name, CancellationToken cancellationToken = default)
    {
        Category category = new()
        {
            Name = name,
        };

        await categoryRepository.CreateAsync(category, cancellationToken);
    }
}