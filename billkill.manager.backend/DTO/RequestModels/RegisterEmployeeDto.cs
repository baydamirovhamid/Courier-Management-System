namespace billkill.manager.backend.DTO.RequestModels
{
    public class RegisterEmployeeDto: RegisterUserDto
    {
        public int RoleId { get; set; }
        public int CompanyId { get; set; }
    }
}
