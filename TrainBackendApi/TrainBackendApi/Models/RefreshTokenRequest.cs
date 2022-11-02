using System.ComponentModel.DataAnnotations;

namespace TrainBackendApi.Models
{
    public class RefreshTokenRequest
    {
        [Required]
        [MinLength(5)]
        public string oldToken { get; set; }
        [Required]
        [MinLength(5)]
        public string RefreshToken { get; set; }
    }
}
