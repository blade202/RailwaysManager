using System.ComponentModel.DataAnnotations;

namespace TrainBackendApi.Models
{
    public class UpdateRailwayRequest
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int DepCitiyId { get; set; }
        [Required]
        public int AriCityId { get; set; }
        [Required]
        [MaxLength(5)]
        public int Km { get; set; }
    }
}
