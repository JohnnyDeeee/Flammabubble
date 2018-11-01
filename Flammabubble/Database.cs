using LiteDB;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace Flammabubble {
    // Helps you with basic database stuff
    public class Database {
        private string dbFilePath; // Path to where the database file is stored

        // Constructor
        public Database(string dbFilePath) {
            this.dbFilePath = dbFilePath;
        }

        // Saves a record to a collection in the DB
        public void SaveRecord(string collectionName, object record) {
            using (var db = new LiteDatabase(this.dbFilePath)) {
                LiteCollection<object> collection = db.GetCollection<object>(collectionName);

                collection.Insert(record);
            }
        }

        // Gets all records from a collection from the DB
        public LiteCollection<object> GetRecords(string collectionName) {
            using (var db = new LiteDatabase(this.dbFilePath)) {
                LiteCollection<object> collection = db.GetCollection<object>(collectionName);
                return collection;
            }
        }
    }
}
