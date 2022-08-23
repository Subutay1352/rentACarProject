using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products; // commention
        public InMemoryProductDal()
        {
            _products = new List<Product> 
            {
                new Product { ProductId = 1,CategoryId=1,ProductName = "Bardak",UnitPrice = 15,UnitsInStock=20 },
                new Product{ ProductId = 2,CategoryId=1,ProductName = "Elma",UnitPrice = 5,UnitsInStock=10 },
                new Product{ ProductId = 3,CategoryId=2,ProductName = "Kitap",UnitPrice = 3,UnitsInStock=50 },
                new Product{ ProductId = 4,CategoryId=2,ProductName = "Kalem",UnitPrice = 2,UnitsInStock=40 },
                new Product{ ProductId = 5,CategoryId=2,ProductName = "PC",UnitPrice = 1,UnitsInStock=88 }
            };
        }
        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            /*Product productToDelete = null;
            foreach (var p in _products)
            {
                if (product.ProductId == p.ProductId)
                {
                    productToDelete = p;
                }
            }
             _products.Remove(productToDelete);*/

            //w Linq

            Product productToDelete = null;
            productToDelete = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
            return _products.Where(p => p.CategoryId == categoryId).ToList();
        }

        public void Update(Product product)
        {
            // Gönderdigim ürün id'sine sahip listedeki ürünü bul

            Product productToUpdate = _products.SingleOrDefault(p=> p.ProductId == product.ProductId);
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.UnitsInStock = product.UnitsInStock;
        }
    }
}
