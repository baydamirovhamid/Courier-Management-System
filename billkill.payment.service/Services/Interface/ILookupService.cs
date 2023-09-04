using billkill.payment.service.Models;

namespace billkill.payment.service.Services.Interface
{
    public interface ILookupService
    {
        IQueryable<MANAGEMENT_COMPANY> GetCompanies();
        IQueryable<BUILDING> GetBuildings(int companyId);
        IQueryable<APARTMENT> GetApartments(int buildingId);
        IQueryable<EMPLOYEE_ROLE> GetEmployeeRoles();
        IQueryable<PAYMENT_TYPE> GetInvoiceTypes();
        IQueryable<SERVICE> GetServices();
    }
}
