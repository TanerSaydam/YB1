using eCommerceServer.Context;
using eCommerceServer.Models;

namespace eCommerceServer.Repositories;

public class CategoryRepository : Repository<Category>
{
    public CategoryRepository(ApplicationDbContext context) : base(context)
    {
    }
}