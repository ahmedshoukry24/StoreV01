using API.Helper;
using API.Middlewares;
using Core.Entities.User;
using Core.Entities.User.UserDetails;
using Core.Interfaces;
using Infrastructure.Data;
using Infrastructure.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(MappingProfiles));

#region TOBEREPLACED
builder.Services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
builder.Services.AddScoped<IStoreRepository, StoreRepository>();
builder.Services.AddScoped<IBranchRepository, BranchRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IVariationRepository, VariationRepository>();
builder.Services.AddScoped<IMediaRepository, MediaRepository>();
#endregion


builder.Services.AddDbContext<StoreDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionString")));



builder.Services.AddIdentity<User, Role>(
    opt =>
    {
        opt.Password.RequireNonAlphanumeric = false;
        opt.Password.RequiredLength = 8;

    }).AddRoles<Role>()
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
                IssuerSigningKey = TokenHelper.GenerateKey(builder.Configuration),
                //RoleClaimType = ClaimTypes.Role

            };
            //options.Events = new JwtBearerEvents
            //{
            //    OnChallenge = context =>
            //    {
            //        context.HandleResponse(); // Prevent default behavior

            //        // Customize the response
            //        context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            //        context.Response.ContentType = "application/json";
            //        var result = JsonSerializer.Serialize(new
            //        {
            //            Status = false,
            //            Message = "Unauthorized: You need to be a Vendor to access this resource."
            //        });

            //        return context.Response.WriteAsync(result);
            //    }
            //};
        });


//builder.Services.AddAuthorization(options =>
//{
//    options.AddPolicy("VendorPolicy", (con) =>
//    {
//        con.RequireClaim(ClaimTypes.Role, "Vendor");
//    });
//});

//builder.Services.AddAuthorization(options =>
//{
//    options.AddPolicy("specificVendors", policy =>
//    {
//        policy.RequireClaim("Current", "Hi_This_Is_Current_Claim_Tor_Testing");
//    });
//});


// CORS
builder.Services.AddCors(options =>
{
    //Web App
    options.AddPolicy("WebApp", policyBuilder =>
    {
        policyBuilder.WithOrigins("http://localhost:3000");
        policyBuilder.AllowAnyHeader();
        policyBuilder.AllowAnyMethod();
        policyBuilder.AllowCredentials();
    });
    // if I have more clients I should add them downhere

});

//builder.Services.AddHttpContextAccessor();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseErrorHandling();

app.UseHttpsRedirection();

app.UseRouting();
app.UseCors();

app.UseAuthentication();
app.UseAuthorization();

app.UseStaticFiles();


app.MapControllers();

app.UseMiddleware<ProfilingMiddleware>();

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
