using billkill.payment.service.DTO.HelperModels;

namespace billkill.payment.service.DTO.ResponseModels.Main
{
    public class ResponseSimple
    {
        public StatusModel Status { get; set; }
        public string TraceID { get; set; }
    }
}
