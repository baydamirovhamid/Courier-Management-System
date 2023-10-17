using reserva.user.backend.DTO.HelperModels;

namespace reserva.user.backend.DTO.ResponseModels.Main
{
    public class ResponseList<T>
    {
        public StatusModel Status { get; set; }
        public List<T> Data { get; set; }
        public string TraceID { get; set; }
    }
}
