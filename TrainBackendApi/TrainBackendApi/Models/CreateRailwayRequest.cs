using System.ComponentModel.DataAnnotations;

namespace TrainBackendApi.Models
{
    public class CreateRailwayRequest
    {
        [Required]
        public int DepatureCityId { get; set; }
        [Required]
        public int ArivalCityId { get; set; }
        [Required]
        public int Km { get; set; }
    }
}
