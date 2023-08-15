using billkill.manager.backend.DTO.HelperModels;

namespace billkill.manager.backend.DTO.ResponseModels.Main
{
    public class ResponseList<T>
    {
        public StatusModel Status { get; set; }
        public List<T> Data { get; set; }
        public string TraceID { get; set; }
    }
}
