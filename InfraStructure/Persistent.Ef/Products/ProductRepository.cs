using Domain.ProductAgg;
using Domain.Products;
using Microsoft.EntityFrameworkCore;

namespace InfraStructure.Persistent.Ef.Products;

public class ProductRepository:IProductRepository
{
    private readonly AppDbContext _context;

    public ProductRepository(AppDbContext context)
    {
        _context = context;
    }
    public async Task<Product> GetById(long id)
    {
        return await _context.Products.FirstOrDefaultAsync(f => f.Id == id);
    }

    public void Add(Product product)
    {
        _context.Products.Add(product);
    }

    public void Update(Product product)
    {
        _context.Update(product);
    }

    public void Remove(Product product)
    {
        _context.Remove(product);
    }

    public async Task SaveChanges()
    {
        await _context.SaveChangesAsync();
    }

    public bool IsProductExist(long id)
    {
       return _context.Products.Any(f => f.Id == id);
    }
}