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
        public IActionResult GetRoutes(int depatciyiid,int arivelcityid)
        {
            string Chachekey = $"{depatciyiid} {arivelcityid}";
            if(!_chache.TryGetValue(Chachekey,out List<ReturnRalway> returnrailways))
            {
                returnrailways = railwaysServic1e.Generateroutes(depatciyiid, arivelcityid);
                var cacheEntryOptions = new MemoryCacheEntryOptions
                {
                    AbsoluteExpiration = DateTime.Now.AddMinutes(5),
                    SlidingExpiration = TimeSpan.FromMinutes(2),

                };
                _chache.Set(Chachekey, returnrailways, cacheEntryOptions);
            }
            return Ok(returnrailways);
        }
    }
}
