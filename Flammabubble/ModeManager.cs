using System;
using System.Windows.Forms;

namespace Flammabubble {
    // Helper that makes sure the right 'view' is visible
    public class ModeManager {
        private Control viewInsert; // The insert 'view' (or 'page')
        private Control viewRetrieve; // The retrieve 'view' (or 'page')
        private Action callback; // Callback that is called whenever the 'view mode' changes
        private Modes _currentMode; // Keeps track of the current mode we are in
        public Modes currentMode { get { return this._currentMode; } set { this._currentMode = value; this.RefreshPanel(); } }

        // Constructor
        public ModeManager(Control viewInsert, Control viewRetrieve, Action callback) {
            this.viewInsert = viewInsert;
            this.viewRetrieve = viewRetrieve;
            this.callback = callback;
        }

        // Called whenever we change the mode
        // shows/hides the right controls
        private void RefreshPanel() {
            this.viewInsert.Visible = this.currentMode == Modes.Insert;
            this.viewRetrieve.Visible = this.currentMode == Modes.Retrieve;

            this.callback();
        }
    }

    // Different modes that are available
    public enum Modes { Insert = 0, Retrieve = 1 }
}
