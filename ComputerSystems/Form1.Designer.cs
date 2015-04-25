namespace ComputerSystems
{
    partial class Main
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.play_pause = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.Panel();
            this.Green_Task = new System.Windows.Forms.Label();
            this.Yellow_Task = new System.Windows.Forms.Label();
            this.Red_Task = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.logging = new System.Windows.Forms.RichTextBox();
            this.fileToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.fileToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.currentTime = new System.Windows.Forms.Label();
            this.processors1 = new ComputerSystems.Controls.Processors();
            this.global1 = new ComputerSystems.Controls.Global();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.play_pause)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Transparent;
            this.menuStrip1.Font = new System.Drawing.Font("Lucida Handwriting", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.optionsToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(30, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1200, 29);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.BackColor = System.Drawing.Color.Transparent;
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.loadToolStripMenuItem,
            this.exitToolStripMenuItem1});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(55, 25);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.BackColor = System.Drawing.Color.Transparent;
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(127, 26);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(127, 26);
            this.saveToolStripMenuItem.Text = "Save";
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(127, 26);
            this.loadToolStripMenuItem.Text = "Load";
            // 
            // exitToolStripMenuItem1
            // 
            this.exitToolStripMenuItem1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.exitToolStripMenuItem1.Name = "exitToolStripMenuItem1";
            this.exitToolStripMenuItem1.Size = new System.Drawing.Size(127, 26);
            this.exitToolStripMenuItem1.Text = "Exit";
            this.exitToolStripMenuItem1.Click += new System.EventHandler(this.exitToolStripMenuItem1_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(91, 25);
            this.optionsToolStripMenuItem.Text = "Options";
            this.optionsToolStripMenuItem.Click += new System.EventHandler(this.optionsToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(56, 25);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // play_pause
            // 
            this.play_pause.BackColor = System.Drawing.Color.Transparent;
            this.play_pause.Image = global::ComputerSystems.Properties.Resources.Button_Play;
            this.play_pause.Location = new System.Drawing.Point(61, 516);
            this.play_pause.Name = "play_pause";
            this.play_pause.Size = new System.Drawing.Size(131, 44);
            this.play_pause.TabIndex = 8;
            this.play_pause.TabStop = false;
            this.play_pause.Click += new System.EventHandler(this.play_pause_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.processors1);
            this.panel1.Controls.Add(this.global1);
            this.panel1.Location = new System.Drawing.Point(46, 35);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(240, 580);
            this.panel1.TabIndex = 9;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.Green_Task);
            this.groupBox2.Controls.Add(this.Yellow_Task);
            this.groupBox2.Controls.Add(this.Red_Task);
            this.groupBox2.Location = new System.Drawing.Point(292, 40);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(642, 572);
            this.groupBox2.TabIndex = 10;
            // 
            // Green_Task
            // 
            this.Green_Task.AutoSize = true;
            this.Green_Task.Font = new System.Drawing.Font("Monotype Corsiva", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Green_Task.Location = new System.Drawing.Point(465, 506);
            this.Green_Task.Name = "Green_Task";
            this.Green_Task.Size = new System.Drawing.Size(28, 33);
            this.Green_Task.TabIndex = 0;
            this.Green_Task.Text = "0";
            // 
            // Yellow_Task
            // 
            this.Yellow_Task.AutoSize = true;
            this.Yellow_Task.Font = new System.Drawing.Font("Monotype Corsiva", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Yellow_Task.Location = new System.Drawing.Point(320, 506);
            this.Yellow_Task.Name = "Yellow_Task";
            this.Yellow_Task.Size = new System.Drawing.Size(28, 33);
            this.Yellow_Task.TabIndex = 0;
            this.Yellow_Task.Text = "0";
            // 
            // Red_Task
            // 
            this.Red_Task.AutoSize = true;
            this.Red_Task.Font = new System.Drawing.Font("Monotype Corsiva", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Red_Task.Location = new System.Drawing.Point(169, 506);
            this.Red_Task.Name = "Red_Task";
            this.Red_Task.Size = new System.Drawing.Size(28, 33);
            this.Red_Task.TabIndex = 0;
            this.Red_Task.Text = "0";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Controls.Add(this.logging);
            this.panel2.Controls.Add(this.play_pause);
            this.panel2.Location = new System.Drawing.Point(953, 40);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(235, 572);
            this.panel2.TabIndex = 11;
            // 
            // logging
            // 
            this.logging.AcceptsTab = true;
            this.logging.BackColor = System.Drawing.SystemColors.Info;
            this.logging.Font = new System.Drawing.Font("Courier New", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.logging.ForeColor = System.Drawing.SystemColors.WindowText;
            this.logging.Location = new System.Drawing.Point(32, 8);
            this.logging.Name = "logging";
            this.logging.ReadOnly = true;
            this.logging.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.logging.Size = new System.Drawing.Size(193, 489);
            this.logging.TabIndex = 9;
            this.logging.Text = "";
            // 
            // fileToolStripMenuItem1
            // 
            this.fileToolStripMenuItem1.Name = "fileToolStripMenuItem1";
            this.fileToolStripMenuItem1.Size = new System.Drawing.Size(55, 25);
            this.fileToolStripMenuItem1.Text = "File";
            // 
            // optionsToolStripMenuItem1
            // 
            this.optionsToolStripMenuItem1.Name = "optionsToolStripMenuItem1";
            this.optionsToolStripMenuItem1.Size = new System.Drawing.Size(91, 25);
            this.optionsToolStripMenuItem1.Text = "Options";
            // 
            // exitToolStripMenuItem2
            // 
            this.exitToolStripMenuItem2.Name = "exitToolStripMenuItem2";
            this.exitToolStripMenuItem2.Size = new System.Drawing.Size(56, 25);
            this.exitToolStripMenuItem2.Text = "Exit";
            // 
            // newToolStripMenuItem1
            // 
            this.newToolStripMenuItem1.Name = "newToolStripMenuItem1";
            this.newToolStripMenuItem1.Size = new System.Drawing.Size(152, 26);
            this.newToolStripMenuItem1.Text = "New";
            // 
            // exitToolStripMenuItem3
            // 
            this.exitToolStripMenuItem3.Name = "exitToolStripMenuItem3";
            this.exitToolStripMenuItem3.Size = new System.Drawing.Size(152, 26);
            this.exitToolStripMenuItem3.Text = "Exit";
            // 
            // fileToolStripMenuItem2
            // 
            this.fileToolStripMenuItem2.Name = "fileToolStripMenuItem2";
            this.fileToolStripMenuItem2.Size = new System.Drawing.Size(55, 25);
            this.fileToolStripMenuItem2.Text = "File";
            // 
            // optionsToolStripMenuItem2
            // 
            this.optionsToolStripMenuItem2.Name = "optionsToolStripMenuItem2";
            this.optionsToolStripMenuItem2.Size = new System.Drawing.Size(91, 25);
            this.optionsToolStripMenuItem2.Text = "Options";
            // 
            // exitToolStripMenuItem4
            // 
            this.exitToolStripMenuItem4.Name = "exitToolStripMenuItem4";
            this.exitToolStripMenuItem4.Size = new System.Drawing.Size(56, 25);
            this.exitToolStripMenuItem4.Text = "Exit";
            // 
            // newToolStripMenuItem2
            // 
            this.newToolStripMenuItem2.Name = "newToolStripMenuItem2";
            this.newToolStripMenuItem2.Size = new System.Drawing.Size(152, 26);
            this.newToolStripMenuItem2.Text = "New";
            // 
            // exitToolStripMenuItem5
            // 
            this.exitToolStripMenuItem5.Name = "exitToolStripMenuItem5";
            this.exitToolStripMenuItem5.Size = new System.Drawing.Size(152, 26);
            this.exitToolStripMenuItem5.Text = "Exit";
            // 
            // currentTime
            // 
            this.currentTime.AutoSize = true;
            this.currentTime.BackColor = System.Drawing.Color.Transparent;
            this.currentTime.Font = new System.Drawing.Font("Monotype Corsiva", 21.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.currentTime.Location = new System.Drawing.Point(344, 1);
            this.currentTime.Name = "currentTime";
            this.currentTime.Size = new System.Drawing.Size(154, 36);
            this.currentTime.TabIndex = 12;
            this.currentTime.Text = "00:00:00:00";
            // 
            // processors1
            // 
            this.processors1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.processors1.BackColor = System.Drawing.Color.Transparent;
            this.processors1.Location = new System.Drawing.Point(34, 53);
            this.processors1.Name = "processors1";
            this.processors1.Size = new System.Drawing.Size(150, 240);
            this.processors1.TabIndex = 1;
            // 
            // global1
            // 
            this.global1.BackColor = System.Drawing.Color.Transparent;
            this.global1.Location = new System.Drawing.Point(34, 53);
            this.global1.Name = "global1";
            this.global1.Size = new System.Drawing.Size(150, 222);
            this.global1.TabIndex = 0;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::ComputerSystems.Properties.Resources.BG_2_task;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(1200, 624);
            this.Controls.Add(this.currentTime);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Computer Systems";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.play_pause)).EndInit();
            this.panel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.PictureBox play_pause;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel groupBox2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RichTextBox logging;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem4;
        private System.Windows.Forms.Label Green_Task;
        private System.Windows.Forms.Label Yellow_Task;
        private System.Windows.Forms.Label Red_Task;
        private System.Windows.Forms.Label currentTime;
        private Controls.Global global1;
        private Controls.Processors processors1;

    }
}

