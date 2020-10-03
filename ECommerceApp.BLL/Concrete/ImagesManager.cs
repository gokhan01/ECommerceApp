using EcommerceApp.DAL.Abstract;
using EcommerceApp.DAL.Concrete.Models;
using ECommerceApp.BLL.Abstract;
using System;

namespace ECommerceApp.BLL.Concrete
{
    public class ImagesManager : IImagesManager
    {
        private readonly IUnitOfWork _unitOfWork;
        public ImagesManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Create(Images image)
        {
            _unitOfWork.ImagesRepository.Insert(image);
            _unitOfWork.Commit();
        }

        public bool Delete(Guid id)
        {
            _unitOfWork.ImagesRepository.Delete(id);
            return _unitOfWork.Commit();
        }
    }
}
