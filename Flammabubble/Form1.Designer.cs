namespace Flammabubble
{
    partial class formMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.insertToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.retrieveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listRecords = new System.Windows.Forms.ListBox();
            this.textRecordInfo = new System.Windows.Forms.RichTextBox();
            this.layoutRetrieve = new System.Windows.Forms.FlowLayoutPanel();
            this.panelListRecords = new System.Windows.Forms.Panel();
            this.panelTextRecordInfo = new System.Windows.Forms.Panel();
            this.layoutInsert = new System.Windows.Forms.FlowLayoutPanel();
            this.menuStrip.SuspendLayout();
            this.layoutRetrieve.SuspendLayout();
            this.panelListRecords.SuspendLayout();
            this.panelTextRecordInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.modeToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(425, 24);
            this.menuStrip.TabIndex = 2;
            this.menuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // modeToolStripMenuItem
            // 
            this.modeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.insertToolStripMenuItem,
            this.retrieveToolStripMenuItem});
            this.modeToolStripMenuItem.Name = "modeToolStripMenuItem";
            this.modeToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.modeToolStripMenuItem.Text = "Mode";
            // 
            // insertToolStripMenuItem
            // 
            this.insertToolStripMenuItem.Name = "insertToolStripMenuItem";
            this.insertToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.insertToolStripMenuItem.Text = "Insert";
            this.insertToolStripMenuItem.Click += new System.EventHandler(this.insertToolStripMenuItem_Click);
            // 
            // retrieveToolStripMenuItem
            // 
            this.retrieveToolStripMenuItem.Name = "retrieveToolStripMenuItem";
            this.retrieveToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.retrieveToolStripMenuItem.Text = "Retrieve";
            this.retrieveToolStripMenuItem.Click += new System.EventHandler(this.retrieveToolStripMenuItem_Click);
            // 
            // listRecords
            // 
            this.listRecords.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listRecords.FormattingEnabled = true;
            this.listRecords.Location = new System.Drawing.Point(0, 0);
            this.listRecords.Name = "listRecords";
            this.listRecords.Size = new System.Drawing.Size(120, 192);
            this.listRecords.TabIndex = 0;
            this.listRecords.SelectedIndexChanged += new System.EventHandler(this.listRecords_SelectedIndexChanged);
            // 
            // textRecordInfo
            // 
            this.textRecordInfo.BackColor = System.Drawing.Color.White;
            this.textRecordInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textRecordInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textRecordInfo.Location = new System.Drawing.Point(0, 0);
            this.textRecordInfo.Name = "textRecordInfo";
            this.textRecordInfo.ReadOnly = true;
            this.textRecordInfo.Size = new System.Drawing.Size(287, 192);
            this.textRecordInfo.TabIndex = 1;
            this.textRecordInfo.Text = "";
            // 
            // layoutRetrieve
            // 
            this.layoutRetrieve.Controls.Add(this.panelListRecords);
            this.layoutRetrieve.Controls.Add(this.panelTextRecordInfo);
            this.layoutRetrieve.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutRetrieve.Location = new System.Drawing.Point(0, 24);
            this.layoutRetrieve.Name = "layoutRetrieve";
            this.layoutRetrieve.Size = new System.Drawing.Size(425, 204);
            this.layoutRetrieve.TabIndex = 2;
            this.layoutRetrieve.Visible = false;
            // 
            // panelListRecords
            // 
            this.panelListRecords.Controls.Add(this.listRecords);
            this.panelListRecords.Location = new System.Drawing.Point(6, 6);
            this.panelListRecords.Margin = new System.Windows.Forms.Padding(6);
            this.panelListRecords.Name = "panelListRecords";
            this.panelListRecords.Size = new System.Drawing.Size(120, 192);
            this.panelListRecords.TabIndex = 3;
            // 
            // panelTextRecordInfo
            // 
            this.panelTextRecordInfo.Controls.Add(this.textRecordInfo);
            this.panelTextRecordInfo.Location = new System.Drawing.Point(132, 6);
            this.panelTextRecordInfo.Margin = new System.Windows.Forms.Padding(0, 6, 6, 6);
            this.panelTextRecordInfo.Name = "panelTextRecordInfo";
            this.panelTextRecordInfo.Size = new System.Drawing.Size(287, 192);
            this.panelTextRecordInfo.TabIndex = 2;
            // 
            // layoutInsert
            // 
            this.layoutInsert.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutInsert.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.layoutInsert.Location = new System.Drawing.Point(0, 24);
            this.layoutInsert.Name = "layoutInsert";
            this.layoutInsert.Size = new System.Drawing.Size(425, 204);
            this.layoutInsert.TabIndex = 4;
            // 
            // formMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(425, 228);
            this.Controls.Add(this.layoutRetrieve);
            this.Controls.Add(this.layoutInsert);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "formMain";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Flammabubble";
            this.Load += new System.EventHandler(this.formMain_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.layoutRetrieve.ResumeLayout(false);
            this.panelListRecords.ResumeLayout(false);
            this.panelTextRecordInfo.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem insertToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem retrieveToolStripMenuItem;
        private System.Windows.Forms.ListBox listRecords;
        private System.Windows.Forms.RichTextBox textRecordInfo;
        private System.Windows.Forms.FlowLayoutPanel layoutRetrieve;
        private System.Windows.Forms.Panel panelListRecords;
        private System.Windows.Forms.Panel panelTextRecordInfo;
        private System.Windows.Forms.FlowLayoutPanel layoutInsert;
    }
}

