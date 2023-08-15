namespace billkill.manager.backend.DTO.HelperModels
{
    public class ResponseTotal<T>
    {
        public List<T> Data { get; set; }
        public decimal Total { get; set; }
        public decimal? TotalPrice { get; set; }
    }
}
