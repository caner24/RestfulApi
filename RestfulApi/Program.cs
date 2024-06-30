using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using RestfulApi.Application.Attributes;
using RestfulApi.Application.Product.Commands.Request;
using RestfulApi.Application.Validations.FluentValidation;
using RestfulApi.Data.Abstract;
using RestfulApi.Data.Concrete;
using RestfulApi.Entity;
using RestfulApi.Entity.Helpers;
using RestfulApi.Extensions;
using Serilog;
using RestfulApi.Validations.FluentValidation;

Log.Logger = new LoggerConfiguration()
        .WriteTo.Console()
        .CreateLogger();
try
{
    Log.Information("Web host başlatılıyor  . . .");

    var builder = WebApplication.CreateBuilder(args);
    builder.Services.AddControllers(config =>
    { config.RespectBrowserAcceptHeader = true; config.ReturnHttpNotAcceptable = true; })
    .AddNewtonsoftJson(opt =>
        opt.SerializerSettings.ReferenceLoopHandling =
        Newtonsoft.Json.ReferenceLoopHandling.Ignore
    );
    builder.Services.AddExceptionHandler<GlobalErrorHandler>();
    builder.Services.AddProblemDetails();
    builder.Services.AddValidatorsFromAssemblyContaining<AddProductValidation>();
    builder.Services.ConfigureRedisOutputCache(builder.Configuration);
    builder.Services.ConfigureInMemoryDb();
    builder.Services.ConfigureMapping();
    builder.Services.ConfigureMediatR();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    builder.Services.ServiceRegister();

    var app = builder.Build();

    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    #region SeedData
    //<summary> Demo ürün </summary>
    RestfulApiContext context = new RestfulApiContext();
    var product = new Product
    {
        Id = Guid.NewGuid(),
        ProductName = "Papara Metal Cart",
        ProductPrice = 999,
        ProductDetail = new ProductDetail { DetailText = "Metal Card made of 18 grams of laster-cut stainless steel, with your name on it.", Amount = 999 }
    };

    var prod = await context.Product.AddAsync(product);
    await context.SaveChangesAsync();
    #endregion

    app.UseExceptionHandler();
    app.UseCors("CorsPolicy");
    app.UseOutputCache();

    app.UseHttpsRedirection();
    app.UseAuthorization();
    app.MapControllers();

    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Proje başlatılırken bir hata meydana geldi");

}
finally
{
    Log.CloseAndFlush();

}