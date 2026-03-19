namespace Backend_Test_DynamoDB.Utils
{
    public class ModelIDCreator
    {
        public const string FORMAT_SESSION_ID = "{0}_{1}";
        public const string FORMAT_ENTITY_ID = "{0}:{1}";

        /// <summary>
        /// Construct a session id which the session belongs to the provided player.
        /// </summary>
        /// <param name="playerId"></param>
        /// <param name="currentRun"></param>
        /// <returns></returns>
        public static string ConstructSessionId(string playerId, int currentRun)
        {
            return string.Format(FORMAT_SESSION_ID, playerId, currentRun.ToString());
        }

        /// <summary>
        /// Construct an entity model id which belongs to the provided session.
        /// </summary>
        /// <param name="sessionId"></param>
        /// <param name="rawEntityId"></param>
        /// <returns></returns>
        public static string ConstructEntityId(string sessionId, string rawEntityId)
        {
            return string.Format(FORMAT_ENTITY_ID, sessionId, rawEntityId);
        }
    }
}
