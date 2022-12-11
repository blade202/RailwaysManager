using Microsoft.Extensions.Caching.Memory;
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
            return dbConntex.Railways.OrderBy(x=>x.DepatureCity).ToList();
        }
        public Railway GetById(int id)
        {
            return dbConntex.Railways.FirstOrDefault(x => x.Id == id);
        }
        public Railway CreateRailway(CreateRailwayRequest request)
        {
            var arivalcity = cityService.GetById(request.ArivalCityId);
            var depatcity = cityService.GetById(request.DepatureCityId);
            if (arivalcity != null && depatcity != null)
            {

                if (dbConntex.Railways.FirstOrDefault(x => x.ArivalCity == arivalcity.CityName && x.DepatureCity == depatcity.CityName) == null)
                {
                    var newrailway = new Railway
                    {
                        KM = request.Km,
                        ArivalCity = arivalcity.CityName,
                        DepatureCity = depatcity.CityName
                    };
                    dbConntex.Railways.Add(newrailway);
                    dbConntex.SaveChanges();
                    return newrailway;
                }
            }
            return null;
        }
        public Railway UpdaeRaiwlay(UpdateRailwayRequest requset)
        {
            var arivalcity = cityService.GetById(requset.AriCityId);
            var depatcity = cityService.GetById(requset.DepCitiyId);
            if (arivalcity != null && depatcity != null)
            {
                if (dbConntex.Railways.FirstOrDefault(x => x.ArivalCity == arivalcity.CityName && x.DepatureCity == depatcity.CityName&&x.KM==requset.Km) == null)
                {
                    var updaterailway = GetById(requset.Id);
                    if(updaterailway!=null)
                    {
                        updaterailway.ArivalCity=arivalcity.CityName;
                        updaterailway.DepatureCity=depatcity.CityName;
                        updaterailway.KM = requset.Km;
                        dbConntex.SaveChanges();
                    }
                    return updaterailway;
                }
            }
            return null;
        }
        public void DeleteRailway(int id)
        {
            var deleterailway= GetById(id);
            if(deleterailway!=null)
            {
                dbConntex.Railways.Remove(deleterailway);
                dbConntex.SaveChanges();            
            }

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
            if (cityService.GetById(DepatureCityid) == null || cityService.GetById(Arrivalcityid) == null)
            {
                return null;
            }
            List<Railway> temprailways = new List<Railway>();
            List<ReturnRalway> returnRalways = new List<ReturnRalway>();
            List<City> cities = cityService.GetAll();
            int ctid = 0;
            foreach (City city in cities)
            {
                if(DepatureCityid==city.Id)
                {
                    DepatureCityid = ctid;                    
                }
                if(Arrivalcityid==city.Id)
                {
                    Arrivalcityid = ctid;
                }
                city.Id = ctid;
                ctid++;
            }
            List<Railway> railways = GettAll();
            Graph g = new Graph(cities.Count);
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
