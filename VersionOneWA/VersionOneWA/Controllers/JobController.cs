using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VersionOneWA.Shared.Classes;
using VersionOneWA.Shared.Services;

namespace VersionOneWA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobController : ControllerBase
    {
        private readonly IJobServices _jobServices;

        public JobController(IJobServices jobService)
        {
            _jobServices = jobService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Job>> GetGameById(int id)
        {
            var selectedJob = await _jobServices.GetJobById(id);
            return Ok(selectedJob);
        }
        [HttpPost]
        public async Task<ActionResult<Job>> AddJob(Job job) 
        { 
            var addedJob = await _jobServices.AddJob(job);
            return Ok(addedJob);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<Job>> EditJob(int id, Job job)
        {
            var updatedJob = await _jobServices.EditJob(id, job);
            return Ok(updatedJob);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Job>> DeleteJob(int id)
        {
            var deletedJob = await _jobServices.DeleteJob(id);
            return Ok(deletedJob);
        }
    }
}
