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
        private IMemoryCache _chache;

        public RailwaysController(RailwaysService railwaysServic1e, UserManager userManager, IMemoryCache chache)
        {
            this.railwaysServic1e = railwaysServic1e;
            this.userManager = userManager;
            _chache = chache;
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
        public IActionResult GetRoutes([FromBody] GetRoutesRquestMode rquestModel)
        {
            if (ModelState.IsValid)
            {
                string Chachekey = $"{rquestModel.ArrivalId} {rquestModel.ArrivalId}";
                if (!_chache.TryGetValue(Chachekey, out List<ReturnRalway> returnrailways))
                {
                    returnrailways = railwaysServic1e.Generateroutes(rquestModel.DepatureId, rquestModel.ArrivalId);
                    var cacheEntryOptions = new MemoryCacheEntryOptions
                    {
                        AbsoluteExpiration = DateTime.Now.AddMinutes(5),
                        SlidingExpiration = TimeSpan.FromMinutes(2),

                    };
                    _chache.Set(Chachekey, returnrailways, cacheEntryOptions);
                }

                if (returnrailways != null) 
                {
                    if (rquestModel.Range + 50 > returnrailways.Count)
                    {
                        return Ok(returnrailways.Skip(rquestModel.Range).Take(rquestModel.Range - returnrailways.Count));
                    }
                    return Ok(returnrailways.Skip(rquestModel.Range).Take(50));
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
    }
    
}
