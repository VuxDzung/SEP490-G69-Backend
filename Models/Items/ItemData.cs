using Amazon.DynamoDBv2.DataModel;

namespace Backend_Test_DynamoDB.Models.Items
{
    [DynamoDBTable("Items")]
    public class ItemData
    {
        #region Identifier
        [DynamoDBHashKey("session_item_id")]
        public string SessionItemId { get; set; }
        public string SessionId { get; set; }
        public string RawItemId { get; set; }
        #endregion

        /// <summary>
        /// Stack item amount
        /// </summary>
        public int RemainAmount { get; set; }
    }
}
