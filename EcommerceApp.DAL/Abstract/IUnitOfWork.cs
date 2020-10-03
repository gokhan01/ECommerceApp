namespace EcommerceApp.DAL.Abstract
{
    public interface IUnitOfWork
    {
        IProductsRepository ProductsRepository { get; }
        IImagesRepository ImagesRepository { get; }
        bool Commit();
    }
}
