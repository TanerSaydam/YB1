using eCommerceServer.Models;
using eCommerceServer.Repositories;

namespace eCommerceServer.Service;

public sealed class CategoryService(CategoryRepository categoryRepository)
{
    public async Task<List<Category>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var response = await categoryRepository.GetAllAsync(cancellationToken);
        return response.OrderBy(p => p.Name).ToList();
    }

    public async Task CreateAsync(string name, CancellationToken cancellationToken = default)
    {
        Category category = new()
        {
            Name = name,
        };

        await categoryRepository.CreateAsync(category, cancellationToken);
    }

    public async Task DeleteByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        Category? category = await categoryRepository.GetByIdAsync(id, cancellationToken);
        if (category is null)
        {
            throw new ArgumentException("Category not found");
        }

        await categoryRepository.DeleteAsync(category, cancellationToken);
    }

    public async Task UpdateAsync(Guid id, string name, CancellationToken cancellationToken = default)
    {
        Category? category = await categoryRepository.GetByIdAsync(id, cancellationToken);
        if (category is null)
        {
            throw new ArgumentException("Category not found");
        }

        category.Name = name;
        await categoryRepository.UpdateAsync(category, cancellationToken);
    }
}