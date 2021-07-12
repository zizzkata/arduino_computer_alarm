namespace Arduino_Assignment_3
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
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.pMenu = new System.Windows.Forms.Panel();
            this.lbLocation = new System.Windows.Forms.Label();
            this.lbAge = new System.Windows.Forms.Label();
            this.lbName = new System.Windows.Forms.Label();
            this.btnPortOpen = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pInfo = new System.Windows.Forms.Panel();
            this.lbRoomLight = new System.Windows.Forms.Label();
            this.lbRoomHum = new System.Windows.Forms.Label();
            this.lbRoomTemp = new System.Windows.Forms.Label();
            this.lbHsAngle = new System.Windows.Forms.Label();
            this.lbAlarmState = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.pMenu.SuspendLayout();
            this.pInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // serialPort1
            // 
            this.serialPort1.PortName = "COM5";
            // 
            // timer1
            // 
            this.timer1.Interval = 50;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Patient1",
            "Patient2",
            "Patient3",
            "Patient4",
            "Patient5"});
            this.comboBox1.Location = new System.Drawing.Point(12, 49);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(207, 28);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // pMenu
            // 
            this.pMenu.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pMenu.Controls.Add(this.lbLocation);
            this.pMenu.Controls.Add(this.lbAge);
            this.pMenu.Controls.Add(this.lbName);
            this.pMenu.Controls.Add(this.btnPortOpen);
            this.pMenu.Controls.Add(this.label4);
            this.pMenu.Controls.Add(this.label3);
            this.pMenu.Controls.Add(this.label2);
            this.pMenu.Controls.Add(this.label1);
            this.pMenu.Controls.Add(this.comboBox1);
            this.pMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.pMenu.Location = new System.Drawing.Point(0, 0);
            this.pMenu.Name = "pMenu";
            this.pMenu.Size = new System.Drawing.Size(260, 450);
            this.pMenu.TabIndex = 1;
            // 
            // lbLocation
            // 
            this.lbLocation.AutoSize = true;
            this.lbLocation.Location = new System.Drawing.Point(106, 243);
            this.lbLocation.Name = "lbLocation";
            this.lbLocation.Size = new System.Drawing.Size(74, 20);
            this.lbLocation.TabIndex = 8;
            this.lbLocation.Text = "Location:";
            // 
            // lbAge
            // 
            this.lbAge.AutoSize = true;
            this.lbAge.Location = new System.Drawing.Point(106, 203);
            this.lbAge.Name = "lbAge";
            this.lbAge.Size = new System.Drawing.Size(42, 20);
            this.lbAge.TabIndex = 7;
            this.lbAge.Text = "Age:";
            // 
            // lbName
            // 
            this.lbName.AutoSize = true;
            this.lbName.Location = new System.Drawing.Point(106, 170);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(55, 20);
            this.lbName.TabIndex = 6;
            this.lbName.Text = "Name:";
            // 
            // btnPortOpen
            // 
            this.btnPortOpen.Location = new System.Drawing.Point(16, 366);
            this.btnPortOpen.Name = "btnPortOpen";
            this.btnPortOpen.Size = new System.Drawing.Size(203, 39);
            this.btnPortOpen.TabIndex = 3;
            this.btnPortOpen.Text = "Turn-On port";
            this.btnPortOpen.UseVisualStyleBackColor = true;
            this.btnPortOpen.Visible = false;
            this.btnPortOpen.Click += new System.EventHandler(this.button1_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 243);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 20);
            this.label4.TabIndex = 5;
            this.label4.Text = "Location:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 203);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Age:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 170);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Name:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Select a patient:";
            // 
            // pInfo
            // 
            this.pInfo.Controls.Add(this.lbRoomLight);
            this.pInfo.Controls.Add(this.lbRoomHum);
            this.pInfo.Controls.Add(this.lbRoomTemp);
            this.pInfo.Controls.Add(this.lbHsAngle);
            this.pInfo.Controls.Add(this.lbAlarmState);
            this.pInfo.Controls.Add(this.button1);
            this.pInfo.Controls.Add(this.label10);
            this.pInfo.Controls.Add(this.label9);
            this.pInfo.Controls.Add(this.label8);
            this.pInfo.Controls.Add(this.label7);
            this.pInfo.Controls.Add(this.label6);
            this.pInfo.Controls.Add(this.listBox1);
            this.pInfo.Controls.Add(this.label5);
            this.pInfo.Dock = System.Windows.Forms.DockStyle.Right;
            this.pInfo.Location = new System.Drawing.Point(261, 0);
            this.pInfo.Name = "pInfo";
            this.pInfo.Size = new System.Drawing.Size(898, 450);
            this.pInfo.TabIndex = 2;
            this.pInfo.Visible = false;
            // 
            // lbRoomLight
            // 
            this.lbRoomLight.AutoSize = true;
            this.lbRoomLight.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRoomLight.Location = new System.Drawing.Point(279, 349);
            this.lbRoomLight.Name = "lbRoomLight";
            this.lbRoomLight.Size = new System.Drawing.Size(180, 32);
            this.lbRoomLight.TabIndex = 12;
            this.lbRoomLight.Text = "Room Lighting:";
            // 
            // lbRoomHum
            // 
            this.lbRoomHum.AutoSize = true;
            this.lbRoomHum.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRoomHum.Location = new System.Drawing.Point(279, 285);
            this.lbRoomHum.Name = "lbRoomHum";
            this.lbRoomHum.Size = new System.Drawing.Size(191, 32);
            this.lbRoomHum.TabIndex = 11;
            this.lbRoomHum.Text = "Room Humidity:";
            // 
            // lbRoomTemp
            // 
            this.lbRoomTemp.AutoSize = true;
            this.lbRoomTemp.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRoomTemp.Location = new System.Drawing.Point(279, 232);
            this.lbRoomTemp.Name = "lbRoomTemp";
            this.lbRoomTemp.Size = new System.Drawing.Size(230, 32);
            this.lbRoomTemp.TabIndex = 10;
            this.lbRoomTemp.Text = "Room Temperature:";
            // 
            // lbHsAngle
            // 
            this.lbHsAngle.AutoSize = true;
            this.lbHsAngle.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbHsAngle.Location = new System.Drawing.Point(279, 160);
            this.lbHsAngle.Name = "lbHsAngle";
            this.lbHsAngle.Size = new System.Drawing.Size(209, 32);
            this.lbHsAngle.TabIndex = 9;
            this.lbHsAngle.Text = "Headstand Angle:";
            // 
            // lbAlarmState
            // 
            this.lbAlarmState.AutoSize = true;
            this.lbAlarmState.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbAlarmState.Location = new System.Drawing.Point(279, 63);
            this.lbAlarmState.Name = "lbAlarmState";
            this.lbAlarmState.Size = new System.Drawing.Size(149, 32);
            this.lbAlarmState.TabIndex = 8;
            this.lbAlarmState.Text = "Alarm State:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(76, 115);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(176, 36);
            this.button1.TabIndex = 7;
            this.button1.Text = "Stop the Alarm";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(101, 359);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(116, 20);
            this.label10.TabIndex = 6;
            this.label10.Text = "Room Lighting:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(101, 295);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(121, 20);
            this.label9.TabIndex = 5;
            this.label9.Text = "Room Humidity:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(101, 242);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(151, 20);
            this.label8.TabIndex = 4;
            this.label8.Text = "Room Temperature:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(101, 170);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(137, 20);
            this.label7.TabIndex = 3;
            this.label7.Text = "Headstand Angle:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(101, 73);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(97, 20);
            this.label6.TabIndex = 2;
            this.label6.Text = "Alarm State:";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 20;
            this.listBox1.Location = new System.Drawing.Point(515, 49);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(371, 364);
            this.listBox1.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(533, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(107, 20);
            this.label5.TabIndex = 0;
            this.label5.Text = "Alarm History:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1159, 450);
            this.Controls.Add(this.pInfo);
            this.Controls.Add(this.pMenu);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.pMenu.ResumeLayout(false);
            this.pMenu.PerformLayout();
            this.pInfo.ResumeLayout(false);
            this.pInfo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Panel pMenu;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel pInfo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnPortOpen;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lbRoomLight;
        private System.Windows.Forms.Label lbRoomHum;
        private System.Windows.Forms.Label lbRoomTemp;
        private System.Windows.Forms.Label lbHsAngle;
        private System.Windows.Forms.Label lbAlarmState;
        private System.Windows.Forms.Label lbLocation;
        private System.Windows.Forms.Label lbAge;
        private System.Windows.Forms.Label lbName;
        private System.Windows.Forms.Timer timer1;
    }
}

