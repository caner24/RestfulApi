using FluentValidation;
using Microsoft.EntityFrameworkCore;
using RestfulApi.Application.Attributes;
using RestfulApi.Application.Product.Commands.Request;
using RestfulApi.Application.Validations.FluentValidation;
using RestfulApi.Data.Abstract;
using RestfulApi.Data.Concrete;
using RestfulApi.Entity.Helpers;
using RestfulApi.Entity;
using RestfulApi.Validations.FluentValidation;
using System.Reflection;
using RestfulApi.Application.Product.Queries.Request;

namespace RestfulApi.Extensions
{
    //<summary> Gerekli servis konfigürasyonlarını bu sınıf altında tanımladım. </summary>
    public static class ServiceExtensions
    {

        public static void ConfigureRedisOutputCache(this IServiceCollection services, IConfiguration config)
        {
            //<summary> Cache yapısı için redis kullandım.</summary>
            //<summary> Redis servisi docker üzerinde çalışıyor</summary>
            //<summary> Projede attribute seviyesinde cache yeterli olacağı için output cache kullandım.</summary>
            services.AddStackExchangeRedisOutputCache(_ => _.InstanceName = config["RedisConn"]);
        }

        public static void ConfigureInMemoryDb(this IServiceCollection services)
        {
            services.AddDbContext<RestfulApiContext>(_ => _.UseInMemoryDatabase("ProductDemoDb"));
        }

        public static void ConfigureMapping(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(Program));
        }
        public static void ConfigureMediatR(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.Load("RestfulApi.Application")));
        }

        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
                    builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                 .WithExposedHeaders("X-Pagination")

                );
            });
        }
        public static void ServiceRegister(this IServiceCollection services)
        {
            services.AddScoped<ValidationFilterAttribute>();
            services.AddScoped<IValidator<AddProductCommandRequest>, AddProductValidation>();
            services.AddScoped<IValidator<UpdateProductCommandRequest>, UpdateProductDtoValidation>();
            services.AddScoped<IValidator<UpdateProductPartialCommandRequest>, UpdatePartialValidation>();
            services.AddScoped<IValidator<GetProductByIdQueryRequest>, GetProductDtoValidation>();
            services.AddScoped<IValidator<DeleteProductCommandRequest>, DeleteProductDtoValidation>();
            services.AddScoped<IDataShaper<Product>, DataShaper<Product>>();
            services.AddScoped<ISortHelper<Product>, SortHelper<Product>>();
            services.AddScoped<IProductDal, ProductDal>();
        }
    }
}
