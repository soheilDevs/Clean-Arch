using Domain.ProductAgg;
using Domain.Shared;

namespace Endpoint.Api.ViewModel.Products
{
    public class ProductViewModel
    {
        public long Id { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
        public Money Money { get; set; }
        public ICollection<ProductImage> Images { get; set; }
        public List<LinkDto> Links { get; set; }=new List<LinkDto>();
    }
}
