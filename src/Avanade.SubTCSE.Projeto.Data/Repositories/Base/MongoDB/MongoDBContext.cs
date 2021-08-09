﻿using Avanade.SubTCSE.Projeto.Domain.Base.Repository.MongoDB;
using MongoDB.Driver;

namespace Avanade.SubTCSE.Projeto.Data.Repositories.Base.MongoDB
{
    public class MongoDBContext : IMongoDBContext
    {
        private readonly IMongoDatabase _mongoDatabase;

        public MongoDBContext()
        {
            MongoClientSettings mongoClientSettings = MongoClientSettings
                .FromUrl(new MongoUrl("mongodb://root:avanade-password@127.0.0.1:27017"));

            mongoClientSettings.SslSettings = 
                new SslSettings()
                {
                    EnabledSslProtocols = System.Security.Authentication.SslProtocols.Tls12
                };

            MongoClient mongoClient = new MongoClient(settings: mongoClientSettings);

            MongoCredential credential = MongoCredential.CreateCredential(
                "root", 
                "fullstack", 
                "avanade-password"
                );

            _mongoDatabase = mongoClient.GetDatabase("fullstack");
        }

        public IMongoCollection<TEntity> GetCollection<TEntity>(string collection)
        {
            return _mongoDatabase.GetCollection<TEntity>(name: collection);
        }
    }
}
