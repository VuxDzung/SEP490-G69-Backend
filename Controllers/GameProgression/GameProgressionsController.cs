using Backend_Test_DynamoDB.DTO.GameProgressions;
using Backend_Test_DynamoDB.Services.GameProgressions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Backend_Test_DynamoDB.Controllers.GameProgression
{
    [Route("api/gameProgression")]
    [ApiController]
    [Authorize]
    public class GameProgressionsController : ControllerBase
    {
        private readonly IGameProgressionsService _service;

        public GameProgressionsController(IGameProgressionsService service)
        {
            _service = service;
        }

        [HttpGet("getPlayerGameData")]
        public IActionResult GetPlayerGameData(string playerId, string sessionId)
        {
            GetPlayerGameDataResponse response = _service.GetPlayerGameData(playerId, sessionId);

            if (response == null)
            {
                return NotFound();
            }
            return Ok(response);
        }

        [HttpGet("getPlayerMetadata")]
        public IActionResult GetPlayerMetadata(string playerId, string sessionId)
        {
            GetPlayerMetadataResponse response = _service.GetMetadata(playerId, sessionId);

            if (response == null)
            {
                response = new GetPlayerMetadataResponse
                {
                    Success = false,
                    ErrorMsg = $"Cannot found the metadata of player {playerId} with session {sessionId}"
                };
            }
            return Ok(response);
        }
    }
}
