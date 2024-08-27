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
}