using System.Windows.Forms;

namespace Flammabubble {
    // Base record class
    // basically means that each record has ATLEAST an ID property
    public class Record {
        public int ID { get; set; }
    }

    // Base interface class
    // also defines what an Interface class ATLEAST has
    // also used to remove some "technical" stuff out of the other Interface classes
    public class Interface {
        protected InterfaceBuilder interfaceBuilder;
        protected Database database;
        protected string collectionName = "default"; // Name of the collection in the DB

        public string COLLECTION_NAME { get { return this.collectionName; } }

        public Interface(Panel parentControl, Database database) {
            this.interfaceBuilder = new InterfaceBuilder(parentControl);
            this.database = database;
        }

        public virtual void CreateInterface() { }
        public virtual void SaveToDB() { }
    }
}
