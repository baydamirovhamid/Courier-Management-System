using billkill.manager.backend.DTO.HelperModels;

namespace billkill.manager.backend.DTO.ResponseModels.Main
{
    public class ResponseListTotal<T>
    {
        public StatusModel Status { get; set; }
        public ResponseTotal<T> Response { get; set; }
        public string TraceID { get; set; }
    }
}
