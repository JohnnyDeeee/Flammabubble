using LiteDB;
using System;
using System.Windows.Forms;

namespace Flammabubble {
    // Base record class
    // basically means that each record has ATLEAST an ID property
    public class Record {
        public int ID { get; set; } // Use 0 so LiteDB will use their AutoId system to assign an ID
        // TODO: Somehow this ID is not auto incremented, see: https://github.com/mbdavid/LiteDB/issues/796
        // Now we just set the ID manually whenever we insert a Record using Database.saveRecord(...);
    }

    // Base interface class
    // also defines what an Interface class ATLEAST has
    // also used to remove some "technical" stuff out of the other Interface classes
    public class Interface {
        protected InterfaceBuilder interfaceBuilder;
        protected string collectionName = "default"; // Name of the collection in the DB

        // Just a public getter for collectionName, so collection name cant be changed outside these classes,
        // but can be retrieved using the getter
        public string COLLECTION_NAME { get { return this.collectionName; } }

        public Interface(Panel parentControl) {
            this.interfaceBuilder = new InterfaceBuilder(parentControl);
        }

        // This will draw the interface
        // Anything put in here will appear in ALL interface because they inherit this class
        public virtual void CreateInterface() { }

        // Redraw the whole interface to reset all the inputs
        protected virtual void Reset() {
            this.interfaceBuilder.Clear();
            this.CreateInterface();
        }

        // Converts a string into an Int
        // if it fails (let's say _string = 'abcd'), then it returns -1
        protected int StringToInt(string _string) {
            int _return = 0;
            bool succes = Int32.TryParse(_string, out _return);
            return succes ? _return : -1;
        }
    }
}
