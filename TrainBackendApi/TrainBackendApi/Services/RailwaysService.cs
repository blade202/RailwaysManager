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
        public Railway GetById(int id)
        {
            return dbConntex.Railways.FirstOrDefault(x => x.Id == id);
        }
        public bool  CreatedSeascessfully(RailwayCreator railway)
        {
            var arivalcity = cityService.GetById(railway.AriCityId);
            var depatcity = cityService.GetById(railway.DepCitiyId);
            if (arivalcity != null && depatcity != null)
            {

                if (dbConntex.Railways.FirstOrDefault(x => x.ArivalCity == arivalcity.CityName && x.DepatureCity == depatcity.CityName) != null)
                {
                    dbConntex.Railways.Add(new Railway { KM = railway.Km, ArivalCity = arivalcity.CityName, DepatureCity = depatcity.CityName });
                    dbConntex.SaveChanges();
                    return true;
                }
            }
            return false;
        }
        public bool UpdatedSeascessfullySeascessfully(RailwayCreator railway,int id)
        {
            var arivalcity = cityService.GetById(railway.AriCityId);
            var depatcity = cityService.GetById(railway.DepCitiyId);
            if (arivalcity != null && depatcity != null)
            {
                if (dbConntex.Railways.FirstOrDefault(x => x.ArivalCity == arivalcity.CityName && x.DepatureCity == depatcity.CityName) != null)
                {
                    var updaterailway = GetById(id);
                    if(updaterailway!=null)
                    {
                        updaterailway.ArivalCity=arivalcity.CityName;
                        updaterailway.DepatureCity=depatcity.CityName;
                        updaterailway.KM = railway.Km;
                        dbConntex.SaveChanges();
                    }
                    return true;
                }
            }
            return false;
        }
        public bool DeletedSeasscessfully(int id)
        {
            var deleterailway= GetById(id);
            if(deleterailway!=null)
            {
                dbConntex.Railways.Remove(deleterailway);
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
        public List<ReturnRalway> Generateroutes(int DepatureCityid, int Arrivalcityid)
        {
            List<Railway> temprailways = new List<Railway>();
            List<ReturnRalway> returnRalways = new List<ReturnRalway>();
            List<City> cities = cityService.GetAll();
            List<Railway> railways = GettAll();
            if(cityService.GetById(DepatureCityid)==null||cityService.GetById(Arrivalcityid)==null)
            {
                return null;
            }
            Graph g = new Graph(cities.Count+1);
            foreach (var item in cities)
            {
                foreach (var railway in railways.Where(x => x.DepatureCity == item.CityName))
                {
                    g.addEdge(item.Id, new RailwayNode { NodeId = cities.FirstOrDefault(x => x.CityName == railway.ArivalCity).Id, Railways = railway });
                }
            }
            g.printAllPaths(new RailwayNode { NodeId = DepatureCityid },Arrivalcityid);
            int id = 0;
            foreach (var item in g.Resualt)
            {
             
                for (int i = 1; i < item.Count; i++)
                {
                    temprailways.Add(item[i].Railways);
                }
                id++;
                returnRalways.Add(new ReturnRalway(temprailways,id));
                temprailways = new List<Railway>();
            }
            return returnRalways.OrderBy(x=>x.Price).ToList();
        }

    }
}
