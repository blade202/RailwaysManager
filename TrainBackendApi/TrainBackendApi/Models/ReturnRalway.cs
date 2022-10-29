using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainBackendApi.Models
{
    public class ReturnRalway
    {
    
        
        public int Km { get; set; }
   
        public int Price { get; set; }
      
        public List<Railway> Railways { get; set; }

        public int Id { get; set; }

        public ReturnRalway(List<Railway> railways,int id)
        {
            this.Railways = railways;
            Km = railways.Sum(x => x.KM);
            Price = Km * 15;
            Id = id;
        }
    }
}
