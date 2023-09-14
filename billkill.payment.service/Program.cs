using billkill.payment.service.Extensions;
using billkill.payment.service.Infrastructure;
using billkill.payment.service.Infrastructure.Repository;
using billkill.payment.service.Models;
using billkill.payment.service.Services.Implementation;
using billkill.payment.service.Services.Interface;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NLog.Extensions.Logging;
using Npgsql.Internal.TypeHandlers.NetworkHandlers;

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

builder.Services.AddTransient<ITerminalService, TerminalService>();
builder.Services.AddTransient<ISqlService, SqlService>();
builder.Services.AddTransient<ICmdService, CmdService>();
builder.Services.AddTransient<IJwtHandler, JwtHandler>();
builder.Services.AddTransient<ILookupService, LookupService>();
builder.Services.AddTransient<IValidationCommon, ValidationCommon>();
builder.Services.AddTransient<IEmailService, EmailService>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));

builder.Services.AddDbContext<BillKillDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddIdentity<USER, EMPLOYEE_ROLE>(options =>
{

})
.AddRoles<EMPLOYEE_ROLE>()
.AddEntityFrameworkStores<BillKillDbContext>()
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
app.UseMiddleware<ApiKeyMiddleware>();
app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
//app.UseClientRateLimiting();
app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseCookiePolicy();
app.MapControllers();
app.Run();
