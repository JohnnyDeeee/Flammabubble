using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Flammabubble {
    // This class helps you build custom 'insert' (mode) interfaces
    public class InterfaceBuilder {
        private List<Row> rows = new List<Row>(); // Keeps track of all the rows in the current 'build'
        private GroupBox group = new GroupBox(); // All rows will be added to this control

        // Constructor
        public InterfaceBuilder(Panel parent) {
            this.group.Visible = false;
            parent.Controls.Add(group);
        }

        // Adds a row to the rows list
        // a row consists of a label + an input
        public void AddRow(Row row) {
            // Add the new row object to the rows list
            rows.Add(row);
        }

        // This function will add all rows to the parent control, so they can be displayed on the screen
        public void Build(string groupName) {
            int padding = 10;

            // Hide the parent control that holds all the interface
            // so you don't see the 1 second change in layout when all the controls are beign added
            this.group.Parent.Visible = false;

            // Add groupBox to the parent to keep interfaces apart from eachother
            this.group.Text = groupName;
            this.group.AutoSize = true;
            this.group.FlatStyle = FlatStyle.Popup;
            this.group.Padding = new Padding(padding, 0, padding, 0);
            this.group.Visible = true;

            // Add flow layout to the groupbox so we can order every row from top to bottom
            FlowLayoutPanel mainPanel = new FlowLayoutPanel();
            mainPanel.AutoSize = true;
            mainPanel.FlowDirection = FlowDirection.TopDown;
            //mainPanel.BackColor = Color.Green; // TEMP
            mainPanel.Margin = new Padding(0);
            group.Controls.Add(mainPanel);
            mainPanel.Location = new Point(((this.group.Width - mainPanel.Width) / 2), Math.Max(15, padding)); // Important: this needs to be AFTER the panel is added to the groupbox

            // Loop through all rows in the rows list
            rows.ForEach(row => {
                // Create a flow layout panel to keep the label + input organized
                FlowLayoutPanel panel = new FlowLayoutPanel();
                panel.AutoSize = true;
                panel.FlowDirection = FlowDirection.LeftToRight;

                // Add that panel to the parent panel
                mainPanel.Controls.Add(panel);

                // If we have label text, create a label control
                if (row.label.Length > 0) {
                    Label label = new Label();
                    label.Text = row.label;
                    label.AutoSize = true;
                    label.Margin = new Padding(0, 4, 0, 0);

                    // Add the label control to the flow layout panel
                    panel.Controls.Add(label);
                }

                // Add the input to the flow layout panel
                panel.Controls.Add(row.input);
            });

            // Don't forget to show the parent control
            this.group.Parent.Visible = true;
        }

        // Removes all controls from the parent so they can be re-initialized
        public void Clear() {
            this.group.Controls.Clear();
            this.rows.Clear();
        }
    }

    // Row object that is used for defining label + input groups
    public class Row {
        public string label { get; set; }
        public Control input { get; set; }

        // label: Text that is displayed in front of the input
        // inputType: Type of input to display
        // items: If you use a Dropdown as inputType, you can define your items here
        // value: Used for setting the text for ReadOnly input and Button input
        // onClick: Action that is invoked everytime you click on the Button
        // onChange: Action that is invoked everytime the value of the input is changed, it passes along the newValue
        public Row(string label, InputType inputType, ListItem[] items = null, string value = null, Action onClick = null, Action<object> onChange = null) {
            // Convert onClick to an EventHandler, because controls use EventHandlers
            // I chose to use the type 'Action' for the param, because it is easier to
            // supply an Action instead of an EventHandler
            EventHandler onClickEventHandler = null;
            if (onClick != null) {
                Action<object, EventArgs> action = (s, e) => { onClick(); };
                EventHandler eventHandler = (s, e) => { action(s, e); };
                onClickEventHandler = eventHandler;
            }

            // Check what kind of input we should create
            Control input = null;
            switch (inputType) {
                case InputType.Text:
                    input = new TextBox();
                    (input as TextBox).TextChanged += (s, a) => { onChange((s as TextBox).Text); };
                    break;
                case InputType.Dropdown:
                    input = new ComboBox();
                    (input as ComboBox).Items.AddRange(items);
                    (input as ComboBox).SelectedIndex = 0;
                    (input as ComboBox).SelectedIndexChanged += (s, a) => { onChange((s as ComboBox).SelectedIndex); };
                    (input as ComboBox).DropDownStyle = ComboBoxStyle.DropDownList;
                    break;
                case InputType.ReadOnly:
                    input = new TextBox();
                    (input as TextBox).ReadOnly = true;
                    (input as TextBox).Text = value != null ? value : throw new System.Exception("Missing 'value' param for ReadOnly inputType");
                    break;
                case InputType.Button:
                    input = new Button();
                    (input as Button).Text = value != null ? value : throw new System.Exception("Missing 'value' param for Button inputType");
                    (input as Button).Click += onClickEventHandler != null ? onClickEventHandler : throw new System.Exception("Missing 'onClick' param for Button inputType");
                    break;
                default:
                    throw new System.Exception("No valid 'inputType' supplied");
            }

            // Set the property values for this Row object
            this.label = label;
            this.input = input;
        }
    }

    // ListItem class is used for creating items which are shown in lists input
    public class ListItem {
        public object value { get; set; }
        public string text { get; set; }

        public override string ToString() {
            return text;
        }
    }

    // ListItemRecord class is used for creating items which are shown in the listRecords in the retrieve view(mode)
    public class ListItemRecord {
        public ListItemRecordValue value { get; set; }
        public string text { get; set; }

        public override string ToString() {
            return text;
        }
    }

    // ListItemRecordValue class is used for the 'value' property of the ListItemRecord class, because 
    // we want to know in which collection a record is stored when we right click on a record in the 'retrieve' view(mode)
    // so we can remove that record from it's collection if the user decides to do so
    public class ListItemRecordValue {
        public Record record { get; set; }
        public string collectionName { get; set; }
    }

    // Types of inputs you can choose from
    // keeping this limited so it is simpler to use it
    public enum InputType { Text = 0, Dropdown = 1, ReadOnly = 2, Button = 3 }
}
