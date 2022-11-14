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
        private readonly UserManager userManager;
        private IMemoryCache memoryCache;

        public CitiesController(CityService citiservice, UserManager userManager, IMemoryCache memoryCache)
        {
            this.citiservice = citiservice;
            this.userManager = userManager;
            this.memoryCache = memoryCache;
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
                Cities = citiservice.GetAll();
                var ChacherEntryOption = new MemoryCacheEntryOptions {
                    AbsoluteExpiration = DateTime.Now.AddMinutes(25),
                    SlidingExpiration = TimeSpan.FromMinutes(20),
                    Size = 1024
                };
                memoryCache.Set("Cities", Cities, ChacherEntryOption);
            }
            return Ok(Cities);
        }
        [HttpPost]
        [Authorize(Roles ="admin")]
        [Route("DeletCity")]
        public IActionResult DeleteCity([FromBody] DeleteRquest rquest)
        {
            citiservice.Delete(rquest.id);
            return Ok();
        }
        [HttpPut]
        [Authorize(Roles = "admin")]
        [Route("CreatCity")]
        public IActionResult CreateCity([FromForm] CreatCityReguest newcity)
        {

            if (ModelState.IsValid)
            {
                return Ok(citiservice.Create(newcity));
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
                return Ok(citiservice.Update(newcity));
            }
            return BadRequest();
        }



    }

}
