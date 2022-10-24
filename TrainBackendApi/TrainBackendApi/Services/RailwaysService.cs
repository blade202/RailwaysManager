using TrainBackendApi.Models;
using TrainBackendApi.Repository;

namespace TrainBackendApi.Services
{
    public class RailwaysService
    {
        private readonly TrainDbConntext dbConntex;
        private readonly CityService cityService;
        public static bool Updated { get; set; }

        public RailwaysService(TrainDbConntext dbConntex, CityService cityService)
        {
            this.dbConntex = dbConntex;
            this.cityService = cityService;
        }

        public List<Railway> GettAll()
        {
            return dbConntex.Railways.ToList();
        }
        public bool  CreatedSeascessfully(RailwayCreator railway)
        {
            var arivalcity = cityService.GetById(railway.AriCityId);
            var depatcity = cityService.GetById(railway.DepCitiyId);


            if (arivalcity!=null&&depatcity!=null)
            {
                dbConntex.Railways.Add(new Railway { KM=railway.Km,ArivalCity=arivalcity.CityName,DepatureCity=depatcity.CityName});
                dbConntex.SaveChanges();
                return true;
            }
            return false;
        }
        public void readrailways()
        {
            StreamReader railwaysreader = new StreamReader("railways.txt");
            while (!railwaysreader.EndOfStream)
{
                string[] spliter = railwaysreader.ReadLine().Split(';');
                dbConntex.Railways.Add(new Railway { ArivalCity = spliter[0], DepatureCity = spliter[1], KM = int.Parse(spliter[2]) }); 
            }
            dbConntex.SaveChanges();
        }

    }
}
