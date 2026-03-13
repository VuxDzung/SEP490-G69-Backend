using Amazon.DynamoDBv2.DataModel;

namespace Backend_Test_DynamoDB.Models.Items
{
    [DynamoDBTable("ShopItems")]
    public class ShopItemData
    {
        #region Identifiers
        [DynamoDBHashKey("session_item_id")]
        public string SessionItemId { get; set; }
        public string SessionId { get; set; }
        public string RawItemId { get; set; }
        #endregion

        public int RemainAmount { get; set; }
    }
}
