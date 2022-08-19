using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.ProductAgg;
using Domain.Products;

namespace InfraStructure.Persistent.Memory.Products
{
    public class ProductRepository:IProductRepository
    {
        private Context _context;

        public ProductRepository(Context context)
        {
            _context = context;
        }
        public List<Product> GetList()
        {
            return _context.Products;
        }

        public Product GetById(long id)
        {
            return _context.Products.FirstOrDefault(f => f.Id == id);
        }

        public void Add(Product product)
        {
            _context.Products.Add(product);
        }

        public void Update(Product product)
        {
            var oldProduct = GetById(product.Id);
            _context.Products.Remove(oldProduct);
            Add(product);
        }

        public void Remove(Product product)
        {
            _context.Products.Remove(product);
        }

        public void SaveChanges()
        {
            //
        }

        public bool IsProductExist(long id)
        {
            return _context.Products.Any(p => p.Id == id);
        }
    }
}
