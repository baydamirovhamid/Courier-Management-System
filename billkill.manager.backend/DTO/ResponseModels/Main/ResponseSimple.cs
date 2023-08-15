using billkill.manager.backend.DTO.HelperModels;

namespace billkill.manager.backend.DTO.ResponseModels.Main
{
    public class ResponseSimple
    {
        public StatusModel Status { get; set; }
        public string TraceID { get; set; }
    }
}
