using billkill.payment.service.DTO.HelperModels;

namespace billkill.payment.service.DTO.ResponseModels.Main
{
    public class ResponseList<T>
    {
        public StatusModel Status { get; set; }
        public List<T> Data { get; set; }
        public string TraceID { get; set; }
    }
}
