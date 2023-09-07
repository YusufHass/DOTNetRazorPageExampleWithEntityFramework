using Microsoft.Data.SqlClient;
using RazorPageExampleWithEntityFramework.Entity;

namespace RazorPageExampleWithEntityFramework.Repository
{
    public class ProductRepository:IProductRepository
    {
        IConfiguration _configuration;
        ProductContextDb _productContextDb;
        public ProductRepository(IConfiguration configuration, ProductContextDb productCont)
        {
            this._configuration = configuration;
            this._productContextDb = productCont;

        }

        public void AddNewProduct(Product product)
        {
            _productContextDb.ProductsEF.Add(product);
            _productContextDb.SaveChanges();

        }

        public void DeleteProduct(int id)
        {
            var product = _productContextDb.ProductsEF.Find(id);
            _productContextDb.Remove(product);
            _productContextDb.SaveChanges();
        }

        public void UpdateProduct(int productId, Product prod)
        {
            var product = _productContextDb.ProductsEF.Find(productId);
        }

        public List<Product> GetList()
        {
            List<Product> productLists = new List<Product>();
            productLists= _productContextDb.ProductsEF.ToList();
            return productLists;
        }

        public Product GetProductById(int id)
        {
            return _productContextDb.ProductsEF.Find(id);
        }
    }
    }
