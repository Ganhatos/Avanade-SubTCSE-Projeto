using Avanade.SubTCSE.Projeto.Domain.Base.Repository.MongoDB;
using MongoDB.Driver;

namespace Avanade.SubTCSE.Projeto.Data.Repositories.Base.MongoDB
{
    public class MongoDBContext : IMongoDBContext
    {
        private readonly IMongoDatabase _mongoDatabase;

        public MongoDBContext()
        {
            MongoClientSettings mongoClientSettings = MongoClientSettings
                .FromUrl(new MongoUrl("mongodb://mongo-gcds:wazhtcE1CuFWuGkxVKeYwtEdPNFWBwBIEWEgkq9IsIxXB2gf6Q0CZKJSqT1QnTqZKHF3LFnP9QffEQDSM3II6A==@mongo-gcds.mongo.cosmos.azure.com:10255/?ssl=true&retrywrites=false&replicaSet=globaldb&maxIdleTimeMS=120000&appName=@mongo-gcds@"));

            mongoClientSettings.SslSettings = 
                new SslSettings()
                {
                    EnabledSslProtocols = System.Security.Authentication.SslProtocols.Tls12
                };

            MongoClient mongoClient = new MongoClient(settings: mongoClientSettings);

            _mongoDatabase = mongoClient.GetDatabase("fullstack");
        }

        public IMongoCollection<TEntity> GetCollection<TEntity>(string collection)
        {
            return _mongoDatabase.GetCollection<TEntity>(name: collection);
        }
    }
}
