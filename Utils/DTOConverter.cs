using Backend_Test_DynamoDB.DTO.GameProgressions;
using Backend_Test_DynamoDB.Models;

namespace Backend_Test_DynamoDB.Utils
{
    public class DTOConverter
    {
        public static SessionDataDTO ConvertSession2DTO(PlayerGameSession sessionModel)
        {
            return new SessionDataDTO
            {
                SessionId = sessionModel.SessionId,
                PlayerId = sessionModel.PlayerId,
                RawCharacterId = sessionModel.RawCharacterId,
                CurrentWeek = sessionModel.CurrentWeek,
                CurrentGoldAmount = sessionModel.CurrentGoldAmount,
                ActiveTournamentId = sessionModel.ActiveTournamentId,
            };
        }

        public static PlayerGameSession ConvertDTO2Session(SessionDataDTO sessionDTO)
        {
            return new PlayerGameSession
            {
                SessionId = sessionDTO.SessionId,
                PlayerId = sessionDTO.PlayerId,
                RawCharacterId = sessionDTO.RawCharacterId,
                CurrentWeek = sessionDTO.CurrentWeek,
                CurrentGoldAmount = sessionDTO.CurrentGoldAmount,
                ActiveTournamentId = sessionDTO.ActiveTournamentId
            };
        }
    }
}
