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

namespace Test1
{
    public partial class Form2 : Form
    {
        bool isConnected;
        String[] ports;
        delegate void serialCalback(string val);
        String selectedPort;

        public Form2(bool isConnected)
        {
            InitializeComponent();
            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.isConnected = isConnected;
            this.connect.TextAlign = ContentAlignment.MiddleCenter;
            this.CenterToParent();

            if(isConnected)
            {
                portBox.Enabled = false;
                this.scan.Enabled = false;
                this.connect.Text = "Disconnect";
            }
            else
            {
                portBox.Enabled = true;
                this.scan.Enabled = true;
                this.connect.Text = "Connect";
                scan_port();
            }
        }

        private void scan_port()
        {
            ports = SerialPort.GetPortNames();

            foreach (string port in ports)
            {
                portBox.Items.Add(port);
                Console.WriteLine(port);
                if (ports[0] != null)
                {
                    portBox.SelectedItem = ports[0];
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!isConnected)
            {
                connectToArduino();
            }
            else
            {
                disconnectFromArduino();
            }
        }
        private void connectToArduino()
        {
            selectedPort = portBox.GetItemText(portBox.SelectedItem);
            Console.WriteLine(selectedPort);
            if(!selectedPort.Equals(""))
            {
                isConnected = true;
                Send_port();
                Send_connect();
                this.Close();
            }
            else
            {
                MessageBox.Show("No port detected, please try again or reconnect the device!!", "Port Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void disconnectFromArduino()
        {
            isConnected = false;
            connect.Text = "Connect";
            portBox.Enabled = true;
            this.scan.Enabled = true;
            Send_connect();
            scan_port();
        }

        private void scan_Click(object sender, EventArgs e)
        {
            portBox.Items.Clear();
            portBox.Text = "";
            scan_port();
        }

        public void Send_port()
        {
            Form1 form1 = (Form1)this.Owner;
            form1.Send_port(selectedPort);
        }

        public void Send_connect()
        {
            Form1 form1 = (Form1)this.Owner;
            form1.Send_connect(this.isConnected);
        }
    }
}
