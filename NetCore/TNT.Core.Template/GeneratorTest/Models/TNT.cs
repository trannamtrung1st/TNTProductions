using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace GeneratorTest.Models
{
    public partial class TNT
    {

        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.String)]
        public string Id { get; set; }

        public Books Books { get; set; }

    }
}
