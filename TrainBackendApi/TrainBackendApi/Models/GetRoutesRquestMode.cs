namespace TrainBackendApi.Models
{
    public class GetRoutesRquestMode
    {
        public int DepatureId { get; set; }
        public int ArrivalId { get; set; }
        public int Range { get; set; }
    }
}
