using System;

namespace Flammabubble {
    // Example of a custom Record
    // this info is saved in the DB
    public class RecordBasic : Record {
        public string championName { get; set; }
        public int gameType { get; set; }
        public int role { get; set; }

        //public override string ToString() {
        //    return string.Format("ID: {0}\nchampionName: {1}\ngameType: {2}\nrole: {3}", this.ID, this.championName, this.gameType, this.role);
        //}
    }

    // Example of a custom Interface
    // this interface is used together with the custom Record class: RecordBasic
    // all input fields (except for save button) change the record's values
    // if you hit save, the record will be saved into the DB
    public class InterfaceBasic : Interface {
        private string collectionName = "Basic"; // Overwrite the base collectionName
        public RecordBasic record = new RecordBasic(); // Keep track of the record values

        // Constructor
        public InterfaceBasic(InterfaceBuilder interfaceBuilder, Database database) : base(interfaceBuilder, database) {
            base.collectionName = this.collectionName;
        }

        // Overrides the base's CreateInterface() method
        // Uses the interfaceBuilder to create the actual interface
        // This is where you define what you want to see in your custom interface
        public override void CreateInterface() {
            // Set the record ID to the amount of records in this collection + 1
            this.record.ID = base.database.GetRecords(this.COLLECTION_NAME).Count() + 1;

            // Create a ReadOnly input for the record.ID property
            base.interfaceBuilder.AddRow("ID",
                InputType.ReadOnly,
                value: this.record.ID.ToString()
            );

            // Create a Text input for the record.championName property
            // the property's value will change according to the Text input's value (due to the propertySetter)
            base.interfaceBuilder.AddRow("Champion name:",
                InputType.Text,
                propertySetter: (newValue) => { this.record.championName = (string)newValue; }
            );

            // Create a Dropdown input for the record.gameType property
            // the property's value will change according to the Dropdown's value (due to the propertySetter)
            base.interfaceBuilder.AddRow("GameType:",
                InputType.Dropdown,
                items: new[] {
                    new ListItem { text = "Ranked", value = 0 },
                    new ListItem { text = "Draft", value = 1 },
                    new ListItem { text = "Blind", value = 2 }
                },
                propertySetter: (newValue) => { this.record.gameType = (int)newValue; }
            );

            // Create another Dropdown input for the record.role property
            // the property's value will change according to the Dropdown's value (due to the propertySetter)
            base.interfaceBuilder.AddRow("Role:",
                InputType.Dropdown,
                items: new[] {
                    new ListItem { text = "Top", value = 0 },
                    new ListItem { text = "Mid", value = 1 },
                    new ListItem { text = "Bot", value = 2 },
                    new ListItem { text = "Jungle", value = 3 }
                },
                propertySetter: (newValue) => { this.record.role = (int)newValue; }
            );

            // Create a Button to save the record into the DB
            // we don't need a label for the button so we can use "" or null for the first param
            base.interfaceBuilder.AddRow("",
                InputType.Button,
                value: "Save",
                onClick: this.SaveToDB
            );

            // Don't forget to actually 'render' everything to the screen
            base.interfaceBuilder.Build(this);
        }

        // Function that is called when we hit the 'save' button
        // it sends the record to our collection in the DB
        public override void SaveToDB() {
            base.database.SaveRecord(this.COLLECTION_NAME, this.record);
        }
    }
}
