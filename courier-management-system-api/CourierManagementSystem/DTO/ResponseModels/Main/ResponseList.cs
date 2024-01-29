using courier.management.system.DTO.HelperModels;
using courier.management.system.DTO.ResponseModels.Inner;

namespace courier.management.system.DTO.ResponseModels.Main
{
    public class ResponseList<T>
    {
        public StatusModel Status { get; set; }
        public List<T> Data { get; set; }
        public string TraceID { get; set; }
        public StaticVM Response { get; internal set; }
    }
}
