using reserva.user.backend.Models;

namespace reserva.user.backend.Services.Interface
{
    public interface ILookupService
    {
        IQueryable<STATIC_DATA> GetStaticDatas();
    }
}
