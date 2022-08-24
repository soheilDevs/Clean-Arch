using Application.Products;
using Application.Products.Create;
using Application.Shared;
using Contracts;
using Domain.OrderAgg;
using Domain.OrderAgg.Services;
using Domain.Products;
using Domain.Users;
using FluentValidation;
using InfraStructure;
using InfraStructure.Persistent.Ef;
using InfraStructure.Persistent.Ef.Orders;
using InfraStructure.Persistent.Ef.Products;
using InfraStructure.Persistent.Ef.Users;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using Query.Models.Product;
using Query.Products.GetById;
using Query.Repositories;

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
            services.AddTransient(typeof(IPipelineBehavior<,>),typeof(CommandValidationBehavior<,>));
            services.AddMediatR(typeof(CreateProductCommand).Assembly);
            services.AddMediatR(typeof(GetProductByIdQuery).Assembly);

            services.AddTransient<IProductReadRepository, ProductReadRepository>();

            services.AddSingleton<IMongoClient, MongoClient>(option =>
            {
                return new MongoClient("mongodb://localhost:27017");
            });
            services.AddValidatorsFromAssembly(typeof(CreateProductCommandValidator).Assembly);

            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });
            services.AddScoped<ISmsService, SmsService>();
        }
    }
}