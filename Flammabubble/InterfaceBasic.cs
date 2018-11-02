using System;
using System.Windows.Forms;

namespace Flammabubble {
    // Example of a custom Record
    // this info is saved in the DB
    public class RecordBasic : Record {
        public string championName { get; set; }
        public int gameType { get; set; }
        public int role { get; set; }
        public int kills { get; set; }
        public int gameTime { get; set; }

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
        public InterfaceBasic(Panel parentControl, Database database) : base(parentControl, database) {
            base.collectionName = this.collectionName;
        }

        // Overrides the base's CreateInterface() method
        // Uses the interfaceBuilder to create the actual interface
        // This is where you define what you want to see in your custom interface
        public override void CreateInterface() {
            // Set the record ID to the amount of records in this collection + 1
            this.record.ID = base.database.GetRecords(this.COLLECTION_NAME).Count() + 1;

            // Create a ReadOnly input for the record.ID property
            Row inputID = new Row("ID",
                InputType.ReadOnly,
                value: this.record.ID.ToString());
            base.interfaceBuilder.AddRow(inputID);

            // Create a Text input for the record.championName property
            // the property's value will change according to the Text input's value (due to the onChange)
            Row inputChampionName = new Row("Champion name:",
                InputType.Text,
                onChange: (newValue) => { this.record.championName = (string)newValue; });
            base.interfaceBuilder.AddRow(inputChampionName);

            // Create a Dropdown input for the record.gameType property
            // the property's value will change according to the Dropdown's value (due to the onChange)
            Row inputGameType = new Row("GameType:",
                InputType.Dropdown,
                items: new[] {
                    new ListItem { text = "Ranked", value = 0 },
                    new ListItem { text = "Draft", value = 1 },
                    new ListItem { text = "Blind", value = 2 }
                },
                onChange: (newValue) => { this.record.gameType = (int)newValue; });
            base.interfaceBuilder.AddRow(inputGameType);

            // Create another Dropdown input for the record.role property
            // the property's value will change according to the Dropdown's value (due to the onChange)
            Row inputRole = new Row("Role:",
                InputType.Dropdown,
                items: new[] {
                    new ListItem { text = "Top", value = 0 },
                    new ListItem { text = "Mid", value = 1 },
                    new ListItem { text = "Bot", value = 2 },
                    new ListItem { text = "Jungle", value = 3 }
                },
                onChange: (newValue) => { this.record.role = (int)newValue; });
            base.interfaceBuilder.AddRow(inputRole);

            // Create a ReadOnly input, this one will not save anything to the Database
            // notice that it doesn't have the familiar 'onChange' code
            // you can still add it if you want
            // We define this one above 'inputKills' because inputKills needs this Row variable
            // for setting the text property of this input whenever inputKills changes text
            Row inputKillsPerMinute = new Row("Kills per minute:",
                InputType.ReadOnly,
                value: "0");

            //
            Row inputGameTime = new Row("Game time (minutes):",
                InputType.Text,
                onChange: (newValue) => { this.record.gameTime = this.StringToInt(newValue.ToString()); });

            // Create a Text input for the record.kills property
            // the property's value will change according to the Text input's value (due to the onChange)
            Row inputKills = new Row("Kills:",
                InputType.Text,
                onChange: (newValue) => {
                    string stringValue = newValue.ToString();
                    this.record.kills = this.StringToInt(stringValue);
                    inputKillsPerMinute.input.Text = ((float)this.StringToInt(stringValue) / (float)this.StringToInt(inputGameTime.input.Text)).ToString();
                });

            base.interfaceBuilder.AddRow(inputGameTime);
            base.interfaceBuilder.AddRow(inputKills);
            base.interfaceBuilder.AddRow(inputKillsPerMinute);

            // Create a Button to save the record into the DB
            // we don't need a label for the button so we can use "" or null for the first param
            Row inputButton = new Row("",
                InputType.Button,
                value: "Save",
                onClick: this.SaveToDB);
            base.interfaceBuilder.AddRow(inputButton);

            // Don't forget to actually 'render' everything to the screen
            base.interfaceBuilder.Build(this.collectionName);
        }

        // Function that is called when we hit the 'save' button
        // it sends the record to our collection in the DB
        public override void SaveToDB() {
            base.database.SaveRecord(this.COLLECTION_NAME, this.record);
            MessageBox.Show("Succesfully saved this record to the Database.\nIf you want to see it change the current Mode to 'Retrieve' and look for id: " + this.record.ID, "Success");

            // Rerender this interface
            base.interfaceBuilder.Clear();
            base.interfaceBuilder.Build(this.collectionName);
        }

        // Converts a string into an Int
        // if it fails (let's say _string = 'abcd'), then it returns -1
        private int StringToInt(string _string) {
            int _return = 0;
            bool succes = Int32.TryParse(_string, out _return);
            return succes ? _return : -1;
        }
    }
}
