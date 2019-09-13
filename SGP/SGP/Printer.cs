using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Printing;

using System.IO;
using System.IO.Ports;
using System.Threading;

using System.Runtime.InteropServices;

using System.Windows.Forms;

namespace SGP
{
    class Printer
    {

        public static int MODE_DEVICE = 1;
        public static int MODE_SERIAL = 2;
        public static int MODE_PARALLEL = 3;

        const int GENERIC_WRITE = 0x40000000;
        const int OPEN_EXISTING = 3;

        private int _mode;

        private PrintDocument pd = new PrintDocument();
        protected PaperSize pz;
        protected Font printFont;

        protected SerialPort _serialPort;
        private string[] _lines = new string[0];

        public string PortName      = "com1:";
        public int PortBaudRate     = 9600;
        public string PortParity    = "1";
        public int PortDataBits     = 8;
        public string PortStopBits  = "0";
        public string PortHandshake = "0";

        public IntPtr ptr;
        
        public Printer(int mode = 1, string printerName = null, string port = null)
        {

            switch(mode) {
                case 1:

                    PrinterSettings s = new PrinterSettings();

                    if (printerName != null)
                        s.PrinterName = printerName;

                    pd.PrintPage += new PrintPageEventHandler(this.pd_PrintPage);

                    break;

                case 2:

                    _serialPort = new SerialPort();

                    if (port == null)
                    {
                        _serialPort.PortName = PortName;
                    }
                    else
                    {
                        _serialPort.PortName = port;
                    }

                    _serialPort.BaudRate    = PortBaudRate;
                    _serialPort.Parity      = (Parity)Enum.Parse(typeof(Parity), PortParity, true);
                    _serialPort.DataBits    = PortDataBits;
                    //_serialPort.StopBits    = (StopBits)Enum.Parse(typeof(StopBits), PortStopBits, true);
                    _serialPort.Handshake   = (Handshake)Enum.Parse(typeof(Handshake), PortHandshake, true);

                    break;

                case 3:

                    if (port == null)
                        port = "LPT1";

                    ptr = CreateFile(port, GENERIC_WRITE, 0,
                                     IntPtr.Zero, OPEN_EXISTING, 0, IntPtr.Zero);

                    break;

            }

            _mode = mode;

        }

        public void Initialize()
        {
        }

        public void Add(string text)
        {

            int len = this._lines.Length;

            Array.Resize<string>(ref this._lines, (len + 1));
            this._lines[len] = text;

        }

        public void Print()
        {

            switch(_mode) {
                case 1:
                    PrintDialog printer = new PrintDialog();
                    printer.Document = this.pd;
                    if (printer.ShowDialog() == DialogResult.OK)
                    {
                        this.pd.Print();
                    }
                    break;
                case 2:

                    _serialPort.Open();

                    foreach (string line in _lines)
                    {
                        _serialPort.WriteLine(line);
                    }

                    _serialPort.Close();

                    break;
                case 3:

                    FileStream lpt = new FileStream(ptr, FileAccess.ReadWrite);
                    Byte[] buffer = new Byte[2048];
                    //buffer = System.Text.Encoding.Unicode.GetBytes(Temp);

                    foreach (string line in _lines)
                    {
                        buffer = System.Text.Encoding.ASCII.GetBytes(line);
                        lpt.Write(buffer, 0, buffer.Length);
                    }
                    
                    lpt.Close();

                    break;
            }

            /*PrinterSettings s = new PrinterSettings();
            s.PrinterName = "Generic / Text Only";

            RawPrinterHelper.SendStringToPrinter(s.PrinterName, "Test");*/

        }

        public void pd_PrintPage(object sender, PrintPageEventArgs e)
        {

            int height = 0;
            float marginLeft = e.MarginBounds.Left;
            
            printFont = new Font("Arial", 10);

            foreach(string line in _lines)
            {
                e.Graphics.DrawString(line, printFont, Brushes.Black, new Point(20, height));
                height += 20;
            }

        }

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern IntPtr CreateFile(string lpFileName, uint dwDesiredAccess, uint dwShareMode, IntPtr lpSecurityAttributes, uint dwCreationDisposition, uint dwFlagsAndAttributes, IntPtr hTemplateFile);

    }
}
