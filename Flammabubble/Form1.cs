using LiteDB;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace Flammabubble {
    public partial class formMain : Form {
        private ModeManager modeManager; // Decides which view to show
        private List<Interface> interfaces = new List<Interface>(); // Keeps track on which kind of interfaces are created

        // Constructor
        public formMain() {
            InitializeComponent();

            // Initialize all the 'helpers'
            this.modeManager = new ModeManager(this.layoutInsert, this.layoutRetrieve, () => { UpdateRetrieveView(); });
        }

        // Updates the retrieve view
        // it gets all the records from the DB and displays them as a list
        private void UpdateRetrieveView() {
            // Create complete interface for retrieve mode
            // this interface is fixed, so it is not created with the InterfaceBuilder
            ListBox records = this.listRecords;
            records.Items.Clear();
            records.Enabled = true;

            // Add all records from the DB to this list
            this.interfaces.ForEach(_interface => { // I'm using a 'underscore' here because the variable 'interface' already exists, and this way i have kind of the same name
                foreach (Record record in Database.GetRecords(_interface.COLLECTION_NAME).FindAll()) {
                    this.listRecords.Items.Add(new ListItemRecord {
                        text = record.ID.ToString(), // Use the ID for the displayed text
                        value = new ListItemRecordValue{ record = record, collectionName = _interface.COLLECTION_NAME } // Bind the record object to the list item as a value
                    });
                }
            });

            // If we have found no items, show some feedback
            if (records.Items.Count == 0) {
                records.Items.Add(new ListItemRecord { text = "nothing found...", value = null });
                records.Enabled = false;
            }

            // Clear the text on the info text box
            this.textRecordInfo.Text = "";
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
            InterfaceBasic basic = new InterfaceBasic(this.layoutInsert);
            basic.CreateInterface();
            this.interfaces.Add(basic);

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
            Record record = (this.listRecords.SelectedItem as ListItemRecord).value.record; // Get the record that was binded to the list item's value

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

        // Called when you click on the listRecords context menu item "Delete" 
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e) {
            // Delete selected record from Database
            foreach (ListItemRecord listItem in this.listRecords.SelectedItems) {
                Database.DeleteRecord(listItem.value.collectionName, listItem.value.record);
            }

            this.UpdateRetrieveView();
        }
    }
}
