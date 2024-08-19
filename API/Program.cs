using API.Helper;
using Core.Entities.User;
using Core.Interfaces;
using Infrastructure.Data;
using Infrastructure.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(MappingProfiles));

builder.Services.AddScoped(typeof(IBaseRepository<>),typeof(BaseRepository<>));
builder.Services.AddScoped<IStoreRepository, StoreRepository>();
builder.Services.AddScoped<IBranchRepository, BranchRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();

builder.Services.AddDbContext<StoreDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionString")));



builder.Services.AddIdentity<User, IdentityRole>(
    opt =>
    {
        opt.Password.RequireNonAlphanumeric = false;
        opt.Password.RequiredLength = 8;

    }).AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<StoreDbContext>();

//builder.Services.Configure<IdentityOptions>(opt =>
//{
//    opt.Password.RequireNonAlphanumeric = false;
//    opt.Password.RequiredLength = 8;

//});

builder.Services.AddAuthentication(
    opts =>
    {
        opts.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        opts.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
        .AddJwtBearer(options =>
        {
            options.SaveToken = false;
            options.RequireHttpsMetadata = false;
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidIssuer = builder.Configuration.GetSection("JWT").GetValue<string>("issuer"),
                ValidAudience = builder.Configuration.GetSection("JWT").GetValue<string>("audience"),
                IssuerSigningKey = TokenHelper.GenerateKey(builder.Configuration)

            };
        });


// CORS
builder.Services.AddCors(options =>
{
    //Web App
    options.AddPolicy("WebApp", policyBuilder =>
    {
        policyBuilder.WithOrigins("http://localhost:3000");
        policyBuilder.AllowAnyHeader();
        policyBuilder.AllowAnyMethod();
    });
    // if I have more clients I should add them downhere

});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();
app.UseCors();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

using(var scope = app.Services.CreateScope())
{
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

    var roles = new[] { "Customer", "Employee","Vendor" };

    foreach(var role in roles)
    {
        if(!await roleManager.RoleExistsAsync(role))
        {
            await roleManager.CreateAsync(new IdentityRole(role));
        }
    }
}
app.UseCors("WebApp");

app.Run();
