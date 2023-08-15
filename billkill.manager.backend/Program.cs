using billkill.manager.backend.Extensions;
using billkill.manager.backend.Infrastructure;
using billkill.manager.backend.Infrastructure.Repository;
using billkill.manager.backend.Services.Implementation;
using billkill.manager.backend.Services.Interface;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NLog.Extensions.Logging;
using Npgsql.Internal.TypeHandlers.NetworkHandlers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.ConfigureCors();
builder.Services.ConfigureJWTService();
builder.Services.ConfigureLoggerService();

builder.Services.AddTransient<ISqlService, SqlService>();
builder.Services.AddTransient<ICmdService, CmdService>();
builder.Services.AddTransient<IJwtHandler, JwtHandler>();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IInvoiceTypeService, InvoiceTypeService>();
builder.Services.AddTransient<IValidationCommon, ValidationCommon>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));

builder.Services.AddDbContext<BillKillDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

//Logs
builder.Host.ConfigureLogging((hostingContext, logging) =>
{
    logging.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
    logging.AddDebug();
    logging.AddNLog();
});

var app = builder.Build();

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
