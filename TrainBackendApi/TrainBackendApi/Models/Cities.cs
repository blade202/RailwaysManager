using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrainBackendApi.Models
{
    
    [Table("CITIES")]
    public class Cities
    {

        [Key]
        public int Id { get; set; }
        [Required]
        [Column("NAME")]
        public string CityName { get; set; }
    }
}
