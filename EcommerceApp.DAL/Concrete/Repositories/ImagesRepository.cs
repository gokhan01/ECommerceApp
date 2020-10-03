using EcommerceApp.DAL.Abstract;
using EcommerceApp.DAL.Concrete.Contexts;
using EcommerceApp.DAL.Concrete.Models;

namespace EcommerceApp.DAL.Concrete.Repositories
{
    public class ImagesRepository : GenericRepository<Images>, IImagesRepository
    {
        public ImagesRepository(ApplicationDbContext context)
            : base(context)
        {
        }
    }
}
