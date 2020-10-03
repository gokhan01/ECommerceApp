using ECommerceApp.BLL.Models;
using System.Collections.Generic;

namespace ECommerceApp.BLL.Abstract
{
    public interface IProductManager
    {
        List<ProductListVM> GetList();
        void Create(ProductVM model);
        void Edit(ProductVM model);
        ProductVM GetById(string id);
    }
}
