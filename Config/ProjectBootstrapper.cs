using Application.Products;
using Application.Products.Create;
using Contracts;
using Domain.OrderAgg;
using Domain.OrderAgg.Services;
using Domain.Products;
using Domain.Users;
using InfraStructure;
using InfraStructure.Persistent.Ef;
using InfraStructure.Persistent.Ef.Orders;
using InfraStructure.Persistent.Ef.Products;
using InfraStructure.Persistent.Ef.Users;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Config
{
    public class ProjectBootstrapper
    {
        public static void Init(IServiceCollection services,string connectionString)
        {
            //services.AddTransient<IOrderService, OrderService>();
            //services.AddTransient<IProductService, ProductService>();
            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            //services.AddTransient<IOrderDomainService, OrderDomainService>();

            services.AddMediatR(typeof(CreateProductCommand).Assembly);
            services.AddDbContext<AppDbContext>(optios =>
            {
                optios.UseSqlServer(connectionString);
            });
            services.AddScoped<ISmsService, SmsService>();
        }
    }
}