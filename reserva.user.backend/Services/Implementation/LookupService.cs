using AutoMapper;
using reserva.user.backend.Infrastructure.Repository;
using reserva.user.backend.Models;
using reserva.user.backend.Services.Interface;
using System.ComponentModel.Design;

namespace reserva.user.backend.Services.Implementation
{
    public class LookupService : ILookupService
    {
        private readonly IRepository<STATIC_DATA> _staticDatas;
      
        public LookupService(
            IRepository<STATIC_DATA> staticDatas
            )
        {
            _staticDatas = staticDatas;
        }

        public IQueryable<STATIC_DATA> GetStaticDatas()
        {
            return _staticDatas.AllQuery;
        }

    }
}
