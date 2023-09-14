using billkill.payment.service.DTO.HelperModels.Const;
using billkill.payment.service.DTO.ResponseModels.Main;
using billkill.payment.service.Infrastructure;
using billkill.payment.service.Infrastructure.Repository;
using billkill.payment.service.Models;
using billkill.payment.service.Services.Implementation;
using billkill.payment.service.Services.Interface;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.Text;

namespace billkill.payment.service.Extensions
{
    public class ApiKeyMiddleware
    {
        private readonly RequestDelegate _next;
        private const string APIKEY = "ApiKey";
        public ApiKeyMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context, IRepository<API_KEY> apiKey)
        {
            try
            {

                if (!context.Request.Headers.TryGetValue(APIKEY, out
                   var extractedApiKey))
                {
                   
                    ResponseSimple response = new ResponseSimple();
                    response.Status = new DTO.HelperModels.StatusModel();
                    response.Status.ErrorCode = ErrorCodes.AUTH;
                    response.Status.Message = "ApiKey əlavə olunmalıdır!";
                    context.Response.StatusCode = 401;
                    context.Response.ContentType = "application/json";
                    await context.Response.WriteAsync(JsonConvert.SerializeObject(response));
                    return;
                }

                var selectedKey = apiKey.AllQuery.FirstOrDefault(x => x.ApiKey == extractedApiKey[0]);
                if (selectedKey==null)
                {
                    ResponseSimple response = new ResponseSimple();
                    response.Status = new DTO.HelperModels.StatusModel();
                    response.Status.ErrorCode = ErrorCodes.AUTH;
                    response.Status.Message = "Giriş icazəniz yoxdur!";
                    context.Response.StatusCode = 401;
                    context.Response.ContentType = "application/json";
                    await context.Response.WriteAsync(JsonConvert.SerializeObject(response));
                    return;
                }
                await _next(context);
            }
            catch(Exception ex)
            {

            }
        }
    }
}
