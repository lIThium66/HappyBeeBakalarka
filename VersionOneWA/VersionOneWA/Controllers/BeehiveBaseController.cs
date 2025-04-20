using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using VersionOneWA.Shared.Classes;
using VersionOneWA.Shared.Services;

namespace VersionOneWA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BeehiveBaseController : ControllerBase
    {
        private readonly IBeehiveBaseService _service;

        public BeehiveBaseController(IBeehiveBaseService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<BeehiveBase>>> GetAll() =>
            Ok(await _service.GetAllBases());

        [HttpGet("{id}")]
        public async Task<ActionResult<BeehiveBase>> GetById(int id)
        {
            var result = await _service.GetBaseById(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<BeehiveBase>> EditBase(int id, BeehiveBase bBase) =>
            Ok(await _service.EditBase(id, bBase));


        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteBase(int id) =>
            Ok(await _service.DeleteBase(id));


        [HttpPost("{baseId}/users/{userId}")]
        public async Task<ActionResult<BeehiveBase>> AddUserToBase(int baseId, string userId) =>
            Ok(await _service.AddUserToBase(baseId, userId));


        [HttpDelete("{baseId}/users/{userId}")]
        public async Task<ActionResult<BeehiveBase>> RemoveUserFromBase(int baseId, string userId) =>
            Ok(await _service.DeleteUserFromBase(baseId, userId));


        [HttpGet("user/{userId}")]
        public async Task<ActionResult<List<Job>>> GetUserJobs(string userId)
        {
            var bases = await _service.GetUserBases(userId);
            return Ok(bases);
        }
    }

}
