namespace billkill.manager.backend.DTO.RequestModels
{
    public class ResetPasswordDto
    {
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Token { get; set; }
        public string Email { get; set; }
    }
}
