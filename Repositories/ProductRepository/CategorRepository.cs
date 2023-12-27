using Entities.Models;
using Repositories.Contracts;

namespace Repositories
{
    public class CategorRepository : RepositoryBase<Category>, ICategoryRepository
    {
        public CategorRepository(RepositoryContext context) : base(context)
        {
        }
    }
}