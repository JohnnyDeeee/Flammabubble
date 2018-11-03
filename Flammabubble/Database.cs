using LiteDB;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace Flammabubble {
    // Helps you with basic database stuff
    public static class Database {
        private const string DATABASE_FILE_NAME = "database.db"; // Name of the database file
        private static string dbFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, DATABASE_FILE_NAME); // Path to where the database file is stored

        // Saves a record to a collection in the DB and returns the record's ID
        public static BsonValue SaveRecord(string collectionName, object record) {
            using (var db = new LiteDatabase(Database.dbFilePath)) {
                LiteCollection<object> collection = db.GetCollection<object>(collectionName);

                return collection.Insert(record);
            }
        }

        // Gets all records from a collection from the DB
        public static LiteCollection<object> GetRecords(string collectionName) {
            using (var db = new LiteDatabase(Database.dbFilePath)) {
                LiteCollection<object> collection = db.GetCollection<object>(collectionName);
                return collection;
            }
        }
    }
}
