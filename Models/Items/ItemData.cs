using Amazon.DynamoDBv2.DataModel;

namespace Backend_Test_DynamoDB.Models.Items
{
    [DynamoDBTable("Items")]
    public class ItemData
    {
        #region Identifier
        [DynamoDBHashKey("session_item_id")]
        public string SessionItemId { get; set; } = string.Empty;
        public string SessionId { get; set; } = string.Empty;
        public string RawItemId { get; set; } = string.Empty;
        #endregion

        /// <summary>
        /// Stack item amount
        /// </summary>
        public int RemainAmount { get; set; }
    }
}
