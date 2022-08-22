using MediatR;

namespace Application.Products.Edit;

public class EditProductCommand:IRequest
{
    public EditProductCommand(long id, string title, int price, string description)
    {
        Id = id;
        Title = title;
        Price = price;
        Description = description;
    }
    public long Id { get; set; }
    public string Title { get; set; }
    public int Price { get; set; }
    public string Description { get; set; }
    
}