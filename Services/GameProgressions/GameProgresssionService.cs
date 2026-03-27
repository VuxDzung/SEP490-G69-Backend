using Backend_Test_DynamoDB.DTO.GameProgressions;
using Backend_Test_DynamoDB.Models;
using Backend_Test_DynamoDB.Repositories.GameSessions;
using Backend_Test_DynamoDB.Repositories.Player;
using Backend_Test_DynamoDB.Utils;
using System.Linq;

namespace Backend_Test_DynamoDB.Services.GameProgressions
{
    public class GameProgresssionService : IGameProgressionsService
    {
        private readonly IPlayerRepository _playerRepo;
        private readonly ISessionRepository _sessionRepo;

        public GameProgresssionService(IPlayerRepository playerRepo, 
                                       ISessionRepository sessionRepo)
        {
            _playerRepo = playerRepo;
            _sessionRepo = sessionRepo;
        }

        public async Task<GetPlayerMetadataResponse> GetMetadata(string playerId, string sessionId)
        {
            GetPlayerMetadataResponse response = new GetPlayerMetadataResponse();

            PlayerData playerData = await _playerRepo.GetAsync(playerId);

            if (playerData == null)
            {
                response.Success = false;
                response.MetadataResult = EMetadataResult.NoProfile;

                return response;
            }

            List<PlayerGameSession> sessions = await _sessionRepo.GetAllAsync(playerId);
            PlayerGameSession? sessionData = sessions.FirstOrDefault();

            if (sessionData == null)
            {
                Console.WriteLine("[GameProgresssionService.GetMetadata] HasProfileNoSession");
                response.Success = true;
                response.PlayerId = playerData.PlayerId;
                response.PlayerName = playerData.PlayerName;
                response.CurrentRun = playerData.CurrentRun;
                response.LastSyncTime = playerData.LastSyncedTime;
                response.MetadataResult = EMetadataResult.HasProfileNoSession;
                return response;
            }

            Console.WriteLine($"[GameProgresssionService.GetMetadata] HasProfileHasSession\nSessionId: {sessionData.SessionId}");

            response.Success = true;
            response.MetadataResult = EMetadataResult.HasProfileHasSession;
            response.PlayerId = playerData.PlayerId;
            response.PlayerName = playerData.PlayerName;
            response.LatestSessionId = sessionData.SessionId;
            response.CurrentRun = playerData.CurrentRun;
            response.LastSyncTime = playerData.LastSyncedTime;

            return response;
        }

        /// <summary>
        /// Get the entire game data of the player with the provided player id and session id.
        /// </summary>
        /// <param name="playerId">The player id which use to indetify which data needs to get</param>
        /// <param name="sessionId">The session id of the provided player id</param>
        /// <returns></returns>
        public async Task<GetPlayerGameDataResponse> GetPlayerGameData(string playerId, string sessionId)
        {
            GetPlayerGameDataResponse response = new GetPlayerGameDataResponse();

            PlayerData playerData = await _playerRepo.GetAsync(playerId);
            if (playerData == null)
            {
                response.Success = false;
                response.ErrorMsg = $"No player account with id {playerId}";
                return response;
            }

            PlayerGameSession sessionData = await _sessionRepo.GetAsync(sessionId);

            if (sessionData == null)
            {
                response.Success = false;
                response.ErrorMsg = $"No session with id {sessionId}";
                return response;
            }

            string sessionCharId = ModelIDCreator.ConstructEntityId(sessionData.SessionId, sessionData.RawCharacterId);

            response.Success = true;
            response.PlayerId = playerData.PlayerId;
            response.PlayerName = playerData.PlayerName;
            response.CurrentRun = playerData.CurrentRun;
            response.LegacyPoints = playerData.LegacyPoints;
            response.LastSyncedTime = playerData.LastSyncedTime;

            response.Session = DTOConverter.ConvertSession2DTO(sessionData);

            response.Character = sessionData.Character;
            response.Exercises = sessionData.Exercises;
            response.ObtainedItems = sessionData.Items;
            response.ShopItems = sessionData.ShopItems;
            response.Cards = sessionData.Cards;
            response.Tournaments = sessionData.Tournaments;
            response.Deck = sessionData.Deck;

            return response;
        }

        /// <summary>
        /// If the current session on client is the same with the backend, insert/update the current session data.
        /// If the current session on client is not the same with the backend, delete the backend data before inserting the new one from client.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<OverrideCloudDataResponse> UnsertGameProgression(UnsertPlayerGameDataRequest request)
        {
            OverrideCloudDataResponse response = new OverrideCloudDataResponse();

            try
            {
                //-----------------------------------------
                // 1. VALIDATE PLAYER
                //-----------------------------------------
                PlayerData playerData = await _playerRepo.GetAsync(request.PlayerData.PlayerId);

                if (playerData == null)
                {
                    response.Success = false;
                    response.ErrorMsg = "Player not found";
                    return response;
                }

                //-----------------------------------------
                // 2. DELETE ALL EXISTING SESSIONS
                //-----------------------------------------
                List<PlayerGameSession> existingSessions = await _sessionRepo.GetAllAsync(playerData.PlayerId);

                if (existingSessions != null)
                {
                    foreach (var session in existingSessions)
                    {
                        await _sessionRepo.DeleteAsync(session);
                    }
                }

                //-----------------------------------------
                // 3. BUILD NEW SESSION (FULL REPLACEMENT)
                //-----------------------------------------
                PlayerGameSession newSession = BuildSessionFromRequest(request);

                //-----------------------------------------
                // 4. SAVE SESSION
                //-----------------------------------------
                await _sessionRepo.SaveAsync(newSession);

                //-----------------------------------------
                // 5. UPDATE PLAYER METADATA
                //-----------------------------------------
                playerData.PlayerName = request.PlayerData.PlayerName;
                playerData.LegacyPoints = request.PlayerData.LegacyPoints;
                playerData.CurrentRun = request.PlayerData.CurrentRun;
                playerData.LastSyncedDevice = request.PlayerData.LastSyncedDevice;
                playerData.LastSyncedTime = request.PlayerData.LastSyncedTime;

                await _playerRepo.SaveAsync(playerData);

                response.Success = true;
                return response;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[GameProgressionService.Upsert exception] {ex.Message}");
                response.Success = false;
                response.ErrorMsg = ex.Message;
                return response;
            }
        }

        public async Task<UpdateLastSyncedTimeResponse> UpdateLastSyncedTime(UpdateLastSyncTimeRequest request)
        {
            UpdateLastSyncedTimeResponse response = new UpdateLastSyncedTimeResponse();

            try
            {

                PlayerData playerData = await _playerRepo.GetAsync(request.PlayerId);

                if (playerData == null)
                {
                    response.Success = false;
                    response.ErrorMsg = $"[GameProgressionService.UpdateLastSyncedTime exception] No player data with id {request.PlayerId} exists in database";

                    return response;
                }

                playerData.LastSyncedTime = request.LastSyncTime;
                playerData.LastSyncedDevice = request.SyncDevice;

                await _playerRepo.SaveAsync(playerData);

                response.Success = true;
                return response;
            }
            catch (System.Exception ex)
            {
                Console.WriteLine($"[GameProgressionService.UpdateLastSyncedTime exception]: {ex.Message}");
                response.Success = false;
                response.ErrorMsg = ex.Message;
                return response;
            }
        }

        private PlayerGameSession BuildSessionFromRequest(UnsertPlayerGameDataRequest request)
        {
            return new PlayerGameSession
            {
                SessionId = request.Session.SessionId,
                PlayerId = request.Session.PlayerId,
                RawCharacterId = request.Session.RawCharacterId,
                CurrentWeek = request.Session.CurrentWeek,
                CurrentGoldAmount = request.Session.CurrentGoldAmount,

                Character = request.Character,
                Cards = request.Cards,
                Exercises = request.Exercises,
                Deck = request.Deck,
                Items = request.ObtainedItems,
                ShopItems = request.ShopItems,
                Tournaments = request.Tournaments
            };
        }
    }
}