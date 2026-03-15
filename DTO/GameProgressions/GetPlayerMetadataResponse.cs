namespace Backend_Test_DynamoDB.DTO.GameProgressions
{
    public class GetPlayerMetadataResponse
    {
        public bool Success { get; set; }

        #region Success fields
        public string PlayerId { get; set; } = string.Empty;
        public string PlayerName { get; set; } = string.Empty;
        public string LatestSessionId { get; set; } = string.Empty;
        public int CurrentRun { get; set; }
        public DateTime LastSyncTime { get; set; }
        #endregion

        #region Error fields
        public string ErrorMsg { get; set; } = string.Empty;
        #endregion
    }
}