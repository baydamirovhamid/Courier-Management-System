using reserva.user.backend.DTO.HelperModels;

namespace reserva.user.backend.DTO.ResponseModels.Main
{
    public class ResponseListTotal<T>
    {
        public StatusModel Status { get; set; }
        public ResponseTotal<T> Response { get; set; }
        public string TraceID { get; set; }
    }
}
