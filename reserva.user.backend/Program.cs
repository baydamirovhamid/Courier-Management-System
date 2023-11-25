using reserva.user.backend.Extensions;
using reserva.user.backend.Infrastructure;
using reserva.user.backend.Infrastructure.Repository;
using reserva.user.backend.Models;
using reserva.user.backend.Services.Implementation;
using reserva.user.backend.Services.Interface;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NLog.Extensions.Logging;
using Npgsql.Internal.TypeHandlers.NetworkHandlers;
using billkill.payment.service.Models;
using billkill.manager.backend.Services.Implementation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(x => x.AddProfile(new MappingEntity()));
builder.Services.ConfigureCors();
builder.Services.ConfigureJWTService();
builder.Services.ConfigureLoggerService();
builder.Services.ConfigureDataProtectionTokenProvider();

builder.Services.AddTransient<ISqlService, SqlService>();
builder.Services.AddTransient<ICmdService, CmdService>();
builder.Services.AddTransient<IJwtHandler, JwtHandler>();
builder.Services.AddTransient<ILookupService, LookupService>();
builder.Services.AddTransient<IStadiumService, StadiumService>();
builder.Services.AddTransient<IStadiumFulliedService, StadiumFulliedService>();
builder.Services.AddTransient<IReserveService,ReserveService>();
builder.Services.AddTransient<ITimeTypeService, TimeTypeService>();
builder.Services.AddTransient<IStadiumFulliedService, StadiumFulliedService>();
builder.Services.AddTransient<IReserveService,ReserveService>();
builder.Services.AddTransient<ICompanyEmployeeService, CompanyEmployeeService>();
builder.Services.AddTransient<ICompanyService, CompanyService>();
builder.Services.AddTransient<IValidationCommon, ValidationCommon>();
builder.Services.AddTransient<IEmailService, EmailService>();
builder.Services.AddTransient<IAuthService, AuthService>();
builder.Services.AddTransient<IStadiumPrice, StadiumPrice>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));

builder.Services.AddDbContext<ReservaDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddIdentity<USER, USER_ROLE>(options =>
{

})
.AddRoles<USER_ROLE>()
.AddEntityFrameworkStores<ReservaDbContext>()
.AddDefaultTokenProviders();

//Logs
builder.Host.ConfigureLogging((hostingContext, logging) =>
{
    logging.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
    logging.AddDebug();
    logging.AddNLog();
});

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
//app.UseClientRateLimiting();
app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseCookiePolicy();
app.MapControllers();
app.Run();
