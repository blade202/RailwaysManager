using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using TrainBackendApi.Models;
using TrainBackendApi.Services;

namespace TrainBackendApi.Controllers
{
    public class RailwaysController:ControllerBase
    {
        private readonly RailwaysService railwaysServic1e;
        private readonly UserManager userManager;
        private readonly CacheService cacheService;
        private IMemoryCache _chache;

        public RailwaysController(RailwaysService railwaysServic1e, UserManager userManager, IMemoryCache chache, CacheService cacheService)
        {
            this.railwaysServic1e = railwaysServic1e;
            this.userManager = userManager;
            _chache = chache;
            this.cacheService = cacheService;
        }
        [Route("ReadRalways")]
        public IActionResult Read()
        {
            railwaysServic1e.readrailways();
            return Ok();
        }
        [Route("GetRoutes")]
        [HttpPost]
        [Authorize]
        public IActionResult GetRoutes([FromBody] RoutesRequest requestModel)
        {
            if (ModelState.IsValid)
            {
                if (!_chache.TryGetValue($"{requestModel.DepatureId}{requestModel.ArrivalId}", out List<ReturnRalway> returnrailways))
                {
                    returnrailways = cacheService.CacheRoutes(requestModel.DepatureId, requestModel.ArrivalId);
                }

                if (returnrailways != null) 
                {
                    if (requestModel.Range + 50 > returnrailways.Count)
                    {
                        return Ok(returnrailways.Skip(requestModel.Range).Take(returnrailways.Count - requestModel.Range));
                    }
                    return Ok(returnrailways.Skip(requestModel.Range).Take(50));
                }
                   
                
            }
            return Ok("nulla");
        }
        [HttpGet]
        [Route("GetRailways")]
        [Authorize(Roles ="admin")]
        public IActionResult GettAllRailways()
        {
            return Ok(railwaysServic1e.GettAll());
        }
        [HttpDelete]
        [Route("DeleteRailway")]
        [Authorize(Roles ="admin")]
        public IActionResult DeleteRailway([FromBody] DeleteRquest requeset)
        {
            railwaysServic1e.DeleteRailway(requeset.id);
            cacheService.DeleteAllCacgedRoutes();
            return Ok();
        }
        [HttpPost]
        [Route("CreateRailwy")]
        [Authorize(Roles = "admin")]
        public IActionResult CreateRailway([FromBody] CreateRailwayRequest request)
        {
            if (ModelState.IsValid)
            {
                var createdrailway = railwaysServic1e.CreateRailway(request);
                if(createdrailway!=null)
                {
                    cacheService.DeleteAllCacgedRoutes();
                    return Ok(createdrailway);
                }
                return BadRequest();
              
            }
            return BadRequest();
        }
        [HttpPost]
        [Route("UpdateRailway")]
        [Authorize(Roles = "admin")]
        public IActionResult UpdateRailway([FromBody] UpdateRailwayRequest requeset)
        {
            if(ModelState.IsValid)
            {
                var updatedrailway = railwaysServic1e.UpdaeRaiwlay(requeset);
                cacheService.DeleteAllCacgedRoutes();
                return Ok();
            }
            return BadRequest();
           
        }
    }
    
}
