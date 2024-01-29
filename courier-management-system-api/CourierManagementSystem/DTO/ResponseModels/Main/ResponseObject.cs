using courier.management.system.DTO.HelperModels;

namespace courier.management.system.DTO.ResponseModels.Main
{
    public class ResponseObject<T>
    {
        public StatusModel Status { get; set; }
        public T Response { get; set; }
        public string TraceID { get; set; }
    }
}
