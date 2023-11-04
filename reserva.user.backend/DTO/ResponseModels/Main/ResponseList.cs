using reserva.user.backend.DTO.HelperModels;
using reserva.user.backend.DTO.ResponseModels.Inner;

namespace reserva.user.backend.DTO.ResponseModels.Main
{
    public class ResponseList<T>
    {
        public StatusModel Status { get; set; }
        public List<T> Data { get; set; }
        public string TraceID { get; set; }
        public StaticVM Response { get; internal set; }
    }
}
