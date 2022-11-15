using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using TrainBackendApi.Models;
using TrainBackendApi.Services;

namespace TrainBackendApi.Controllers
{
    public class CitiesController : Controller
    {
        private readonly CityService citiservice;
        private readonly CacheService cacheService;
        private readonly UserManager userManager;
        private IMemoryCache memoryCache;

        public CitiesController(CityService citiservice, UserManager userManager, IMemoryCache memoryCache, CacheService cacheService)
        {
            this.citiservice = citiservice;
            this.userManager = userManager;
            this.memoryCache = memoryCache;
            this.cacheService = cacheService;
        }
        [Route("ReadCities")]
        public IActionResult Read()
        {

            citiservice.readCities();
            return Ok();
        }
        [HttpGet]
        [Authorize]
        [Route("GetCities")]
        public IActionResult GettAllCity()
        {
            if (!memoryCache.TryGetValue("Cities", out List<City> Cities))
            {
               Cities=cacheService.CacheCities();
            }
            return Ok(Cities);
        }
        [HttpPost]
        [Authorize(Roles ="admin")]
        [Route("DeletCity")]
        public IActionResult DeleteCity([FromBody] DeleteRquest rquest)
        {
            citiservice.Delete(rquest.id);
            cacheService.DeletCitesCache();
            return Ok();
        }
        [HttpPut]
        [Authorize(Roles = "admin")]
        [Route("CreatCity")]
        public IActionResult CreateCity([FromForm] CreatCityReguest newcity)
        {

            if (ModelState.IsValid)
            {
                var createdcity = citiservice.Create(newcity);
                if(createdcity!=null)
                {
                    cacheService.DeletCitesCache();
                }
                return Ok(createdcity);
            }
            return BadRequest();
        }
        [HttpPost]
        [Authorize(Roles = "admin")]
        [Route("UpdateCity")]
        public IActionResult UpdateCity([FromBody] City newcity)
        {

            if (ModelState.IsValid)
            {
                var updatedcity = citiservice.Update(newcity);
                if(updatedcity!=null)
                {
                    cacheService.DeletCitesCache();
                }
                return Ok(updatedcity);
            }
            return BadRequest();
        }



    }

}
