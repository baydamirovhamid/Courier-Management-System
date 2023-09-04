using billkill.payment.service.DTO.HelperModels;

namespace billkill.payment.service.DTO.ResponseModels.Main
{
    public class ResponseObject<T>
    {
        public StatusModel Status { get; set; }
        public T Response { get; set; }
        public string TraceID { get; set; }
    }
}
