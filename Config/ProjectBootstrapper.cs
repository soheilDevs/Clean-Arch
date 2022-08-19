using Application.Orders;
using Application.Orders.Services;
using Application.Products;
using Contracts;
using Domain.OrderAgg.Services;
using Domain.Orders;
using Domain.Products;
using InfraStructure;
using InfraStructure.Persistent.Memory;
using InfraStructure.Persistent.Memory.Orders;
using InfraStructure.Persistent.Memory.Products;
using Microsoft.Extensions.DependencyInjection;

namespace Config
{
    public class ProjectBootstrapper
    {
        public static void Init(IServiceCollection services)
        {
            services.AddTransient<IOrderService, OrderService>();
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IOrderDomainService, OrderDomainService>();

            services.AddScoped<ISmsService, SmsService>();
            services.AddSingleton<Context>();
        }
    }
}