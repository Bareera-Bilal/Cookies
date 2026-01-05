using System;
using System;
using MongoDB.Bson;
using MongoDB.Driver;


namespace P12_WebApi.Services;

public class MongoDbService
{

    private readonly IMongoDatabase _database;    // inheritance 
                                                  // function which takes connection string from config and establishes a connection with mongodb server 

   // ctor
    public MongoDbService(IConfiguration configuration)
    {

        var connectionString = configuration["MongoDB:ConnectionString"];  // importing connection strting 

        var databaseName = configuration["MongoDB:DatabaseName"];     //importing data base name from appsettings

        var client = new MongoClient(connectionString);
        
        var database = client.GetDatabase(databaseName);

        _database = database;

    }


    public IMongoCollection<Cookie> cookie => _database.GetCollection<Cookie>("cookies");

    //public IMongoCollection<abcd> meta => _database.GetCollection<abcd>("Products");



}



