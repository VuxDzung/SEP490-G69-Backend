namespace Backend_Test_DynamoDB.Database
{
    using Amazon.DynamoDBv2;
    using Amazon.DynamoDBv2.Model;

    public class DynamoDbTableInitializer
    {
        private readonly IAmazonDynamoDB _dynamoDb;

        public DynamoDbTableInitializer(IAmazonDynamoDB dynamoDb)
        {
            _dynamoDb = dynamoDb;
        }

        public async Task InitializeAsync()
        {
            await EnsurePlayerDataTable();
            //await EnsureSessionCheckpointSnapshotTable();
            //await EnsurePlayerCharacterDataTable();
            //await EnsurePlayerItemTable();
            //await EnsurePlayerCardTable();
        }

        #region === Tables ===

        private async Task EnsurePlayerDataTable()
        {
            await EnsureTableAsync(
                tableName: "PlayerData",
                hashKey: ("player_id", ScalarAttributeType.S)
            );
        }

        private async Task EnsureSessionCheckpointSnapshotTable()
        {
            await EnsureTableAsync(
                tableName: "SessionCheckpointSnapshot",
                hashKey: ("session_id", ScalarAttributeType.S),
                rangeKey: ("snapshot_id", ScalarAttributeType.S)
            );
        }

        private async Task EnsurePlayerCharacterDataTable()
        {
            await EnsureTableAsync(
                tableName: "PlayerCharacterData",
                hashKey: ("session_id", ScalarAttributeType.S),
                rangeKey: ("character_id", ScalarAttributeType.S)
            );
        }

        private async Task EnsurePlayerItemTable()
        {
            await EnsureTableAsync(
                tableName: "PlayerItem",
                hashKey: ("session_id", ScalarAttributeType.S),
                rangeKey: ("item_id", ScalarAttributeType.N)
            );
        }

        private async Task EnsurePlayerCardTable()
        {
            await EnsureTableAsync(
                tableName: "PlayerCard",
                hashKey: ("session_id", ScalarAttributeType.S),
                rangeKey: ("card_id", ScalarAttributeType.S)
            );
        }

        #endregion

        #region === Core ===

        private async Task EnsureTableAsync(string tableName,
            (string Name, ScalarAttributeType Type) hashKey,
            (string Name, ScalarAttributeType Type)? rangeKey = null)
        {
            if (await TableExistsAsync(tableName))
                return;

            var attributeDefinitions = new List<AttributeDefinition>
            {
                new AttributeDefinition(hashKey.Name, hashKey.Type)
            };

            var keySchema = new List<KeySchemaElement>
            {
                new KeySchemaElement(hashKey.Name, KeyType.HASH)
            };

            if (rangeKey.HasValue)
            {
                attributeDefinitions.Add(
                    new AttributeDefinition(rangeKey.Value.Name, rangeKey.Value.Type)
                );

                keySchema.Add(
                    new KeySchemaElement(rangeKey.Value.Name, KeyType.RANGE)
                );
            }

            var request = new CreateTableRequest
            {
                TableName = tableName,
                AttributeDefinitions = attributeDefinitions,
                KeySchema = keySchema,
                BillingMode = BillingMode.PAY_PER_REQUEST
            };

            await _dynamoDb.CreateTableAsync(request);
        }

        private async Task<bool> TableExistsAsync(string tableName)
        {
            try
            {
                await _dynamoDb.DescribeTableAsync(tableName);
                return true;
            }
            catch (ResourceNotFoundException)
            {
                return false;
            }
        }
        #endregion
    }
}