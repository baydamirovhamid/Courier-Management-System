namespace billkill.payment.service.Services.Interface
{
    public interface IEmailService
    {
        bool SendEmailForgetPassword(string userMail, string token);
    }
}
