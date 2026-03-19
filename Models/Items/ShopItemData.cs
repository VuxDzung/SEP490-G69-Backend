using Amazon.DynamoDBv2.DataModel;

namespace Backend_Test_DynamoDB.Models.Items
{
    //[DynamoDBTable("ShopItems")]
    public class ShopItemData
    {
        #region Identifiers
        //[DynamoDBHashKey("session_item_id")]

        public string SessionItemId { get; set; } = string.Empty;
        public string SessionId { get; set; } = string.Empty;
        public string RawItemId { get; set; } = string.Empty;
        #endregion

        public int RemainAmount { get; set; }
    }
}
