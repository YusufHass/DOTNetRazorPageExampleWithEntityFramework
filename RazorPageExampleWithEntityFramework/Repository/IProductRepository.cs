using RazorPageExampleWithEntityFramework.Entity;

namespace RazorPageExampleWithEntityFramework.Repository
{
    public interface IProductRepository
    {
       void AddNewProduct(Product product);
        
    void DeleteProduct(int id);

        List<Product> GetList();
        Product GetProductById(int id);

     void UpdateProduct(int productId, Product prod);

    }
}
