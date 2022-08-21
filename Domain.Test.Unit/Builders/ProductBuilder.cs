using Domain.ProductAgg;
using Domain.Shared;

namespace Domain.Test.Unit.Builders;

internal class ProductBuilder
{
    private string _title = "test";
    private Money _money = new Money(1000000);
    private ICollection<ProductImages> _images;

    public ProductBuilder SetTitle(string title)
    {
        _title = title;
        return this;
    }

    public ProductBuilder SetMoney(int rialPrice)
    {
        _money = new Money(rialPrice);
        return this;
    }

    public Product Build()
    {
        return new Product(_title, _money);
    }
}