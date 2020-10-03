using ECommerceApp.BLL.Models;
using System;
using System.Collections.Generic;

namespace ECommerceApp.BLL.Abstract
{
    public interface IProductManager
    {
        List<ProductListVM> GetNameList();
        List<ProductVM> GetList();
        void Create(ProductVM model);
        void Edit(ProductVM model);
        bool Delete(Guid id);
        ProductVM GetById(Guid id);
    }
}
