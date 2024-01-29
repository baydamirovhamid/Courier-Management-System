namespace courier.management.system.Services.Interface
{
    public interface IEmailService
    {
        bool SendEmailForgetPassword(string userMail, string token);
    }
}
