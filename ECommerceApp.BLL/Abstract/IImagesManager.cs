using EcommerceApp.DAL.Concrete.Models;
using System;

namespace ECommerceApp.BLL.Abstract
{
    public interface IImagesManager
    {
        void Create(Images image);
        bool Delete(Guid id);
    }
}
