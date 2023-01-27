using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrueCode.Model;
using TrueCodeTraining.DbModel;

namespace TrueCodeTraining.Repository
{
    public class ProductRepository
    {
        // Adding data into product
        public Product AddProduct(ProductVm productVm)
        {
            using(TrueCodeTrainingDbContext dbContext = new TrueCodeTrainingDbContext()) {
                var product = new Product();
                product.ProductName = productVm.ProductName;
                product.Price = productVm.Price;
                dbContext.Products.Add(product);
                dbContext.SaveChanges();
                return product;
            }
        }
        // get all Product data through ProductVm
        public List<ProductVm> GetAllProduct()
        {
            using(TrueCodeTrainingDbContext dbContext = new TrueCodeTrainingDbContext()) {
                return (from product in dbContext.Products
                        select new ProductVm() {
                            ProductId = product.ProductId,
                            ProductName = product.ProductName,
                            Price = product.Price
                        }).ToList();
            }
        }

    }
}
