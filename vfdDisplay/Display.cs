using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.Runtime.InteropServices.WindowsRuntime;

namespace vfdDisplay
{
    internal class Display
    {
        private SerialPort comport;

        public Display(SerialPort comport) {
        this.comport = comport;
        }
        public void InitDisplay()
        {
            byte[] bytesToSend = new byte[] { 0x1B, 0x40 };
            comport.Write(bytesToSend, 0, bytesToSend.Length);
        }
        public void DisableBlinking()
        {
            byte[] bytesToSend = new byte[] { 0x1f, 0x45, 0x00 };
            comport.Write(bytesToSend, 0, bytesToSend.Length);
        }

        public void Write(string text) {
            comport.Write(text);
        }

        public void ClearScreen() {
            byte[] bytesToSend = new byte[] { 0x0C};
            comport.Write(bytesToSend, 0, bytesToSend.Length);
        }

        public void MoveToHomePosition() {
            byte[] bytesToSend = new byte[] { 0x0B };
            comport.Write(bytesToSend, 0, bytesToSend.Length);
        }

        public void MoveToStringEndPosition()
        {
            byte[] bytesToSend = new byte[] { 0x1F, 0x0D};
            comport.Write(bytesToSend, 0, bytesToSend.Length);
        }

        public void MoveToStringStartPosition()
        {
            byte[] bytesToSend = new byte[] { 0x0D};
            comport.Write(bytesToSend, 0, bytesToSend.Length);
        }

        public void MoveRight(int count = 1) {
            byte[] bytesToSend = new byte[] { 0x09};
            for (int i = 0; i < count; i++){
                comport.Write(bytesToSend, 0, bytesToSend.Length);
            }
        }
        public void MoveLeft(int count = 1)
        {
            byte[] bytesToSend = new byte[] { 0x08 };
            for (int i = 0; i < count; i++)
            {
                comport.Write(bytesToSend, 0, bytesToSend.Length);
            }
        }
        public void MoveUp()
        {
            byte[] bytesToSend = new byte[] { 0x1F, 0x0A };
            comport.Write(bytesToSend, 0, bytesToSend.Length);
        }

        public void MoveDawn()
        {
            byte[] bytesToSend = new byte[] { 0x0A };
            comport.Write(bytesToSend, 0, bytesToSend.Length);
        }

        public void MoveToSpecifiedPosition(int column, int row) {
            if (column >= 20) { column = 20; }
            if (row >= 2) { row = 2; }
            byte[] bytesToSend = new byte[] { 0x1F, 0x24, Convert.ToByte(16 * (column / 10) + (column % 10)),
                                                            Convert.ToByte(16 * (row / 10) + (row % 10)) };
            comport.Write(bytesToSend, 0, bytesToSend.Length);
        }

        public void DrawProgress(string title, int progress) {
            if (title.Length> 3)
            {
                title = title.Substring(0, 3);
            }
            int progres = map(progress, 0, 100, 0, 14);
            MoveToStringStartPosition();
            Write("{");
            for (int i = 0; i < 14; i++) {
                if (i < progres)
                {
                    Write("#");
                }
                else {
                    Write("-");
                }
            }
            Write("}");
            MoveRight();
            Write(title);

        }

        public void DrawProgress(string title, int progress, bool withProcents)
        {
            if (title.Length > 3)
            {
                title = title.Substring(0, 3);
            }
            int progres = map(progress, 0, 100, 0, 14);
            MoveToStringStartPosition();
            Write("{");
            for (int i = 0; i < 10; i++)
            {
                if (i < progres)
                {
                    Write("#");
                }
                else
                {
                    Write("-");
                }
            }
            Write("}");
            MoveRight();
            if (map(progress, 0, 100, 0, 99) < 10) {
                MoveRight();
            }
            Write(map(progress, 0, 100, 0, 99).ToString());
            Write("%");
            MoveRight();
            Write(title);

        }


        private int map(int value, int inMin, int inMax, int outMin, int OutMax) {
            return (int)((value - inMin) * (OutMax - outMin) / (inMax - inMin) + outMin);
        }

        public void DrawClock() {

            ClearScreen();
            MoveToHomePosition();
            string time = DateTime.Now.ToString("HH:mm:ss");
            MoveToSpecifiedPosition(7, 1);
            Write(time);


        }


    }
}
