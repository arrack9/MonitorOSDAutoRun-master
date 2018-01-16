namespace MonitorOSDAutoRun
{
    partial class Form_OSDRUN
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
            if(disposing && (components != null)) {
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
        	this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
        	this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
        	this.switchDisplaysToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.MsgBox = new System.Windows.Forms.TextBox();
        	this.RunTime = new System.Windows.Forms.Timer(this.components);
        	this.Btn_ShowMenu = new System.Windows.Forms.Button();
        	this.Btn_SaveTextFile = new System.Windows.Forms.Button();
        	this.Btn_Read = new System.Windows.Forms.Button();
        	this.ReadDataTime = new System.Windows.Forms.Timer(this.components);
        	this.contextMenuStrip1.SuspendLayout();
        	this.SuspendLayout();
        	// 
        	// contextMenuStrip1
        	// 
        	this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.switchDisplaysToolStripMenuItem,
			this.exitToolStripMenuItem});
        	this.contextMenuStrip1.Name = "contextMenuStrip1";
        	this.contextMenuStrip1.Size = new System.Drawing.Size(69, 48);
        	// 
        	// switchDisplaysToolStripMenuItem
        	// 
        	this.switchDisplaysToolStripMenuItem.Name = "switchDisplaysToolStripMenuItem";
        	this.switchDisplaysToolStripMenuItem.Size = new System.Drawing.Size(68, 22);
        	// 
        	// exitToolStripMenuItem
        	// 
        	this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
        	this.exitToolStripMenuItem.Size = new System.Drawing.Size(68, 22);
        	// 
        	// MsgBox
        	// 
        	this.MsgBox.Location = new System.Drawing.Point(3, 56);
        	this.MsgBox.Multiline = true;
        	this.MsgBox.Name = "MsgBox";
        	this.MsgBox.Size = new System.Drawing.Size(307, 238);
        	this.MsgBox.TabIndex = 2;
        	// 
        	// RunTime
        	// 
        	this.RunTime.Interval = 3000;
        	// 
        	// Btn_ShowMenu
        	// 
        	this.Btn_ShowMenu.Location = new System.Drawing.Point(3, 12);
        	this.Btn_ShowMenu.Name = "Btn_ShowMenu";
        	this.Btn_ShowMenu.Size = new System.Drawing.Size(96, 42);
        	this.Btn_ShowMenu.TabIndex = 3;
        	this.Btn_ShowMenu.Text = "Show Menu";
        	this.Btn_ShowMenu.UseVisualStyleBackColor = true;
        	this.Btn_ShowMenu.Click += new System.EventHandler(this.Btn_ShowMenu_Click);
        	// 
        	// Btn_SaveTextFile
        	// 
        	this.Btn_SaveTextFile.Location = new System.Drawing.Point(235, 296);
        	this.Btn_SaveTextFile.Name = "Btn_SaveTextFile";
        	this.Btn_SaveTextFile.Size = new System.Drawing.Size(75, 23);
        	this.Btn_SaveTextFile.TabIndex = 15;
        	this.Btn_SaveTextFile.Text = "Save As";
        	this.Btn_SaveTextFile.UseVisualStyleBackColor = true;
        	this.Btn_SaveTextFile.Click += new System.EventHandler(this.Btn_SaveTextFile_Click);
        	// 
        	// Btn_Read
        	// 
        	this.Btn_Read.Location = new System.Drawing.Point(183, 12);
        	this.Btn_Read.Name = "Btn_Read";
        	this.Btn_Read.Size = new System.Drawing.Size(96, 42);
        	this.Btn_Read.TabIndex = 16;
        	this.Btn_Read.Text = "Read Command";
        	this.Btn_Read.UseVisualStyleBackColor = true;
        	this.Btn_Read.Click += new System.EventHandler(this.Btn_ReadClick);
        	// 
        	// ReadDataTime
        	// 
        	this.ReadDataTime.Interval = 8000;
        	// 
        	// Form_OSDRUN
        	// 
        	this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
        	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        	this.ClientSize = new System.Drawing.Size(312, 319);
        	this.Controls.Add(this.Btn_Read);
        	this.Controls.Add(this.Btn_SaveTextFile);
        	this.Controls.Add(this.Btn_ShowMenu);
        	this.Controls.Add(this.MsgBox);
        	this.Name = "Form_OSDRUN";
        	this.Text = "Form_OSDRUN";
        	this.contextMenuStrip1.ResumeLayout(false);
        	this.ResumeLayout(false);
        	this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem switchDisplaysToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.TextBox MsgBox;
        private System.Windows.Forms.Timer RunTime;
        private System.Windows.Forms.Button Btn_ShowMenu;
        private System.Windows.Forms.Button Btn_SaveTextFile;
        private System.Windows.Forms.Button Btn_Read;
        private System.Windows.Forms.Timer ReadDataTime;
    }
}

