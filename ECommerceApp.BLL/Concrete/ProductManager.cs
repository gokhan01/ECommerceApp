using EcommerceApp.DAL.Abstract;
using EcommerceApp.DAL.Concrete.Models;
using ECommerceApp.BLL.Abstract;
using ECommerceApp.BLL.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ECommerceApp.BLL.Concrete
{
    public class ProductManager : IProductManager
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProductManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<ProductListVM> GetList()
        {
            return _unitOfWork.ProductsRepository.Get()
                .Select(x => new ProductListVM
                {
                    Id = x.Id,
                    Name = x.ProductName
                }).ToList();
        }

        public ProductVM GetById(string id)
        {
            var product = _unitOfWork.ProductsRepository.GetByID(id);

            return new ProductVM
            {
                Id = product.Id.ToString(),
                Name = product.ProductName,
                Barcode = product.Barcode,
                Description = product.Description,
                UnitPrice = product.UnitPrice,
                UnitsInStock = product.UnitsInStock,
                DisplayImages = product.Images.Select(x => string.Format("data:image/gif;base64,{0}", x.FileContent)).ToList()
            };
        }

        public void Create(ProductVM model)
        {
            var product = _unitOfWork.ProductsRepository.Insert(new Products
            {
                ProductName = model.Name,
                Barcode = model.Barcode,
                Description = model.Description,
                UnitPrice = model.UnitPrice,
                UnitsInStock = model.UnitsInStock
            });
            _unitOfWork.Commit();

            foreach (var file in model.Images)
            {
                if (file != null && file.ContentLength > 0)
                {
                    byte[] uploadedFile = new byte[file.InputStream.Length];
                    file.InputStream.Read(uploadedFile, 0, uploadedFile.Length);

                    // Initialization.  
                    var fileContent = Convert.ToBase64String(uploadedFile);

                    _unitOfWork.ImagesRepository.Insert(new Images
                    {
                        ProductId = product.Id,
                        FileContent = fileContent,
                        FileType = file.ContentType,
                        FileName = file.FileName
                    });
                }
            }

            _unitOfWork.Commit();
        }

        public void Edit(ProductVM model)
        {
            throw new NotImplementedException();
        }
    }
}
