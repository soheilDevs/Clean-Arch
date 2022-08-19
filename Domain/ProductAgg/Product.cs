using Domain.Shared;

namespace Domain.ProductAgg;

public class Product
{
    public Guid Id { get; private set; }
    public string Title { get; private set; }
    public Money Price { get; private set; }
    public ICollection<ProductImages> Images { get;private set; }

    public Product(string title,Money price)
    {
        Guard(title);

        Title = title;
        Price=price;
        Id=Guid.NewGuid();
    }

    public void Edit(string title, Money price)
    {
       Guard(title);

        Title = title;
        Price = price;
    }

    public void RemoveImages(long Id)
    {
        var image = Images.FirstOrDefault(x => x.Id == Id);
        if (image == null)
            throw new Exception("dada");

        Images.Remove(image);

    }

    public void AddImages(string imageName)
    {
        Images.Add(new ProductImages(Id,imageName));
    }
    private void Guard(string title)
    {
        if (string.IsNullOrWhiteSpace(title))
            throw new ArgumentNullException("title");

    }
}