using reserva.user.backend.DTO.HelperModels;

namespace reserva.user.backend.DTO.ResponseModels.Main
{
    public class ResponseSimple
    {
        public StatusModel Status { get; set; }
        public string TraceID { get; set; }
    }
}
