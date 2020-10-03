using EcommerceApp.DAL.Abstract;
using EcommerceApp.DAL.Concrete.Contexts;
using EcommerceApp.DAL.Concrete.Models;

namespace EcommerceApp.DAL.Concrete.Repositories
{
    public class ProductsRepository : GenericRepository<Products>, IProductsRepository
    {
        public ProductsRepository(ApplicationDbContext context)
            : base(context)
        {
        }
    }
}
