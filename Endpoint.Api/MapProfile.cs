using AutoMapper;
using Endpoint.Api.ViewModel.Products;
using Query.Models.Product;

namespace Endpoint.Api
{
    public class MapProfile:Profile
    {
        public MapProfile()
        {
            CreateMap<ProductReadModel, ProductViewModel>().ReverseMap();
        }
    }
}
