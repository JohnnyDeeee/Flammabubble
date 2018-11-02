using LiteDB;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace Flammabubble {
    public partial class formMain : Form {
        private const string DATABASE_FILE_NAME = "database.db"; // Name of the dataabase file

        private ModeManager modeManager; // Decides which view to show
        private Database database; // Provides some functions to save/get records to/from the database
        private List<Interface> interfaces = new List<Interface>(); // Keeps track on which kind of interfaces are created

        // Constructor
        public formMain() {
            InitializeComponent();

            // Initialize all the 'helpers'
            string dbFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, DATABASE_FILE_NAME);
            this.database = new Database(dbFilePath);
            this.modeManager = new ModeManager(this.layoutInsert, this.layoutRetrieve, () => { UpdateRetrieveView(); });
        }

        // Updates the retrieve view
        // it gets all the records from the DB and displays them as a list
        private void UpdateRetrieveView() {
            // Create complete interface for retrieve mode
            // this interface is fixed, so it is not created with the InterfaceBuilder
            ListBox records = this.listRecords;
            records.Items.Clear();

            // Add all records from the DB to this list
            this.interfaces.ForEach(_interface => {
                foreach (Record record in this.database.GetRecords(_interface.COLLECTION_NAME).FindAll()) {
                    this.listRecords.Items.Add(new ListItem {
                        text = record.ID.ToString(), // Use the ID for the displayed text
                        value = record // Bind the record object to the list item as a value
                    });
                }
            });
        }

        // Called when the form is loaded
        private void formMain_Load(object sender, EventArgs e) {
            // Setup the form size
            double percentageOfScreenWidth = 0.7; // The percentage of screen space (width) the form can use
            double percentageOfScreenHeight = 0.9; // The percentage of screen space (height) the form can use
            Form mainForm = (sender as Form);
            Size workingArea = Screen.FromControl(mainForm).WorkingArea.Size;
            Size maxSize = new Size((int)(workingArea.Width * percentageOfScreenWidth), (int)(workingArea.Height * percentageOfScreenHeight));
            mainForm.MaximumSize = maxSize;
            mainForm.Size = maxSize;

            // Create basic interface for insert mode
            // Basic interface is a custom interface and is here as an example
            InterfaceBasic basic = new InterfaceBasic(this.layoutInsert, this.database);
            basic.CreateInterface();
            this.interfaces.Add(basic);

            // TODO: REMOVE THIS
            for (int i = 0; i < 5; i++) {
                (new InterfaceBasic(this.layoutInsert, this.database)).CreateInterface();
            }

            // Setup form position on center of the screen (must be after the interfaces are drawn)
            mainForm.Location = new Point((workingArea.Width / 2) - (mainForm.Width / 2), (workingArea.Height - mainForm.Height) / 2);

            // Show Insert view by default
            this.modeManager.currentMode = Modes.Insert;
        }

        // Called when the "file->exit" toolstrip is clicked
        private void exitToolStripMenuItem_Click(object sender, EventArgs e) {
            Application.Exit();
        }

        // Called when the "mode->insert" toolstrip is clicked
        private void insertToolStripMenuItem_Click(object sender, EventArgs e) {
            this.modeManager.currentMode = Modes.Insert;
        }

        // Called when the "mode->retrieve" toolstrip is clicked
        private void retrieveToolStripMenuItem_Click(object sender, EventArgs e) {
            this.modeManager.currentMode = Modes.Retrieve;
        }

        // Called whenever the selection changes in the retrieve view list
        private void listRecords_SelectedIndexChanged(object sender, EventArgs e) {
            this.textRecordInfo.Text = ""; // Clear the current text on the right
            object record = (this.listRecords.SelectedItem as ListItem).value; // Get the record that was binded to the list item's value

            // Show all its properties + their values in the textbox on the right
            foreach (PropertyInfo property in record.GetType().GetProperties()) {
                object propertyValue = property.GetValue(record);
                if (propertyValue != null && propertyValue.ToString().Length > 0)
                    propertyValue = propertyValue.ToString();
                else
                    propertyValue = "N/A";
                this.textRecordInfo.Text += $"{property.Name}: {propertyValue}\n";
            }
        }
    }
}
