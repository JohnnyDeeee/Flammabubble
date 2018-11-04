using LiteDB;
using System;
using System.Windows.Forms;

namespace Flammabubble {
    // Record is optional
    // only needed if you want to save stuff to the Database
    public class RecordTemplate : Record { }

    // Class declaration is required (the name must be differenr though)
    public class InterfaceTemplate : Interface {
        private string collectionName = "Template"; // Overwrite the base collectionName (optional, only needed if you want to save stuff into a collection other than the default 'default' collection)

        // Constructor
        // name must be the same as the class name
        public InterfaceTemplate(Panel parentControl) : base(parentControl) {
            base.collectionName = this.collectionName;
        }

        public override void CreateInterface() {
            // Put your rows here
            // ...

            // Don't forget to actually 'render' everything to the screen
            base.interfaceBuilder.Build(this.collectionName);
        }
    }
}
