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

    }
}
