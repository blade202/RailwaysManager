using Microsoft.Extensions.Caching.Memory;
using TrainBackendApi.Models;
using TrainBackendApi.Repository;

namespace TrainBackendApi.Services
{
    public class CityService
    {
        private readonly TrainDbConntext dbConntext;

        public CityService(TrainDbConntext dbConntext)
        {
            this.dbConntext = dbConntext;
        }

        public List<City>Cities()
        {
            return dbConntext.Cities.ToList();
        }
        public City GetById(int id)
        {
            var city=dbConntext.Cities.FirstOrDefault(c => c.Id == id);
            if (city != null)
            {
                return city;
            }
            return null;
        }
        public void readCities()
        {
            StreamReader citireader = new StreamReader("cities.txt");

            while (!citireader.EndOfStream)
            {
                dbConntext.Cities.Add(new City { CityName = citireader.ReadLine()});

            }
            dbConntext.SaveChanges();

        }
        public List<City>GetAll()
        {
            return dbConntext.Cities.ToList();
        }
        public City Create(CreatCityReguest newcity)
        {
            if(dbConntext.Cities.FirstOrDefault(x=>x.CityName==newcity.CityName)==null)
            {
                var city=new City() { CityName=newcity.CityName};
                dbConntext.Cities.Add(city);
                dbConntext.SaveChanges();
                return city;
       
            }
            return null;
        }
        public City Update(City updatecity)
        {
            var city = dbConntext.Cities.FirstOrDefault(x => x.Id == updatecity.Id);
            if(city != null)
            {
                city.CityName = updatecity.CityName;
                dbConntext.SaveChanges();
                return city;
            }
            return null;
        }
        public void Delete(int id)
        {
            var city = GetById(id);
            if(city!=null)
            {
                DeleteRailwaytoCity(city);
                dbConntext.Cities.Remove(city);
                dbConntext.SaveChanges();
            }
        }
        public void DeleteRailwaytoCity(City city)
        {
            var railways = dbConntext.Railways.Where(x => x.ArivalCity == city.CityName || x.DepatureCity == city.CityName);
            foreach (var item in railways)
            {
                dbConntext.Railways.Remove(item);
            }
            dbConntext.SaveChanges();
        }

    }
}
