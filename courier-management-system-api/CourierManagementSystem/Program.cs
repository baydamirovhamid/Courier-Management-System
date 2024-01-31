using courier.management.system.Extensions;
using courier.management.system.Infrastructure;
using courier.management.system.Infrastructure.Repository;
using courier.management.system.Models;
using courier.management.system.Services.Implementation;
using courier.management.system.Services.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NLog.Extensions.Logging;
using courier.management.system.Services.Implementation;
using courier.management.system.Models;
using Npgsql.Internal.TypeHandlers.NetworkHandlers;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers().AddNewtonsoftJson();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(x => x.AddProfile(new MappingEntity()));
builder.Services.ConfigureCors();
builder.Services.ConfigureJWTService();
builder.Services.ConfigureLoggerService();
builder.Services.ConfigureDataProtectionTokenProvider();

builder.Services.AddTransient<IJwtHandler, JwtHandler>();
builder.Services.AddTransient<ILookupService, LookupService>();
builder.Services.AddTransient<IPackageService, PackageService>();
builder.Services.AddTransient<ICourierService, CourierService>();
builder.Services.AddTransient<IPaymentService,PaymentService>();
builder.Services.AddTransient<IValidationCommon, ValidationCommon>();
builder.Services.AddTransient<IAuthService, AuthService>();

builder.Services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));

builder.Services.AddDbContext<CourierManagementDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddIdentity<USER, USER_ROLE>(options =>
{

})
.AddRoles<USER_ROLE>()
.AddEntityFrameworkStores<CourierManagementDbContext>()
.AddDefaultTokenProviders();

//Logs
builder.Host.ConfigureLogging((hostingContext, logging) =>
{
    logging.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
    logging.AddDebug();
    logging.AddNLog();
}
);

var app = builder.Build();
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.ConfigureCustomExceptionMiddleware();
app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseCookiePolicy();
app.MapControllers();
app.Run();
