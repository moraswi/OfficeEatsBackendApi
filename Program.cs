using Microsoft.EntityFrameworkCore;
using officeeatsbackendapi.Data;
using officeeatsbackendapi.Interfaces.Repository;
using officeeatsbackendapi.Interfaces.Services;
using officeeatsbackendapi.Repository;
using officeeatsbackendapi.Services;
//using pepbackendapi.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//builder.Services.AddControllers();
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
    });


// DataContext
//builder.Services.AddDbContext<DataContext>(options =>
//    options.UseMySql(
//        builder.Configuration.GetConnectionString("DefaultConnection"),
//        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection"))
//    )
//);

builder.Services.AddDbContext<DataContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        new MySqlServerVersion(ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection"))),
        mySqlOptions =>
            mySqlOptions.EnableRetryOnFailure(
                maxRetryCount: 5,
                maxRetryDelay: TimeSpan.FromSeconds(1),
                errorNumbersToAdd: null
            )
    ));

//Repository
builder.Services.AddScoped<IUsersRepository, UsersRepository>();
builder.Services.AddScoped<IOfficesRepository, OfficesRepository>();
builder.Services.AddScoped<IShopRepository, ShopRepository>();
builder.Services.AddScoped<IAddressesRepository, AddressesRepository>();
builder.Services.AddScoped<ICategoriesRepository, CategoriesRepository>();
builder.Services.AddScoped<IStoreMenuRepository, StoreMenuRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IRateRepository, RateRepository>();

//services
builder.Services.AddScoped<IUsersService, UsersService>();
builder.Services.AddScoped<IOfficesServices, OfficesServices>();
builder.Services.AddScoped<IShopServices, ShopServices>();
builder.Services.AddScoped<IAddressesServices, AddressesServices>();
builder.Services.AddScoped<ICategoriesService, CategoriesService>();
builder.Services.AddScoped<IStoreMenuService, StoreMenuService>();
builder.Services.AddScoped<IOrderServices, OrderServices>();
builder.Services.AddScoped<IRateServices, RateServices>();

//AddAutoMapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseCors(builder => builder
       .AllowAnyOrigin()
       .AllowAnyMethod()
       .AllowAnyHeader());

app.UseSwagger();
app.UseSwaggerUI(x => x.SwaggerEndpoint("/swagger/v1/swagger.json", "Office Eats Api Gateway"));

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
