using billkill.manager.backend.Models;

namespace billkill.manager.backend.Services.Interface
{
    public interface ILookupService
    {
        IQueryable<MANAGEMENT_COMPANY> GetCompanies();
        IQueryable<BUILDING> GetBuildings(int companyId);
        IQueryable<APARTMENT> GetApartments(int buildingId);
        IQueryable<EMPLOYEE_ROLE> GetEmployeeRoles();
        IQueryable<INVOICE_TYPE> GetInvoiceTypes();
        IQueryable<SERVICE> GetServices();
    }
}
