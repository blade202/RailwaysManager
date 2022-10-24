using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrainBackendApi.Models
{
    [Table("RALILWAYS")]
    public class Railway
    {
        [Key]
        [DatabaseGenerated( DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [Column("DepatureCyity")]
        public string DepatureCity { get; set; }

        [Required]
        [Column("ArivalCity")]
        public string ArivalCity { get; set; }

        [Required]
        [Column("KM")]
        public int KM { get; set; }
    }
}
