using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace courier.management.system.DTO.ResponseModels.Inner
{
    public class TimeTypeVM
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? WeekDay { get; set; }
        public string? Time { get; set; }
        public string? Interval { get; set; }


    }
}