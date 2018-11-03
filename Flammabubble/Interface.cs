using LiteDB;
using System.Windows.Forms;

namespace Flammabubble {
    // Base record class
    // basically means that each record has ATLEAST an ID property
    public class Record {
        public int ID { get; set; } // Use 0 so LiteDB will use their AutoId system to assign an ID
        // TODO: Somehow this ID is not auto incremented, see: https://github.com/mbdavid/LiteDB/issues/796
    }

    // Base interface class
    // also defines what an Interface class ATLEAST has
    // also used to remove some "technical" stuff out of the other Interface classes
    public class Interface {
        protected InterfaceBuilder interfaceBuilder;
        protected string collectionName = "default"; // Name of the collection in the DB

        public string COLLECTION_NAME { get { return this.collectionName; } }

        public Interface(Panel parentControl) {
            this.interfaceBuilder = new InterfaceBuilder(parentControl);
        }

        public virtual void CreateInterface() { }
        public virtual void SaveToDB() { }
    }
}
