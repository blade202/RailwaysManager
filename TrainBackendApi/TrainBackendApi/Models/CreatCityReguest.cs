using System.ComponentModel.DataAnnotations;

namespace TrainBackendApi.Models
{
    public class CreatCityReguest
    {
        [MaxLength(15)]
        [MinLength(0)]
        public string CityName { get; set; }
    }
}
