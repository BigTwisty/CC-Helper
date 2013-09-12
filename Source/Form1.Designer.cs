namespace CC_Helper
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.Source = new System.Windows.Forms.TextBox();
            this.SourceBrowse = new System.Windows.Forms.Button();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.label2 = new System.Windows.Forms.Label();
            this.Destination = new System.Windows.Forms.TextBox();
            this.DestinationBrowse = new System.Windows.Forms.Button();
            this.Files = new System.Windows.Forms.CheckedListBox();
            this.Directories = new System.Windows.Forms.TreeView();
            this.Copy = new System.Windows.Forms.Button();
            this.ExitOnCopy = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.RunOnEntry = new System.Windows.Forms.TextBox();
            this.Cancel = new System.Windows.Forms.Button();
            this.Worlds = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.Comps = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Minecraft = new System.Windows.Forms.TextBox();
            this.Open = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "&Project Directory:";
            // 
            // Source
            // 
            this.Source.Location = new System.Drawing.Point(116, 6);
            this.Source.Name = "Source";
            this.Source.ReadOnly = true;
            this.Source.Size = new System.Drawing.Size(318, 20);
            this.Source.TabIndex = 13;
            this.Source.Enter += new System.EventHandler(this.Source_Enter);
            // 
            // SourceBrowse
            // 
            this.SourceBrowse.Location = new System.Drawing.Point(440, 7);
            this.SourceBrowse.Name = "SourceBrowse";
            this.SourceBrowse.Size = new System.Drawing.Size(33, 19);
            this.SourceBrowse.TabIndex = 10;
            this.SourceBrowse.Text = "...";
            this.SourceBrowse.UseVisualStyleBackColor = true;
            this.SourceBrowse.Click += new System.EventHandler(this.SourceBrowse_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Mi&necraft Directory:";
            // 
            // Destination
            // 
            this.Destination.Location = new System.Drawing.Point(116, 32);
            this.Destination.Name = "Destination";
            this.Destination.ReadOnly = true;
            this.Destination.Size = new System.Drawing.Size(318, 20);
            this.Destination.TabIndex = 14;
            this.Destination.TextChanged += new System.EventHandler(this.Destination_TextChanged);
            this.Destination.Enter += new System.EventHandler(this.Destination_Enter);
            // 
            // DestinationBrowse
            // 
            this.DestinationBrowse.Location = new System.Drawing.Point(440, 32);
            this.DestinationBrowse.Name = "DestinationBrowse";
            this.DestinationBrowse.Size = new System.Drawing.Size(33, 19);
            this.DestinationBrowse.TabIndex = 12;
            this.DestinationBrowse.Text = "...";
            this.DestinationBrowse.UseVisualStyleBackColor = true;
            this.DestinationBrowse.Click += new System.EventHandler(this.DestinationBrowse_Click);
            // 
            // Files
            // 
            this.Files.FormattingEnabled = true;
            this.Files.Location = new System.Drawing.Point(231, 84);
            this.Files.Name = "Files";
            this.Files.Size = new System.Drawing.Size(242, 229);
            this.Files.TabIndex = 1;
            this.Files.SelectedIndexChanged += new System.EventHandler(this.Files_SelectedIndexChanged);
            // 
            // Directories
            // 
            this.Directories.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.Directories.Location = new System.Drawing.Point(5, 139);
            this.Directories.Name = "Directories";
            this.Directories.Size = new System.Drawing.Size(220, 174);
            this.Directories.TabIndex = 0;
            this.Directories.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.Directories_AfterSelect);
            // 
            // Copy
            // 
            this.Copy.Enabled = false;
            this.Copy.Location = new System.Drawing.Point(5, 343);
            this.Copy.Name = "Copy";
            this.Copy.Size = new System.Drawing.Size(381, 42);
            this.Copy.TabIndex = 7;
            this.Copy.Text = "Copy";
            this.Copy.UseVisualStyleBackColor = true;
            this.Copy.Click += new System.EventHandler(this.Copy_Click);
            // 
            // ExitOnCopy
            // 
            this.ExitOnCopy.AutoSize = true;
            this.ExitOnCopy.Location = new System.Drawing.Point(392, 320);
            this.ExitOnCopy.Name = "ExitOnCopy";
            this.ExitOnCopy.Size = new System.Drawing.Size(85, 17);
            this.ExitOnCopy.TabIndex = 4;
            this.ExitOnCopy.Text = "E&xit on Copy";
            this.ExitOnCopy.UseVisualStyleBackColor = true;
            this.ExitOnCopy.CheckedChanged += new System.EventHandler(this.ExitOnCopy_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 321);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "&Run on Entry:";
            // 
            // RunOnEntry
            // 
            this.RunOnEntry.Location = new System.Drawing.Point(83, 318);
            this.RunOnEntry.Name = "RunOnEntry";
            this.RunOnEntry.Size = new System.Drawing.Size(303, 20);
            this.RunOnEntry.TabIndex = 6;
            this.RunOnEntry.TextChanged += new System.EventHandler(this.RunOnEntry_TextChanged);
            // 
            // Cancel
            // 
            this.Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancel.Location = new System.Drawing.Point(392, 343);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(81, 42);
            this.Cancel.TabIndex = 8;
            this.Cancel.Text = "Cancel";
            this.Cancel.UseVisualStyleBackColor = true;
            this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // Worlds
            // 
            this.Worlds.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Worlds.Enabled = false;
            this.Worlds.FormattingEnabled = true;
            this.Worlds.Location = new System.Drawing.Point(83, 58);
            this.Worlds.Name = "Worlds";
            this.Worlds.Size = new System.Drawing.Size(142, 21);
            this.Worlds.Sorted = true;
            this.Worlds.TabIndex = 15;
            this.Worlds.SelectedIndexChanged += new System.EventHandler(this.Worlds_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(39, 61);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "&World:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 88);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "&Computer ID:";
            // 
            // Comps
            // 
            this.Comps.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Comps.Enabled = false;
            this.Comps.FormattingEnabled = true;
            this.Comps.Location = new System.Drawing.Point(83, 85);
            this.Comps.Name = "Comps";
            this.Comps.Size = new System.Drawing.Size(142, 21);
            this.Comps.TabIndex = 18;
            this.Comps.SelectedIndexChanged += new System.EventHandler(this.Comps_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(228, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(127, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "&Minecraft Window Name:";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // Minecraft
            // 
            this.Minecraft.Location = new System.Drawing.Point(361, 58);
            this.Minecraft.Name = "Minecraft";
            this.Minecraft.Size = new System.Drawing.Size(112, 20);
            this.Minecraft.TabIndex = 3;
            this.Minecraft.TextChanged += new System.EventHandler(this.Minecraft_TextChanged);
            // 
            // Open
            // 
            this.Open.Location = new System.Drawing.Point(5, 112);
            this.Open.Name = "Open";
            this.Open.Size = new System.Drawing.Size(220, 21);
            this.Open.TabIndex = 19;
            this.Open.Text = "Open In Explorer";
            this.Open.UseVisualStyleBackColor = true;
            this.Open.Click += new System.EventHandler(this.Open_Click);
            // 
            // Form1
            // 
            this.AcceptButton = this.Copy;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.Cancel;
            this.ClientSize = new System.Drawing.Size(478, 390);
            this.Controls.Add(this.Open);
            this.Controls.Add(this.Comps);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.Worlds);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.RunOnEntry);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ExitOnCopy);
            this.Controls.Add(this.Minecraft);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Copy);
            this.Controls.Add(this.Directories);
            this.Controls.Add(this.Files);
            this.Controls.Add(this.DestinationBrowse);
            this.Controls.Add(this.SourceBrowse);
            this.Controls.Add(this.Destination);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Source);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "CC Helper (v1.0)";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Source;
        private System.Windows.Forms.Button SourceBrowse;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Destination;
        private System.Windows.Forms.Button DestinationBrowse;
        private System.Windows.Forms.CheckedListBox Files;
        private System.Windows.Forms.TreeView Directories;
        private System.Windows.Forms.Button Copy;
        private System.Windows.Forms.CheckBox ExitOnCopy;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox RunOnEntry;
        private System.Windows.Forms.Button Cancel;
        private System.Windows.Forms.ComboBox Worlds;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox Comps;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox Minecraft;
        private System.Windows.Forms.Button Open;
    }
}

