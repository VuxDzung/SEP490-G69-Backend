using Backend_Test_DynamoDB.DTO.GameProgressions;
using Backend_Test_DynamoDB.Services.GameProgressions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

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
        public async Task<IActionResult> GetPlayerGameData(string playerId, string sessionId)
        {
            GetPlayerGameDataResponse response = await _service.GetPlayerGameData(playerId, sessionId);

            if (response == null)
            {
                return NotFound();
            }
            return Ok(response);
        }

        [HttpGet("getPlayerMetadata")]
        public async Task<IActionResult> GetPlayerMetadata(string playerId, string sessionId)
        {
            GetPlayerMetadataResponse response = await _service.GetMetadata(playerId, sessionId);

            if (response == null)
            {
                response = new GetPlayerMetadataResponse
                {
                    Success = false,
                    ErrorMsg = $"Cannot found the metadata of player {playerId} with session {sessionId}"
                };
            }

            string json = JsonConvert.SerializeObject(response);

            return Ok(json);
        }

        [HttpGet("fetchCloudData")]
        public async Task<IActionResult> FetchCloudData(string playerId, string sessionId)
        {
            GetPlayerGameDataResponse response = await _service.GetPlayerGameData(playerId, sessionId);

            string json = JsonConvert.SerializeObject(response);  
            
            return Ok(json);
        }

        [HttpPut("overrideCloudData")]
        public async Task<IActionResult> OverrideCloudData([FromBody] UnsertPlayerGameDataRequest request)
        {
            OverrideCloudDataResponse response = await _service.UnsertGameProgression(request);

            string json = JsonConvert.SerializeObject(response);
            return Ok(json);
        }

        [HttpPut("updateLastSyncTime")]
        public async Task<IActionResult> UpdateLastSyncedTime([FromBody] UpdateLastSyncTimeRequest request)
        {
            UpdateLastSyncedTimeResponse response = await _service.UpdateLastSyncedTime(request);
            string json = JsonConvert.SerializeObject(response, Formatting.Indented);
            return Ok(json);
        }
    }
}
