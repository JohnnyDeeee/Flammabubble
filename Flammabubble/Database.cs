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
        public static BsonValue SaveRecord(string collectionName, Record record) {
            using (var db = new LiteDatabase(Database.dbFilePath)) {
                LiteCollection<Record> collection = db.GetCollection<Record>(collectionName);

                record.ID = collection.Max("_id").AsInt32 + 1; // Internally LiteDB renames the ID field to _id
                return collection.Insert(record);
            }
        }

        // Gets all records from a collection from the DB
        public static LiteCollection<Record> GetRecords(string collectionName) {
            using (var db = new LiteDatabase(Database.dbFilePath)) {
                LiteCollection<Record> collection = db.GetCollection<Record>(collectionName);
                return collection;
            }
        }

        // Deletes a record from the collection in the DB
        public static void DeleteRecord(string collectionName, Record record) {
            using (var db = new LiteDatabase(Database.dbFilePath)) {
                LiteCollection<Record> collection = db.GetCollection<Record>(collectionName);
                collection.Delete(x => x.ID == record.ID);
            }
        }
    }
}
