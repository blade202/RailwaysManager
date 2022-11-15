using Microsoft.Extensions.Caching.Memory;
using TrainBackendApi.Models;

namespace TrainBackendApi.Services
{
    public class CacheService
    {
        private IMemoryCache memoryCache;
        private CityService cityService;
        private RailwaysService raiwlaysService;

        public CacheService(IMemoryCache memoryCache, CityService cityService, RailwaysService raiwlaysService)
        {
            this.memoryCache = memoryCache;
            this.cityService = cityService;
            this.raiwlaysService = raiwlaysService;
        }

        private static List<string> CachedRoutes=new List<string>();

        public List<City> CacheCities()
        {
            var cities = cityService.GetAll();
            var ChacherEntryOption = new MemoryCacheEntryOptions
            {
                AbsoluteExpiration = DateTime.Now.AddMinutes(25),
                SlidingExpiration = TimeSpan.FromMinutes(20),
                Size = 1024
            };
            memoryCache.Set("Cities", cities, ChacherEntryOption);
            return cities;
        }
        public void DeletCitesCache()
        {
            memoryCache.Remove("Cities");
            DeleteAllCacgedRoutes();
        }
        public List<ReturnRalway> CacheRoutes(int depatureid,int arivalid)
        {
            var routes = raiwlaysService.Generateroutes(depatureid,arivalid);
            if (routes != null)
            {
                var ChacherEntryOption = new MemoryCacheEntryOptions
                {
                    AbsoluteExpiration = DateTime.Now.AddMinutes(25),
                    SlidingExpiration = TimeSpan.FromMinutes(20),
                    Size = 1024
                };
                string cachekey = $"{depatureid}{arivalid}";
                memoryCache.Set(cachekey, routes, ChacherEntryOption);
                CachedRoutes.Add(cachekey);
            }
            return routes;
        }
        public void DeleteAllCacgedRoutes()
        {
            foreach (var item in CachedRoutes)
            {
                memoryCache.Remove(item);
                CachedRoutes.Remove(item);
            }
        }
    }
}
