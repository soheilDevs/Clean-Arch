using Domain.ProductAgg.Events;
using Domain.Shared;
using Domain.Shared.Exceptions;

namespace Domain.ProductAgg;

public class Product : AggregateRoot
{
    private Product()
    {
        
    }
    public string Description { get; private set; }
    public string Title { get; private set; }
    public Money Money { get; private set; }
    public ICollection<ProductImage> Images { get; private set; }
    public Product(string title, Money price, string description)
    {
        Guard(title);

        Title = title;
        Money = price;
        Description = description;
        Images = new List<ProductImage>();
        AddDomainEvent(new ProductCreated(Id,title));
    }

    public void Edit(string title, Money price, string description)
    {
        Guard(title);

        Title = title;
        Money = price;
        Description = description;
    }

    public void RemoveImages(long Id)
    {
        var image = Images.FirstOrDefault(x => x.Id == Id);
        if (image == null)
            throw new NullOrEmptyDomainDataException("Image not found");

        Images.Remove(image);

    }

    public void AddImages(string imageName)
    {
        Images.Add(new ProductImage(Id, imageName));
    }
    private void Guard(string title)
    {
        NullOrEmptyDomainDataException.CheckString(title, nameof(title));
    }
}