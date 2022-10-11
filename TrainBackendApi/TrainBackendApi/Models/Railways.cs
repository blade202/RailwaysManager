using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsoleApp1
{
    [Table("RALILWAYS")]
    public class Railways
    {

     

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
