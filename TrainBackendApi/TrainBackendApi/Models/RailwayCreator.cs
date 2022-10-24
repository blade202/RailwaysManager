using System.ComponentModel.DataAnnotations;

namespace TrainBackendApi.Models
{
    public class RailwayCreator
    {
        [Required]
        public int DepCitiyId { get; set; }
        [Required]
        public int AriCityId { get; set; }
        [Required]
        [MaxLength(5)]
        public int Km { get; set; }
    }
}
