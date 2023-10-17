using AutoMapper;
using reserva.user.backend.Infrastructure.Repository;
using reserva.user.backend.Models;
using reserva.user.backend.Services.Interface;
using System.ComponentModel.Design;

namespace reserva.user.backend.Services.Implementation
{
    public class LookupService : ILookupService
    {
       // private readonly IRepository<COMPANY> _companies;
      
        public LookupService(
            //IRepository<COMPANY> companies
            )
        {
           // _companies = companies;
        }

        //public IQueryable<COMPANY> GetCompanies()
        //{
        //    return _companies.AllQuery;
        //}


    }
}
