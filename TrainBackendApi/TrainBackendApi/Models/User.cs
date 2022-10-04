using System.ComponentModel.DataAnnotations;

namespace TrainBackendApi.Models
{
    public class User
    {
        [Key]
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}
