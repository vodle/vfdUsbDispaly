using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.Diagnostics;
using System.Timers;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace vfdDisplay
{
    public partial class Form1 : Form
    {

        Display display;
        PerformanceCounter cpuCounter;
        PerformanceCounter ramCounter;
        PerformanceCounter uptimeCounter;
        int prevCpu, prevRam = 0;
        int pageCounter = 0;

        public Form1()
        {
            cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
            ramCounter = new PerformanceCounter("Memory", "% Committed Bytes In Use");
            uptimeCounter = new PerformanceCounter("System", "System Up Time");


            InitializeComponent();
            String[] ports = SerialPort.GetPortNames();
            cbPorts.Items.AddRange(ports);
            display = new Display(comport);
            LoadPort();
            comport.Open();

            display.DisableBlinking();
            DrowClockAndUptime();

            timer20sec.Interval =20000;
            timer20sec.Enabled = true;
            timer20sec.Start();
            timer60sec.Interval = 60000;
            timer60sec.Enabled = true;
            timer60sec.Start();
            WindowState = FormWindowState.Minimized;
            this.ShowInTaskbar = false;
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {            
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cbPorts.SelectedIndex == -1) {
                MessageBox.Show("no iteme selected!");
            }
            else
            {
                Properties.Settings.Default.PortName = cbPorts.SelectedText;
                Properties.Settings.Default.Save();
            }
        }

        public void LoadPort() {
            if (Properties.Settings.Default.PortName == "")
            {
                comport.PortName = "COM9";
            }
            else {
                comport.PortName =  Properties.Settings.Default.PortName;
            }
        }

        private void nIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
            nIcon.Visible = false;
            WindowState = FormWindowState.Normal;
        }

        private void btnWrite_Click(object sender, EventArgs e)
        {
            UpdateCpuAndRam();
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                this.Hide();
                nIcon.Visible = true;
                this.ShowInTaskbar = false;
            }
            else if (FormWindowState.Normal == this.WindowState) {
                nIcon.Visible = false;
                this.ShowInTaskbar = true;
            }
        }

        private void DrowPageProgress(string firstRow, string secondRow, int firstProgress, int secondProgress) {
            display.ClearScreen();
            display.MoveToHomePosition();
            display.DrawProgress(firstRow, firstProgress, true);
            display.MoveDawn();
            display.DrawProgress(secondRow, secondProgress, true);
        }

        public void UpdateCpuAndRam() {
            int cpu = (int)cpuCounter.NextValue();
            int mem = (int)ramCounter.NextValue();
            DrowPageProgress("CPU","MEM",cpu, mem);
        }

        private void timer60sec_Tick(object sender, EventArgs e)
        {
            if (pageCounter < 2)
            {
                pageCounter++;
            }
           
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            display.InitDisplay();
            display.ClearScreen();
            comport.Close();
            Application.Exit();
        }

        private void timer20sec_Tick(object sender, EventArgs e)
        {
            switch (pageCounter)
            {
                case 0:
                    DrowClockAndUptime();
                    break;
                case 1:
                    UpdateCpuAndRam();
                    break;
            }
            if (pageCounter >= 2) {
                pageCounter = 0;

            }
        }

        private void DrowClockAndUptime() {

            uptimeCounter.NextValue();
            display.DrawClock();
            display.MoveToSpecifiedPosition(1, 1);
            display.Write("NOW:");
            display.MoveToSpecifiedPosition(1, 2);
            display.Write("UP:");

            display.MoveToSpecifiedPosition(6, 2);
            DateTime uptime = UnixTimeStampToDateTime(uptimeCounter.NextValue());
            string formated = uptime.ToString("dd:HH:mm:ss");

            display.Write(formated);

        }
        public DateTime UnixTimeStampToDateTime(double unixTimeStamp)
        {
            DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dateTime = dateTime.AddMilliseconds(unixTimeStamp).ToLocalTime();
            return dateTime;
        }

    }

}
