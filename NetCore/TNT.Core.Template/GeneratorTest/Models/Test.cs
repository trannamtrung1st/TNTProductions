using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace GeneratorTest.Models
{
    public partial class Test
    {
        [BsonId]
        public string Id { get; set; }
        public string Name { get; set; }
    }
}
