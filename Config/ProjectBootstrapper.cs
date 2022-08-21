using Application.Orders;
using Application.Orders.Services;
using Application.Products;
using Application.Products.Create;
using Contracts;
using Domain.OrderAgg;
using Domain.OrderAgg.Services;
using Domain.Products;
using InfraStructure;
using InfraStructure.Persistent.Memory;
using InfraStructure.Persistent.Memory.Orders;
using InfraStructure.Persistent.Memory.Products;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Config
{
    public class ProjectBootstrapper
    {
        public static void Init(IServiceCollection services)
        {
            services.AddTransient<IOrderService, OrderService>();
            //services.AddTransient<IProductService, ProductService>();
            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IOrderDomainService, OrderDomainService>();

            services.AddMediatR(typeof(CreateProductCommand).Assembly);

            services.AddScoped<ISmsService, SmsService>();
            services.AddSingleton<Context>();
        }
    }
}