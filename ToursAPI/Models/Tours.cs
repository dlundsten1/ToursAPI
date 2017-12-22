using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ToursAPI.Models
{
    public class Tours
    {
        public ObjectId _id { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public int difficulty { get; set; }
        public string comments { get; set; }
        public string grade { get; set; }
        public string snowconditions { get; set; }
        public Position position { get; set; }
    }


    
    public class Position
    {
        [BsonRepresentation(BsonType.Int32, AllowTruncation = true)]
        public double x { get; set; }
        [BsonRepresentation(BsonType.Int32, AllowTruncation = true)]
        public double y { get; set; }
    }
}