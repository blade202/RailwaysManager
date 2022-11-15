using System.ComponentModel.DataAnnotations;

namespace TrainBackendApi.Models
{
    public class RoutesRequest
    {
        
        [Required]
        public int DepatureId { get; set; }
        [Required]
        public int ArrivalId { get; set; }
        [Required]
        public int Range { get; set; }
    }
}
