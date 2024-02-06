namespace vfdDisplay
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnConnect = new System.Windows.Forms.Button();
            this.comport = new System.IO.Ports.SerialPort(this.components);
            this.cbPorts = new System.Windows.Forms.ComboBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.nIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.btnWrite = new System.Windows.Forms.Button();
            this.timer60sec = new System.Windows.Forms.Timer(this.components);
            this.btnNextScreen = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(12, 12);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(121, 23);
            this.btnConnect.TabIndex = 0;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // comport
            // 
            this.comport.PortName = "COM9";
            // 
            // cbPorts
            // 
            this.cbPorts.FormattingEnabled = true;
            this.cbPorts.Location = new System.Drawing.Point(12, 42);
            this.cbPorts.Name = "cbPorts";
            this.cbPorts.Size = new System.Drawing.Size(121, 24);
            this.cbPorts.TabIndex = 1;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(140, 12);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // nIcon
            // 
            this.nIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.nIcon.BalloonTipText = "working 🤖";
            this.nIcon.BalloonTipTitle = "🤖";
            this.nIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("nIcon.Icon")));
            this.nIcon.Text = "PC Monitor";
            this.nIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.nIcon_MouseDoubleClick);
            // 
            // btnWrite
            // 
            this.btnWrite.Location = new System.Drawing.Point(140, 42);
            this.btnWrite.Name = "btnWrite";
            this.btnWrite.Size = new System.Drawing.Size(75, 23);
            this.btnWrite.TabIndex = 3;
            this.btnWrite.Text = "write";
            this.btnWrite.UseVisualStyleBackColor = true;
            this.btnWrite.Click += new System.EventHandler(this.btnWrite_Click);
            // 
            // timer60sec
            // 
            this.timer60sec.Enabled = true;
            this.timer60sec.Interval = 60000;
            this.timer60sec.Tick += new System.EventHandler(this.timer60sec_Tick);
            // 
            // btnNextScreen
            // 
            this.btnNextScreen.Location = new System.Drawing.Point(222, 12);
            this.btnNextScreen.Name = "btnNextScreen";
            this.btnNextScreen.Size = new System.Drawing.Size(75, 23);
            this.btnNextScreen.TabIndex = 4;
            this.btnNextScreen.Text = "Next S";
            this.btnNextScreen.UseVisualStyleBackColor = true;
            this.btnNextScreen.Click += new System.EventHandler(this.btnNextScreen_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 453);
            this.Controls.Add(this.btnNextScreen);
            this.Controls.Add(this.btnWrite);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.cbPorts);
            this.Controls.Add(this.btnConnect);
            this.Name = "Form1";
            this.Text = "Main VFD Form ";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnConnect;
        private System.IO.Ports.SerialPort comport;
        private System.Windows.Forms.ComboBox cbPorts;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.NotifyIcon nIcon;
        private System.Windows.Forms.Button btnWrite;
        private System.Windows.Forms.Timer timer60sec;
        private System.Windows.Forms.Button btnNextScreen;
    }
}

