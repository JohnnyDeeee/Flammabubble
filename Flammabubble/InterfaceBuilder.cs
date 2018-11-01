using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Flammabubble {
    // This class helps you build custom 'insert' (mode) interfaces
    public class InterfaceBuilder {
        private List<Row> rows = new List<Row>(); // Keeps track of all the rows in the current 'build'
        private Panel parent; // All 'rows' will be added to this parent panel

        // Constructor
        public InterfaceBuilder(Panel parent) {
            this.parent = parent;
        }

        // Adds a row to the rows list
        // a row consists of a label + an input
        // label: Text that is displayed in front of the input
        // inputType: Type of input to display
        // items: If you use a Dropdown as inputType, you can define your items here
        // value: Used for setting the text for ReadOnly input and Button input
        // onClick: Action that is invoked everytime you click on the Button
        // propertySetter: Action that is invoked everytime the value of the input is changed, it passes along the newValue
        public void AddRow(string label, InputType inputType, ListItem[] items = null, string value = null, Action onClick = null, Action<object> propertySetter = null) {
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
                    (input as TextBox).TextChanged += (s, a) => { propertySetter((s as TextBox).Text); };
                    break;
                case InputType.Dropdown:
                    input = new ComboBox();
                    (input as ComboBox).Items.AddRange(items);
                    (input as ComboBox).SelectedIndex = 0;
                    (input as ComboBox).SelectedIndexChanged += (s, a) => { propertySetter((s as ComboBox).SelectedIndex); };
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

            // Create a new Row object, this is mainly to keep things easier to access
            Row newRow = new Row {
                label = label,
                input = input
            };

            // Add the new row object to the rows list
            rows.Add(newRow);
        }

        // This function will add all rows to the parent control, so they can be displayed on the screen
        public void Build(Interface interfaceObject) {
            // Loop through all rows in the rows list
            rows.ForEach(row => {
                // Create a flow layout panel to keep the label + input organized
                FlowLayoutPanel panel = new FlowLayoutPanel();
                panel.AutoSize = true;
                panel.FlowDirection = FlowDirection.LeftToRight;

                // Add that panel to the parent panel
                parent.Controls.Add(panel);

                // If we have label text, create a label control
                if (row.label.Length > 0) {
                    Label label = new Label();
                    label.Text = row.label;

                    // Add the label control to the flow layout panel
                    panel.Controls.Add(label);
                }

                // Add the input to the flow layout panel
                panel.Controls.Add(row.input);
            });
        }
    }

    // Row object that is used for defining label + input groups
    public class Row {
        public string label { get; set; }
        public Control input { get; set; }
    }

    // ListItem object is used for creating items which are shown in lists input
    public class ListItem {
        public object value { get; set; }
        public string text { get; set; }

        public override string ToString() {
            return text;
        }
    }

    // Types of inputs you can choose from
    // keeping this limited so it is simpler to use it
    public enum InputType { Text = 0, Dropdown = 1, ReadOnly = 2, Button = 3 }
}
