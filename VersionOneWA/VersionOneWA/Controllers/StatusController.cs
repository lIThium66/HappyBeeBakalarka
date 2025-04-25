using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VersionOneWA.Controllers;
using VersionOneWA.Shared.Classes;
using VersionOneWA.Shared.Services;

namespace VersionOneWA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusController : ControllerBase
    {
        private readonly IStatusServices _statusServices;
        public StatusController(IStatusServices statusServices)
        {
            _statusServices = statusServices;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Status>> GetStatusById(int id)
        {
            var status = await _statusServices.GetStatusById(id);
            return Ok(status);
        }

        [HttpPost]
        public async Task<ActionResult<Status>> AddStatus(Status status)
        {
            var addedStatus = await _statusServices.AddStatus(status);
            return Ok(addedStatus);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Status>> EditStatus(int id, Status status)
        {
            var updatedStatus = await _statusServices.EditStatus(id, status);
            return Ok(updatedStatus);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Status>> DeleteStatus(int id, Status status)
        {
            var deletedStatus = await _statusServices.DeleteStatus(id);
            return Ok(deletedStatus);
        }

        [HttpGet]
        public async Task<ActionResult<List<Job>>> GetAllStatuses()
        {
            var statuses = await _statusServices.GetStatuses();
            return Ok(statuses);
        }

        [HttpGet("user/{userId}")]
        public async Task<ActionResult<List<Job>>> GetUserJobs(string userId)
        {
            var statuses = await _statusServices.GetUserStatuses(userId);
            return Ok(statuses);
        }
    }
}




