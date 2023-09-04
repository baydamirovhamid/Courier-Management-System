using billkill.payment.service.Infrastructure.Repository;
using billkill.payment.service.Models;
using billkill.payment.service.Services.Interface;
using System.ComponentModel.Design;

namespace billkill.payment.service.Services.Implementation
{
    public class LookupService : ILookupService
    {
        private readonly IRepository<MANAGEMENT_COMPANY> _managementCompany;
        private readonly IRepository<BUILDING> _building;
        private readonly IRepository<APARTMENT> _apartment;
        private readonly IRepository<EMPLOYEE_ROLE> _employeeRole;
        private readonly IRepository<PAYMENT_TYPE> _invoiceType;
        private readonly IRepository<SERVICE> _service;

        public LookupService(
            IRepository<MANAGEMENT_COMPANY> managementCompany,
            IRepository<BUILDING> building,
            IRepository<APARTMENT> apartment,
            IRepository<EMPLOYEE_ROLE> employeeRole,
            IRepository<PAYMENT_TYPE> invoiceType,
            IRepository<SERVICE> service)
        {
            _managementCompany = managementCompany;
            _building = building;
            _apartment = apartment;
            _employeeRole = employeeRole;
            _invoiceType = invoiceType;
            _service = service;

        }

        public IQueryable<APARTMENT> GetApartments(int buildingId)
        {
            return _apartment.AllQuery.Where(x => x.BuildingId == buildingId);
        }

        public IQueryable<BUILDING> GetBuildings(int companyId)
        {
            return _building.AllQuery.Where(x => x.CompanyId == companyId);
        }

        public IQueryable<MANAGEMENT_COMPANY> GetCompanies()
        {
            return _managementCompany.AllQuery;
        }

        public IQueryable<EMPLOYEE_ROLE> GetEmployeeRoles()
        {
            return _employeeRole.AllQuery;
        }

        public IQueryable<PAYMENT_TYPE> GetInvoiceTypes()
        {
            return _invoiceType.AllQuery;
        }

        public IQueryable<SERVICE> GetServices()
        {
            return _service.AllQuery;
        }
    }
}
