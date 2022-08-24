using Domain.ProductAgg;
using Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Query.Shared;

namespace Query.Models.Product
{
    public class ProductReadModel:BaseReadModel
    {
        public string Description { get;  set; }
        public string Title { get;  set; }
        public Money Money { get;  set; }
        public ICollection<ProductImage> Images { get;  set; }
    }
}
