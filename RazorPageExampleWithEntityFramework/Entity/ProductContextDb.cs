using Microsoft.EntityFrameworkCore;

namespace RazorPageExampleWithEntityFramework.Entity
{
    public class ProductContextDb:DbContext
    {
        

        public ProductContextDb(DbContextOptions<ProductContextDb> options) : base(options)
        {

        }
        public DbSet<Product> ProductsEF { get; set; }
}
}
