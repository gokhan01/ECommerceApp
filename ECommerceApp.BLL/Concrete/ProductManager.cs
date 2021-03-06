﻿using EcommerceApp.DAL.Abstract;
using EcommerceApp.DAL.Concrete.Models;
using ECommerceApp.BLL.Abstract;
using ECommerceApp.BLL.Models;
using System;
using System.Collections.Generic;
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

        public List<ProductVM> GetList()
        {
            return _unitOfWork.ProductsRepository.Get()
                .Select(x => new ProductVM
                {
                    Id = x.Id,
                    Name = x.ProductName,
                    Barcode = x.Barcode,
                    Description = x.Description,
                    UnitPrice = x.UnitPrice,
                    UnitsInStock = x.UnitsInStock,
                    DisplayImages = x.Images.Take(1).Select(i => new DisplayImageVM
                    {
                        Id = i.Id,
                        FileContent = string.Format("data:image/gif;base64,{0}", i.FileContent)
                    }).ToList()
                }).ToList();
        }

        public List<ProductListVM> GetNameList()
        {
            return _unitOfWork.ProductsRepository.Get()
                .Select(x => new ProductListVM
                {
                    Id = x.Id,
                    Name = x.ProductName
                }).ToList();
        }

        public ProductVM GetById(Guid id)
        {
            var product = _unitOfWork.ProductsRepository.GetByID(id);

            return new ProductVM
            {
                Id = product.Id,
                Name = product.ProductName,
                Barcode = product.Barcode,
                Description = product.Description,
                UnitPrice = product.UnitPrice,
                UnitsInStock = product.UnitsInStock,
                DisplayImages = product.Images.Select(x => new DisplayImageVM
                {
                    Id = x.Id,
                    FileContent = string.Format("data:image/gif;base64,{0}", x.FileContent)
                }).ToList()
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

            if (_unitOfWork.Commit())
            {
                SaveProductImages(model, product.Id);
            }
        }

        public void Edit(ProductVM model)
        {
            var product = _unitOfWork.ProductsRepository.GetByID(model.Id);

            product.ProductName = model.Name;
            product.Barcode = model.Barcode;
            product.Description = model.Description;
            product.UnitPrice = model.UnitPrice;
            product.UnitsInStock = model.UnitsInStock;

            _unitOfWork.Commit();

            SaveProductImages(model, product.Id);
        }

        private void SaveProductImages(ProductVM model, Guid productId)
        {
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
                        ProductId = productId,
                        FileContent = fileContent,
                        FileType = file.ContentType,
                        FileName = file.FileName
                    });
                }
            }
            _unitOfWork.Commit();
        }

        public bool Delete(Guid id)
        {
            _unitOfWork.ProductsRepository.Delete(id);
            return _unitOfWork.Commit();
        }
    }
}
