using billkill.manager.backend.DTO.HelperModels;

namespace billkill.manager.backend.DTO.ResponseModels.Main
{
    public class ResponseObject<T>
    {
        public StatusModel Status { get; set; }
        public T Response { get; set; }
        public string TraceID { get; set; }
    }
}
