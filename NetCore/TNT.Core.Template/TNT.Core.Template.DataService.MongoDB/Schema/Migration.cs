using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace TNT.Core.Template.DataService.MongoDB.Schema
{
    public class Migration
    {
        public MongoClient Client { get; }
        public IMongoDatabase Database { get; }

        public Migration(string connStr, string database)
        {
            Client = new MongoClient(connStr);
            Database = Client.GetDatabase(database);
        }

        public BulkWriteResult AddField(string toCollection, string fieldName, object defaultValue)
        {
            var col = Database.GetCollection<BsonDocument>(toCollection);
            var updateMany = new UpdateManyModel<BsonDocument>(
                Builders<BsonDocument>.Filter.Empty,
                Builders<BsonDocument>.Update.Set(d => d[fieldName], defaultValue));
            var changes = new List<WriteModel<BsonDocument>>();
            changes.Add(updateMany);
            return col.BulkWrite(changes);
        }

        public BulkWriteResult RemoveField(string fromCollection, string fieldName)
        {
            var col = Database.GetCollection<BsonDocument>(fromCollection);
            var updateMany = new UpdateManyModel<BsonDocument>(
                Builders<BsonDocument>.Filter.Empty,
                Builders<BsonDocument>.Update.Unset(d => d[fieldName]));
            var changes = new List<WriteModel<BsonDocument>>();
            changes.Add(updateMany);
            return col.BulkWrite(changes);
        }

        public BulkWriteResult RenameField(string ofCollection, string oldField, string newField)
        {
            var col = Database.GetCollection<BsonDocument>(ofCollection);
            var updateMany = new UpdateManyModel<BsonDocument>(
                Builders<BsonDocument>.Filter.Empty,
                Builders<BsonDocument>.Update.Rename(d => d[oldField], newField));
            var changes = new List<WriteModel<BsonDocument>>();
            changes.Add(updateMany);
            return col.BulkWrite(changes);
        }

    }
}
