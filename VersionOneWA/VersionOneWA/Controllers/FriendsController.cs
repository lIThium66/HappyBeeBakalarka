using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using VersionOneWA.Shared.Classes;
using VersionOneWA.Shared.Services;

namespace VersionOneWA.Controllers
{
    [Route("api/friends")]
    [ApiController]
    public class FriendController : ControllerBase
    {
        private readonly IFriendService _friendService;
        private readonly UserManager<ApplicationUser> _userManager;

        public FriendController(IFriendService friendService, UserManager<ApplicationUser> userManager)
        {
            _friendService = friendService;
            _userManager = userManager;
        }

        [HttpPost("send/{receiverId}")]
        public async Task<IActionResult> SendFriendRequest(string receiverId)
        {
            var senderId = _userManager.GetUserId(User);
            if(senderId == null) return Unauthorized();
            if (await _friendService.SendFriendRequestAsync(senderId, receiverId))
                return Ok();
            return BadRequest("Žiadosť už existuje alebo sa vyskytla chyba.");
        }

        [HttpPost("accept/{requestId}")]
        public async Task<IActionResult> AcceptFriendRequest(int requestId)
        {
            var success = await _friendService.AcceptFriendRequestAsync(requestId);
            return success ? Ok() : BadRequest("Request not found.");
        }

        [HttpPost("reject/{requestId}")]
        public async Task<IActionResult> RejectFriendRequest(int requestId)
        {
            var success = await _friendService.RejectFriendRequestAsync(requestId);
            return success ? Ok() : BadRequest("Request not found.");
        }

        [HttpGet("list")]
        public async Task<IActionResult> GetFriends()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null) return Unauthorized();

            var friends = await _friendService.GetFriendsAsync(user.Id);
            return Ok(friends);
        }

        [HttpGet("pending")]
        public async Task<IActionResult> GetPendingRequests()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null) return Unauthorized();

            var requests = await _friendService.GetPendingRequestsAsync(user.Id);
            return Ok(requests);
        }
        [HttpGet("requests")]
        public async Task<IActionResult> GetFriendRequests()
        {
            var userId = _userManager.GetUserId(User);
            if (userId == null)
                return Unauthorized();

            var requests = await _friendService.GetFriendRequestsAsync(userId);
            return Ok(requests);
        }
    }
}
