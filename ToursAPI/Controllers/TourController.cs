using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Script.Serialization;
using ToursAPI.Models;

namespace ToursAPI.Controllers
{
    public class TourController : ApiController
    {
        // GET: api/Tour
        public List<Tours> Get()
        {
            List<Tours> Tours = new List<Tours>();
            MongoClient client = new MongoClient("mongodb://localhost:27017");
            var cursor = client.GetDatabase("TourDB").GetCollection<BsonDocument>("Tours").Find(new BsonDocument()).ToCursor();
        
            foreach (var document in cursor.ToEnumerable())
            {
                Tours.Add(BsonSerializer.Deserialize<Tours>(document));
            }
                 
            return Tours;
        }

        // GET: api/Tour/5
        public List<Tours> Get(string id) 
        {
            List<Tours> Tours = new List<Tours>();

            var filter = Builders<BsonDocument>.Filter.Eq("name", id);
            MongoClient client = new MongoClient("mongodb://localhost:27017");
            var collection = client.GetDatabase("TourDB").GetCollection<BsonDocument>("Tours").Find(filter).First();


            Tours.Add(BsonSerializer.Deserialize<Tours>(collection));

            return Tours;
        }

        // POST: api/Tour Detta är inte heller fixat
        public void Post([FromBody]Tours tour)
        {

         
      
            MongoClient client = new MongoClient("mongodb://localhost:27017");
            var collection = client.GetDatabase("TourDB").GetCollection<BsonDocument>("Tours");
            //collection.InsertOne(document);
        }

        // PUT: api/Tour/5 Detta är inte färdigt fixa
        public void Put(int id, string value)
        {
            Tours Tour = new Tours();
            var filter = Builders<BsonDocument>.Filter.Eq("name", id);
            var update = Builders<BsonDocument>.Update.Set("name", value);

            MongoClient client = new MongoClient("mongodb://localhost:27017");
            var collection = client.GetDatabase("TourDB").GetCollection<BsonDocument>("Tours");
            var result = collection.UpdateOne(filter, update);

            Get();
            
        }

        // DELETE: api/Tour/5
        public void Delete(int id)
        {
        }
    }
}
