using EcommerceApp.DAL.Abstract;
using EcommerceApp.DAL.Concrete.Contexts;
using System;

namespace EcommerceApp.DAL.Concrete.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private IProductsRepository productsRepository;
        private IImagesRepository imagesRepository;

        public UnitOfWork(ApplicationDbContext dbContext)
        {
            _context = dbContext;
        }

        public IProductsRepository ProductsRepository
        {
            get
            {

                if (productsRepository == null)
                {
                    productsRepository = new ProductsRepository(_context);
                }
                return productsRepository;
            }
        }

        public IImagesRepository ImagesRepository
        {
            get
            {

                if (imagesRepository == null)
                {
                    imagesRepository = new ImagesRepository(_context);
                }
                return imagesRepository;
            }
        }

        public bool Commit()
        {
            return _context.SaveChanges() > 0;
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
