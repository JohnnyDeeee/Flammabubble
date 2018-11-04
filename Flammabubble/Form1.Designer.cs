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
            this.components = new System.ComponentModel.Container();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.insertToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.retrieveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listRecords = new System.Windows.Forms.ListBox();
            this.textRecordInfo = new System.Windows.Forms.RichTextBox();
            this.layoutInsert = new System.Windows.Forms.FlowLayoutPanel();
            this.panelTextRecordInfo = new System.Windows.Forms.Panel();
            this.panelListRecords = new System.Windows.Forms.Panel();
            this.layoutRetrieve = new System.Windows.Forms.TableLayoutPanel();
            this.contextListRecordsItem = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip.SuspendLayout();
            this.panelTextRecordInfo.SuspendLayout();
            this.panelListRecords.SuspendLayout();
            this.layoutRetrieve.SuspendLayout();
            this.contextListRecordsItem.SuspendLayout();
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
            this.listRecords.ContextMenuStrip = this.contextListRecordsItem;
            this.listRecords.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listRecords.FormattingEnabled = true;
            this.listRecords.Location = new System.Drawing.Point(0, 0);
            this.listRecords.Margin = new System.Windows.Forms.Padding(0);
            this.listRecords.Name = "listRecords";
            this.listRecords.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listRecords.Size = new System.Drawing.Size(85, 192);
            this.listRecords.TabIndex = 0;
            this.listRecords.SelectedIndexChanged += new System.EventHandler(this.listRecords_SelectedIndexChanged);
            // 
            // textRecordInfo
            // 
            this.textRecordInfo.BackColor = System.Drawing.Color.White;
            this.textRecordInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textRecordInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textRecordInfo.Location = new System.Drawing.Point(0, 0);
            this.textRecordInfo.Margin = new System.Windows.Forms.Padding(0);
            this.textRecordInfo.Name = "textRecordInfo";
            this.textRecordInfo.ReadOnly = true;
            this.textRecordInfo.Size = new System.Drawing.Size(322, 192);
            this.textRecordInfo.TabIndex = 1;
            this.textRecordInfo.Text = "";
            // 
            // layoutInsert
            // 
            this.layoutInsert.AutoScroll = true;
            this.layoutInsert.AutoSize = true;
            this.layoutInsert.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutInsert.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.layoutInsert.Location = new System.Drawing.Point(0, 24);
            this.layoutInsert.Name = "layoutInsert";
            this.layoutInsert.Size = new System.Drawing.Size(425, 204);
            this.layoutInsert.TabIndex = 4;
            // 
            // panelTextRecordInfo
            // 
            this.panelTextRecordInfo.AutoSize = true;
            this.panelTextRecordInfo.Controls.Add(this.textRecordInfo);
            this.panelTextRecordInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTextRecordInfo.Location = new System.Drawing.Point(97, 6);
            this.panelTextRecordInfo.Margin = new System.Windows.Forms.Padding(0, 6, 6, 6);
            this.panelTextRecordInfo.Name = "panelTextRecordInfo";
            this.panelTextRecordInfo.Size = new System.Drawing.Size(322, 192);
            this.panelTextRecordInfo.TabIndex = 2;
            // 
            // panelListRecords
            // 
            this.panelListRecords.AutoSize = true;
            this.panelListRecords.Controls.Add(this.listRecords);
            this.panelListRecords.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelListRecords.Location = new System.Drawing.Point(6, 6);
            this.panelListRecords.Margin = new System.Windows.Forms.Padding(6);
            this.panelListRecords.Name = "panelListRecords";
            this.panelListRecords.Size = new System.Drawing.Size(85, 192);
            this.panelListRecords.TabIndex = 3;
            // 
            // layoutRetrieve
            // 
            this.layoutRetrieve.ColumnCount = 2;
            this.layoutRetrieve.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.82353F));
            this.layoutRetrieve.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 77.17647F));
            this.layoutRetrieve.Controls.Add(this.panelTextRecordInfo, 0, 0);
            this.layoutRetrieve.Controls.Add(this.panelListRecords, 0, 0);
            this.layoutRetrieve.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutRetrieve.Location = new System.Drawing.Point(0, 24);
            this.layoutRetrieve.Name = "layoutRetrieve";
            this.layoutRetrieve.RowCount = 1;
            this.layoutRetrieve.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.layoutRetrieve.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.layoutRetrieve.Size = new System.Drawing.Size(425, 204);
            this.layoutRetrieve.TabIndex = 1;
            // 
            // contextListRecordsItem
            // 
            this.contextListRecordsItem.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteToolStripMenuItem});
            this.contextListRecordsItem.Name = "contextListRecordsItem";
            this.contextListRecordsItem.Size = new System.Drawing.Size(108, 26);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // formMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(425, 228);
            this.Controls.Add(this.layoutRetrieve);
            this.Controls.Add(this.layoutInsert);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.MaximizeBox = false;
            this.Name = "formMain";
            this.ShowIcon = false;
            this.Text = "Flammabubble";
            this.Load += new System.EventHandler(this.formMain_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.panelTextRecordInfo.ResumeLayout(false);
            this.panelListRecords.ResumeLayout(false);
            this.layoutRetrieve.ResumeLayout(false);
            this.layoutRetrieve.PerformLayout();
            this.contextListRecordsItem.ResumeLayout(false);
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
        private System.Windows.Forms.FlowLayoutPanel layoutInsert;
        private System.Windows.Forms.Panel panelListRecords;
        private System.Windows.Forms.Panel panelTextRecordInfo;
        private System.Windows.Forms.TableLayoutPanel layoutRetrieve;
        private System.Windows.Forms.ContextMenuStrip contextListRecordsItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
    }
}

