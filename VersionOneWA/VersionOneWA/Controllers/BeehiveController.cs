using Microsoft.AspNetCore.Mvc;
using VersionOneWA.Shared.Classes;
using VersionOneWA.Shared.Services;

namespace VersionOneWA.Controllers
{  
        [Route("api/[controller]")]
        [ApiController]
        public class BeehiveController : ControllerBase 
        {
            private readonly IBeehiveService _beehiveServices;

            public BeehiveController(IBeehiveService beehiveService)
            {
                _beehiveServices = beehiveService;
            }

            [HttpGet("{id}")]
            public async Task<ActionResult<Beehive>> GetBeehiveById(int id)
            {
                var selectedBeehive = await _beehiveServices.GetBeehiveById(id);
                return Ok(selectedBeehive);
            }
            [HttpPost]
            public async Task<ActionResult<Beehive>> AddBeehive(Beehive beehive)
            {
                var addedBeehive = await _beehiveServices.AddBeehive(beehive);
                return Ok(addedBeehive);
            }
            [HttpPut("{id}")]
            public async Task<ActionResult<Beehive>> EditBeehive(int id, Beehive beehive)
            {
                var updatedBeehive = await _beehiveServices.EditBeehive(id, beehive);
                return Ok(updatedBeehive);
            }
            [HttpDelete("{id}")]
            public async Task<ActionResult<Beehive>> DeleteBeehive(int id)
            {
                var deletedBeehive = await _beehiveServices.DeleteBeehive(id);
                return Ok(deletedBeehive);
            }

            [HttpGet("user/{userId}")]
            public async Task<ActionResult<List<Job>>> GetUserJobs(string userId)
            {
                var beehives = await _beehiveServices.GetUserBeehives(userId);
                return Ok(beehives);
            }

    }
}
