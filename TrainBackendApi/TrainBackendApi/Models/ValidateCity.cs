using System.ComponentModel.DataAnnotations;

namespace TrainBackendApi.Models
{
    public class ValidateCity
    {
        [Required]
        [MaxLength(16)]
        public string CityName { get; set; }
    }
}
