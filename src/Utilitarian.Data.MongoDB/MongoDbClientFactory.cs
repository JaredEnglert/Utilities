﻿using System.Collections.Concurrent;
using MongoDB.Driver;

namespace Utilitarian.Data.MongoDB
{
    public static class MongoDbClientFactory
    {
        public static ConcurrentDictionary<string, MongoClient> MongoClients;

        static MongoDbClientFactory()
        {
            MongoClients = new ConcurrentDictionary<string, MongoClient>();
        }

        public static MongoClient GetMongoClient(string databaseName, string connectionString)
        {
            MongoClient mongoClient;
            MongoClients.TryGetValue(databaseName, out mongoClient);

            if (mongoClient != null) return mongoClient;

            mongoClient = new MongoClient(connectionString);

            MongoClients.TryAdd(databaseName, mongoClient);

            return mongoClient;
        }
    }
}
