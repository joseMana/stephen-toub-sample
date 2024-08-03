
//namespace MongoDBConsoleApp
//{
//    class Program
//    {
//        static async Task Main(string[] args)
//        {
//            // Replace the following connection string with your MongoDB deployment's connection string.
//            var connectionString = "mongodb://username:password@localhost:27017/testdb?authSource=admin";

//            var client = new MongoClient(connectionString);
//            var database = client.GetDatabase("testdb");
//            var collection = database.GetCollection<BsonDocument>("testcollection");

//            // Create a new document
//            var document = new BsonDocument
//            {
//                { "name", "John Doe" },
//                { "age", 30 },
//                { "profession", "Software Developer" }
//            };

//            // Insert the document into the collection
//            await collection.InsertOneAsync(document);
//            Console.WriteLine("Document inserted.");

//            // Retrieve the document
//            var filter = Builders<BsonDocument>.Filter.Eq("name", "John Doe");
//            var retrievedDocument = await collection.Find(filter).FirstOrDefaultAsync();
//            Console.WriteLine("Document retrieved:");
//            Console.WriteLine(retrievedDocument.ToString());

//            // Update the document
//            var update = Builders<BsonDocument>.Update.Set("age", 31);
//            await collection.UpdateOneAsync(filter, update);
//            Console.WriteLine("Document updated.");

//            // Retrieve the updated document
//            var updatedDocument = await collection.Find(filter).FirstOrDefaultAsync();
//            Console.WriteLine("Updated document:");
//            Console.WriteLine(updatedDocument.ToString());

//            // Delete the document
//            await collection.DeleteOneAsync(filter);
//            Console.WriteLine("Document deleted.");
//        }
//    }
//}
