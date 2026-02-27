using Backend_Test_DynamoDB.DTO.Profile;
using Backend_Test_DynamoDB.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Backend_Test_DynamoDB.Controllers.PlayerProfile
{
    [Route("api/playerProfiles")]
    [ApiController]
    [Authorize]
    public class PlayerProfilesController : ControllerBase
    {
        private IPlayerProfileService _service;

        public PlayerProfilesController(IPlayerProfileService service)
        {
            _service = service;
        }

        [HttpPut("updatePlayerName")]
        public async Task<IActionResult> UpdatePlayerName(UpdatePlayerNameRequest request)
        {
            if (string.IsNullOrEmpty(request.PlayerId))
            {
                string error = "Player id is empty";
                Console.WriteLine(error);
                return BadRequest(error);
            }
            if (string.IsNullOrEmpty(request.PlayerName))
            {
                string error = "Player name is empty";
                Console.WriteLine(error);
                return BadRequest(error);
            }

            bool success = await _service.TryUpdatePlayerName(request.PlayerId, request.PlayerName);
            if (success)
            {
                return Ok("Update success");
            }
            return BadRequest();
        }

        [HttpGet("getPlayerName")]
        public async Task<IActionResult> GetPlayerName(string playerId)
        {
            string name = await _service.GetPlayerName(playerId);
            
            if (name == null)
            {
                return BadRequest();
            }

            GetPlayerNameResponse response = new GetPlayerNameResponse { PlayerName = name };
            return Ok(response);
        }
    }
}
