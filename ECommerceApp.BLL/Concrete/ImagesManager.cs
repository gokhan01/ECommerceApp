using EcommerceApp.DAL.Abstract;
using EcommerceApp.DAL.Concrete.Models;

namespace ECommerceApp.BLL.Concrete
{
    public class ImagesManager
    {
        private readonly IImagesRepository _imagesRepository;
        public ImagesManager(IImagesRepository imagesRepository)
        {
            _imagesRepository = imagesRepository;
        }

        public void Create(Images image)
        {
            _imagesRepository.Insert(image);
        }
    }
}
