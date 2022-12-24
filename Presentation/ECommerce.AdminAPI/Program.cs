
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Business.DependencyResolvers.Autofac;
using ECommerce.Application;
using ECommerce.Core.CrossCuttingConcerns.Logging;
using ECommerce.Core.CrossCuttingConcerns.Logging.Serilog;
using ECommerce.Infrastructure;
using ECommerce.Persistance;


var builder = WebApplication.CreateBuilder(args);

//Auto Fact DI https://stackoverflow.com/questions/69754985/adding-autofac-to-net-core-6-0-using-the-new-single-file-template
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(builder => builder.RegisterModule(new AutofacBusinessModule()));

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddControllersWithViews(options =>
{
    options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true;
    //options.Filters.Add(new ExceptionFilter());
}).AddJsonOptions(options =>
      {
        options.JsonSerializerOptions.MaxDepth = 64;
          //options.JsonSerializerOptions.IgnoreNullValues = true;
     });



// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddPersistenceServices(builder.Configuration);
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration);

//builder.Services.AddSingleton<LoggerServiceBase, MssqlLogger>();


var app = builder.Build();

app.UseCors(builder => builder.WithOrigins(
            new string[] { "http://localhost:3000" }
            //new string[] { "http://celaleker.com" }
            )
           .AllowAnyHeader()
           .AllowAnyOrigin()
           .AllowAnyMethod());

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
