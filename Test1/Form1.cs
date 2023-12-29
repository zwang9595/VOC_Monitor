using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.ObjectModel;
using System.IO.Ports;

using MindFusion.Charting;
using Brush = MindFusion.Drawing.Brush;
using SolidBrush = MindFusion.Drawing.SolidBrush;

namespace Test1
{
    public partial class Form1 : Form
    {
        SerialPort port;
        String port_name, received_data;
        String[] data;

        Timer temp_timer = new Timer();
        Timer co2_timer = new Timer();
        Timer tvoc_timer = new Timer();

        bool isconnected, read_s;

        MyDateTimeSeries temp_1, temp_2, temp_3, temp_4, temp_5, temp_6, temp_7, temp_8, temp_avg;
        MyDateTimeSeries co2_1, co2_2, co2_3, co2_4, co2_5, co2_6, co2_7, co2_8, co2_avg;
        MyDateTimeSeries tvoc_1, tvoc_2, tvoc_3, tvoc_4, tvoc_5, tvoc_6, tvoc_7, tvoc_8, tvoc_avg;

        public Form1()
        {
            InitializeComponent();

            this.isconnected = false;
            this.data = new String[28];

            this.comBox.Enabled = false;
            this.comBox.Text = "Disconnected";
            this.comBox.TextAlign = HorizontalAlignment.Center;
            
            this.port_name = "";

            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.FormClosed += Close_clicked;
            this.CenterToScreen();

            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            checkBox4.Checked = false;
            checkBox5.Checked = false;
            checkBox6.Checked = false;
            checkBox7.Checked = false;
            checkBox8.Checked = false;
            checkBox9.Checked = false;
            checkBox10.Checked = false;

            checkBox1.Enabled = false;
            checkBox2.Enabled = false;
            checkBox3.Enabled = false;
            checkBox4.Enabled = false;
            checkBox5.Enabled = false;
            checkBox6.Enabled = false;
            checkBox7.Enabled = false;
            checkBox8.Enabled = false;
            checkBox9.Enabled = false;
            checkBox10.Enabled = false;

            // create sample data
            ObservableCollection<Series> data = new ObservableCollection<Series>();

            temp_1 = new MyDateTimeSeries(DateTime.Now, DateTime.Now, DateTime.Now.AddMinutes(1));
            temp_1.DateTimeFormat = DateTimeFormat.CustomDateTime;
            temp_1.CustomDateTimeFormat = "mm:ss";
            //how many values will be added before a time stamp is rendered at the axis
            temp_1.LabelInterval = 10;
            temp_1.MinValue = 0;
            temp_1.MaxValue = 120;
            temp_1.Title = "R0";
            temp_1.SupportedLabels = LabelKinds.XAxisLabel;

            temp_2 = new MyDateTimeSeries(DateTime.Now, DateTime.Now, DateTime.Now.AddMinutes(1));
            temp_2.DateTimeFormat = DateTimeFormat.CustomDateTime;
            temp_2.CustomDateTimeFormat = "mm:ss";
            //how many values will be added before a time stamp is rendered at the axis
            temp_2.LabelInterval = 10;
            temp_2.MinValue = 0;
            temp_2.MaxValue = 120;
            temp_2.Title = "R1";
            temp_2.SupportedLabels = LabelKinds.None;

            temp_3 = new MyDateTimeSeries(DateTime.Now, DateTime.Now, DateTime.Now.AddMinutes(1));
            temp_3.DateTimeFormat = DateTimeFormat.CustomDateTime;
            temp_3.CustomDateTimeFormat = "mm:ss";
            //how many values will be added before a time stamp is rendered at the axis
            temp_3.LabelInterval = 10;
            temp_3.MinValue = 0;
            temp_3.MaxValue = 120;
            temp_3.Title = "R2";
            temp_3.SupportedLabels = LabelKinds.None;

            temp_4 = new MyDateTimeSeries(DateTime.Now, DateTime.Now, DateTime.Now.AddMinutes(1));
            temp_4.DateTimeFormat = DateTimeFormat.CustomDateTime;
            temp_4.CustomDateTimeFormat = "mm:ss";
            //how many values will be added before a time stamp is rendered at the axis
            temp_4.LabelInterval = 10;
            temp_4.MinValue = 0;
            temp_4.MaxValue = 120;
            temp_4.Title = "R3";
            temp_4.SupportedLabels = LabelKinds.None;

            temp_5 = new MyDateTimeSeries(DateTime.Now, DateTime.Now, DateTime.Now.AddMinutes(1));
            temp_5.DateTimeFormat = DateTimeFormat.CustomDateTime;
            temp_5.CustomDateTimeFormat = "mm:ss";
            //how many values will be added before a time stamp is rendered at the axis
            temp_5.LabelInterval = 10;
            temp_5.MinValue = 0;
            temp_5.MaxValue = 120;
            temp_5.Title = "R4";
            temp_5.SupportedLabels = LabelKinds.None;

            temp_6 = new MyDateTimeSeries(DateTime.Now, DateTime.Now, DateTime.Now.AddMinutes(1));
            temp_6.DateTimeFormat = DateTimeFormat.CustomDateTime;
            temp_6.CustomDateTimeFormat = "mm:ss";
            //how many values will be added before a time stamp is rendered at the axis
            temp_6.LabelInterval = 10;
            temp_6.MinValue = 0;
            temp_6.MaxValue = 120;
            temp_6.Title = "R5";
            temp_6.SupportedLabels = LabelKinds.None;

            temp_7 = new MyDateTimeSeries(DateTime.Now, DateTime.Now, DateTime.Now.AddMinutes(1));
            temp_7.DateTimeFormat = DateTimeFormat.CustomDateTime;
            temp_7.CustomDateTimeFormat = "mm:ss";
            //how many values will be added before a time stamp is rendered at the axis
            temp_7.LabelInterval = 10;
            temp_7.MinValue = 0;
            temp_7.MaxValue = 120;
            temp_7.Title = "R6";
            temp_7.SupportedLabels = LabelKinds.None;

            temp_8 = new MyDateTimeSeries(DateTime.Now, DateTime.Now, DateTime.Now.AddMinutes(1));
            temp_8.DateTimeFormat = DateTimeFormat.CustomDateTime;
            temp_8.CustomDateTimeFormat = "mm:ss";
            //how many values will be added before a time stamp is rendered at the axis
            temp_8.LabelInterval = 10;
            temp_8.MinValue = 0;
            temp_8.MaxValue = 120;
            temp_8.Title = "R7";
            temp_8.SupportedLabels = LabelKinds.None;

            temp_avg = new MyDateTimeSeries(DateTime.Now, DateTime.Now, DateTime.Now.AddMinutes(1));
            temp_avg.DateTimeFormat = DateTimeFormat.CustomDateTime;
            temp_avg.CustomDateTimeFormat = "mm:ss";
            //how many values will be added before a time stamp is rendered at the axis
            temp_avg.LabelInterval = 10;
            temp_avg.MinValue = 0;
            temp_avg.MaxValue = 120;
            temp_avg.Title = "Avg";
            temp_avg.SupportedLabels = LabelKinds.XAxisLabel;

            co2_1 = new MyDateTimeSeries(DateTime.Now, DateTime.Now, DateTime.Now.AddMinutes(1));
            co2_1.DateTimeFormat = DateTimeFormat.CustomDateTime;
            co2_1.CustomDateTimeFormat = "mm:ss";
            //how many values will be added before a time stamp is rendered at the axis
            co2_1.LabelInterval = 10;
            co2_1.MinValue = 0;
            co2_1.MaxValue = 120;
            co2_1.Title = "S0";
            co2_1.SupportedLabels = LabelKinds.XAxisLabel;

            co2_2 = new MyDateTimeSeries(DateTime.Now, DateTime.Now, DateTime.Now.AddMinutes(1));
            co2_2.DateTimeFormat = DateTimeFormat.CustomDateTime;
            co2_2.CustomDateTimeFormat = "mm:ss";
            //how many values will be added before a time stamp is rendered at the axis
            co2_2.LabelInterval = 10;
            co2_2.MinValue = 0;
            co2_2.MaxValue = 120;
            co2_2.Title = "S1";
            co2_2.SupportedLabels = LabelKinds.None;

            co2_3 = new MyDateTimeSeries(DateTime.Now, DateTime.Now, DateTime.Now.AddMinutes(1));
            co2_3.DateTimeFormat = DateTimeFormat.CustomDateTime;
            co2_3.CustomDateTimeFormat = "mm:ss";
            //how many values will be added before a time stamp is rendered at the axis
            co2_3.LabelInterval = 10;
            co2_3.MinValue = 0;
            co2_3.MaxValue = 120;
            co2_3.Title = "S2";
            co2_3.SupportedLabels = LabelKinds.None;

            co2_4 = new MyDateTimeSeries(DateTime.Now, DateTime.Now, DateTime.Now.AddMinutes(1));
            co2_4.DateTimeFormat = DateTimeFormat.CustomDateTime;
            co2_4.CustomDateTimeFormat = "mm:ss";
            //how many values will be added before a time stamp is rendered at the axis
            co2_4.LabelInterval = 10;
            co2_4.MinValue = 0;
            co2_4.MaxValue = 120;
            co2_4.Title = "S3";
            co2_4.SupportedLabels = LabelKinds.None;

            co2_5 = new MyDateTimeSeries(DateTime.Now, DateTime.Now, DateTime.Now.AddMinutes(1));
            co2_5.DateTimeFormat = DateTimeFormat.CustomDateTime;
            co2_5.CustomDateTimeFormat = "mm:ss";
            //how many values will be added before a time stamp is rendered at the axis
            co2_5.LabelInterval = 10;
            co2_5.MinValue = 0;
            co2_5.MaxValue = 120;
            co2_5.Title = "S4";
            co2_5.SupportedLabels = LabelKinds.None;

            co2_6 = new MyDateTimeSeries(DateTime.Now, DateTime.Now, DateTime.Now.AddMinutes(1));
            co2_6.DateTimeFormat = DateTimeFormat.CustomDateTime;
            co2_6.CustomDateTimeFormat = "mm:ss";
            //how many values will be added before a time stamp is rendered at the axis
            co2_6.LabelInterval = 10;
            co2_6.MinValue = 0;
            co2_6.MaxValue = 120;
            co2_6.Title = "S5";
            co2_6.SupportedLabels = LabelKinds.None;

            co2_7 = new MyDateTimeSeries(DateTime.Now, DateTime.Now, DateTime.Now.AddMinutes(1));
            co2_7.DateTimeFormat = DateTimeFormat.CustomDateTime;
            co2_7.CustomDateTimeFormat = "mm:ss";
            //how many values will be added before a time stamp is rendered at the axis
            co2_7.LabelInterval = 10;
            co2_7.MinValue = 0;
            co2_7.MaxValue = 120;
            co2_7.Title = "S6";
            co2_7.SupportedLabels = LabelKinds.None;

            co2_8 = new MyDateTimeSeries(DateTime.Now, DateTime.Now, DateTime.Now.AddMinutes(1));
            co2_8.DateTimeFormat = DateTimeFormat.CustomDateTime;
            co2_8.CustomDateTimeFormat = "mm:ss";
            //how many values will be added before a time stamp is rendered at the axis
            co2_8.LabelInterval = 10;
            co2_8.MinValue = 0;
            co2_8.MaxValue = 120;
            co2_8.Title = "S7";
            co2_8.SupportedLabels = LabelKinds.None;

            co2_avg = new MyDateTimeSeries(DateTime.Now, DateTime.Now, DateTime.Now.AddMinutes(1));
            co2_avg.DateTimeFormat = DateTimeFormat.CustomDateTime;
            co2_avg.CustomDateTimeFormat = "mm:ss";
            //how many values will be added before a time stamp is rendered at the axis
            co2_avg.LabelInterval = 10;
            co2_avg.MinValue = 0;
            co2_avg.MaxValue = 120;
            co2_avg.Title = "Avg";
            co2_avg.SupportedLabels = LabelKinds.XAxisLabel;

            tvoc_1 = new MyDateTimeSeries(DateTime.Now, DateTime.Now, DateTime.Now.AddMinutes(1));
            tvoc_1.DateTimeFormat = DateTimeFormat.CustomDateTime;
            tvoc_1.CustomDateTimeFormat = "mm:ss";
            //how many values will be added before a time stamp is rendered at the axis
            tvoc_1.LabelInterval = 10;
            tvoc_1.MinValue = 0;
            tvoc_1.MaxValue = 120;
            tvoc_1.Title = "S0";
            tvoc_1.SupportedLabels = LabelKinds.XAxisLabel;

            tvoc_2 = new MyDateTimeSeries(DateTime.Now, DateTime.Now, DateTime.Now.AddMinutes(1));
            tvoc_2.DateTimeFormat = DateTimeFormat.CustomDateTime;
            tvoc_2.CustomDateTimeFormat = "mm:ss";
            //how many values will be added before a time stamp is rendered at the axis
            tvoc_2.LabelInterval = 10;
            tvoc_2.MinValue = 0;
            tvoc_2.MaxValue = 120;
            tvoc_2.Title = "S1";
            tvoc_2.SupportedLabels = LabelKinds.None;

            tvoc_3 = new MyDateTimeSeries(DateTime.Now, DateTime.Now, DateTime.Now.AddMinutes(1));
            tvoc_3.DateTimeFormat = DateTimeFormat.CustomDateTime;
            tvoc_3.CustomDateTimeFormat = "mm:ss";
            //how many values will be added before a time stamp is rendered at the axis
            tvoc_3.LabelInterval = 10;
            tvoc_3.MinValue = 0;
            tvoc_3.MaxValue = 120;
            tvoc_3.Title = "S2";
            tvoc_3.SupportedLabels = LabelKinds.None;

            tvoc_4 = new MyDateTimeSeries(DateTime.Now, DateTime.Now, DateTime.Now.AddMinutes(1));
            tvoc_4.DateTimeFormat = DateTimeFormat.CustomDateTime;
            tvoc_4.CustomDateTimeFormat = "mm:ss";
            //how many values will be added before a time stamp is rendered at the axis
            tvoc_4.LabelInterval = 10;
            tvoc_4.MinValue = 0;
            tvoc_4.MaxValue = 120;
            tvoc_4.Title = "S3";
            tvoc_4.SupportedLabels = LabelKinds.None;

            tvoc_5 = new MyDateTimeSeries(DateTime.Now, DateTime.Now, DateTime.Now.AddMinutes(1));
            tvoc_5.DateTimeFormat = DateTimeFormat.CustomDateTime;
            tvoc_5.CustomDateTimeFormat = "mm:ss";
            //how many values will be added before a time stamp is rendered at the axis
            tvoc_5.LabelInterval = 10;
            tvoc_5.MinValue = 0;
            tvoc_5.MaxValue = 120;
            tvoc_5.Title = "S4";
            tvoc_5.SupportedLabels = LabelKinds.None;

            tvoc_6 = new MyDateTimeSeries(DateTime.Now, DateTime.Now, DateTime.Now.AddMinutes(1));
            tvoc_6.DateTimeFormat = DateTimeFormat.CustomDateTime;
            tvoc_6.CustomDateTimeFormat = "mm:ss";
            //how many values will be added before a time stamp is rendered at the axis
            tvoc_6.LabelInterval = 10;
            tvoc_6.MinValue = 0;
            tvoc_6.MaxValue = 120;
            tvoc_6.Title = "S5";
            tvoc_6.SupportedLabels = LabelKinds.None;

            tvoc_7 = new MyDateTimeSeries(DateTime.Now, DateTime.Now, DateTime.Now.AddMinutes(1));
            tvoc_7.DateTimeFormat = DateTimeFormat.CustomDateTime;
            tvoc_7.CustomDateTimeFormat = "mm:ss";
            //how many values will be added before a time stamp is rendered at the axis
            tvoc_7.LabelInterval = 10;
            tvoc_7.MinValue = 0;
            tvoc_7.MaxValue = 120;
            tvoc_7.Title = "S6";
            tvoc_7.SupportedLabels = LabelKinds.None;

            tvoc_8 = new MyDateTimeSeries(DateTime.Now, DateTime.Now, DateTime.Now.AddMinutes(1));
            tvoc_8.DateTimeFormat = DateTimeFormat.CustomDateTime;
            tvoc_8.CustomDateTimeFormat = "mm:ss";
            //how many values will be added before a time stamp is rendered at the axis
            tvoc_8.LabelInterval = 10;
            tvoc_8.MinValue = 0;
            tvoc_8.MaxValue = 120;
            tvoc_8.Title = "S7";
            tvoc_8.SupportedLabels = LabelKinds.None;

            tvoc_avg = new MyDateTimeSeries(DateTime.Now, DateTime.Now, DateTime.Now.AddMinutes(1));
            tvoc_avg.DateTimeFormat = DateTimeFormat.CustomDateTime;
            tvoc_avg.CustomDateTimeFormat = "mm:ss";
            //how many values will be added before a time stamp is rendered at the axis
            tvoc_avg.LabelInterval = 10;
            tvoc_avg.MinValue = 0;
            tvoc_avg.MaxValue = 120;
            tvoc_avg.Title = "Avg";
            tvoc_avg.SupportedLabels = LabelKinds.XAxisLabel;

            // setup chart
            tempChart.Title = "Temperature";
            tempChart.ShowXCoordinates = false;
            tempChart.ShowLegendTitle = false;
            tempChart.LayoutPanel.Margin = new Margins(0, 0, 20, 0);

            tempChart.XAxis.Title = "";
            tempChart.XAxis.MinValue = 0;
            tempChart.XAxis.MaxValue = 120;
            tempChart.XAxis.Interval = 10;

            tempChart.YAxis.MinValue = 0;
            tempChart.YAxis.MaxValue = 50;
            tempChart.YAxis.Interval = 10;
            tempChart.YAxis.Title = "Temperature (C)";

            List<Brush> brushes = new List<Brush>()
            {
                new SolidBrush(Color.Red),
                new SolidBrush(Color.Orange),
                new SolidBrush(Color.SeaGreen),
                new SolidBrush(Color.Black),
                new SolidBrush(Color.Aqua),
                new SolidBrush(Color.BlueViolet),
                new SolidBrush(Color.Brown),
                new SolidBrush(Color.Yellow),
                new SolidBrush(Color.Ivory)
            };

            List<double> thicknesses = new List<double>() { 2 };

            PerSeriesStyle style = new PerSeriesStyle(brushes, brushes, thicknesses, null);
            tempChart.Plot.SeriesStyle = style;
            tempChart.Theme.PlotBackground = new SolidBrush(Color.White);
            tempChart.Theme.GridLineColor = Color.LightGray;
            tempChart.Theme.GridLineStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            tempChart.TitleMargin = new Margins(10);
            tempChart.GridType = GridType.Horizontal;

            temp_timer.Tick += new EventHandler(TimerEventProcessor_temp);

            // Sets the timer interval to half a seconds.
            temp_timer.Interval = 500;
            temp_timer.Start();

            // setup co2 chart
            co2_Chart.Title = "CO2 Value";
            co2_Chart.ShowXCoordinates = false;
            co2_Chart.ShowLegendTitle = false;
            co2_Chart.LayoutPanel.Margin = new Margins(0, 0, 20, 0);

            co2_Chart.XAxis.Title = "";
            co2_Chart.XAxis.MinValue = 0;
            co2_Chart.XAxis.MaxValue = 120;
            co2_Chart.XAxis.Interval = 10;

            co2_Chart.YAxis.MinValue = 400;
            co2_Chart.YAxis.MaxValue = 450;
            co2_Chart.YAxis.Interval = 20;
            co2_Chart.YAxis.Title = "ppm";

            co2_Chart.Plot.SeriesStyle = style;
            co2_Chart.Theme.PlotBackground = new SolidBrush(Color.White);
            co2_Chart.Theme.GridLineColor = Color.LightGray;
            co2_Chart.Theme.GridLineStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            co2_Chart.TitleMargin = new Margins(10);
            co2_Chart.GridType = GridType.Horizontal;

            co2_timer.Tick += new EventHandler(TimerEventProcessor_co2);

            // Sets the timer interval to half a seconds.
            co2_timer.Interval = 500;
            co2_timer.Start();

            // setup co2 chart
            tvoc_Chart.Title = "TVOC Value";
            tvoc_Chart.ShowXCoordinates = false;
            tvoc_Chart.ShowLegendTitle = false;
            tvoc_Chart.LayoutPanel.Margin = new Margins(0, 0, 20, 0);

            tvoc_Chart.XAxis.Title = "";
            tvoc_Chart.XAxis.MinValue = 0;
            tvoc_Chart.XAxis.MaxValue = 120;
            tvoc_Chart.XAxis.Interval = 10;

            tvoc_Chart.YAxis.MinValue = 0;
            tvoc_Chart.YAxis.MaxValue = 50;
            tvoc_Chart.YAxis.Interval = 10;
            tvoc_Chart.YAxis.Title = "ppb";

            tvoc_Chart.Plot.SeriesStyle = style;
            tvoc_Chart.Theme.PlotBackground = new SolidBrush(Color.White);
            tvoc_Chart.Theme.GridLineColor = Color.LightGray;
            tvoc_Chart.Theme.GridLineStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            tvoc_Chart.TitleMargin = new Margins(10);
            tvoc_Chart.GridType = GridType.Horizontal;

            tvoc_timer.Tick += new EventHandler(TimerEventProcessor_tvoc);

            // Sets the timer interval to half a seconds.
            tvoc_timer.Interval = 500;
            tvoc_timer.Start();
        }

        private void Connect_Click(object sender, EventArgs e)
        {
            using(Form2 form2 = new Form2(this.isconnected))
            {
                form2.FormClosed += F2_Closed;
                form2.ShowDialog(this);
            }
        }

        public void Send_connect(bool isc)
        {
            this.isconnected = isc;
            if (!isconnected)
            {
                comBox.Text = "Disconnected";
                port.DataReceived -= this.serialPort_DataReceived;
                port.Close();
                port = null;
            }
        }

        public void Send_port(string s)
        {
            this.port_name = s;
        }

        private void F2_Closed(object sender, FormClosedEventArgs e)
        {
            if(isconnected && port == null)
            {
                this.comBox.Text = port_name;
                port = new SerialPort(port_name, 115200, Parity.None, 8, StopBits.One);
                try 
                {
                    port.Open();
                    port.DataReceived += new SerialDataReceivedEventHandler(this.serialPort_DataReceived);
                    MessageBox.Show("Successfully connect to " + port_name + "!");
                    checkBox1.Enabled = true;
                    checkBox2.Enabled = true;
                    checkBox3.Enabled = true;
                    checkBox4.Enabled = true;
                    checkBox5.Enabled = true;
                    checkBox6.Enabled = true;
                    checkBox7.Enabled = true;
                    checkBox8.Enabled = true;
                    checkBox9.Enabled = true;
                    checkBox10.Enabled = true;
                }
                catch
                {
                    MessageBox.Show("Port is busy, please try again or reconnect the device!!", "Port is in used", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                if(port == null)
                {
                    MessageBox.Show("Port is not selected!!!", "Select port", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }              
            }
        }

        private void serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                received_data = port.ReadLine();
                String[] data_temp = received_data.Split('\t');
                if(data_temp[0].Equals("HH") & data_temp.Length == 29)
                {
                    Console.WriteLine("Read Success!");
                    read_s = true;
                    Array.Copy(data_temp, 1, data, 0, data_temp.Length - 2);
                    foreach (string words in data)
                    {
                        Console.Write($"{words} ");
                    }
                    Console.WriteLine();
                }
                else
                {
                    read_s = false;
                    Console.WriteLine("Read failed! Head: " + data_temp[0] + " Tail: " + data_temp[data.Length - 1] + "Length: " + data_temp.Length);
                    int h = data_temp[0].CompareTo("HH");
                    int t = data_temp[data_temp.Length - 1].CompareTo("AA");
                    Console.WriteLine("Head: " + h + " Tail: " + t);
                }
                this.Invoke(new EventHandler(DisplayText));
            }
            catch
            {
                MessageBox.Show("Port is busy, please try again or reconnect the device!!", "Port is in used", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Read/Update to textbox
        private void DisplayText(object s, EventArgs e)
        {
            receive.Text = received_data;
        }

        private void Close_clicked(object sender, FormClosedEventArgs e)
        {
            if(port != null)
            {
                if(port.IsOpen)
                {
                    port.DataReceived -= this.serialPort_DataReceived;
                    port.Close();
                }                
            }
            Application.Exit();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //tempChart.Series.Clear();
            //co2_Chart.Series.Clear();
            //tvoc_Chart.Series.Clear();
            temp_1.Clear();
            temp_2.Clear();
            temp_3.Clear();
            temp_4.Clear();
            temp_5.Clear();
            temp_6.Clear();
            temp_7.Clear();
            temp_8.Clear();
            temp_avg.Clear();

            co2_1.Clear();
            co2_2.Clear();
            co2_3.Clear();
            co2_4.Clear();
            co2_5.Clear();
            co2_6.Clear();
            co2_7.Clear();
            co2_8.Clear();
            co2_avg.Clear();

            tvoc_1.Clear();
            tvoc_2.Clear();
            tvoc_3.Clear();
            tvoc_4.Clear();
            tvoc_5.Clear();
            tvoc_6.Clear();
            tvoc_7.Clear();
            tvoc_8.Clear();
            tvoc_avg.Clear();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked)
            {
                tempChart.Series.Add(temp_1);
                co2_Chart.Series.Add(co2_1);
                tvoc_Chart.Series.Add(tvoc_1);
                check_All();
            }
            else
            {
                tempChart.Series.Remove(temp_1);
                co2_Chart.Series.Remove(co2_1);
                tvoc_Chart.Series.Remove(tvoc_1);
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                tempChart.Series.Add(temp_2);
                co2_Chart.Series.Add(co2_2);
                tvoc_Chart.Series.Add(tvoc_2);
                check_All();
            }
            else
            {
                tempChart.Series.Remove(temp_2);
                co2_Chart.Series.Remove(co2_2);
                tvoc_Chart.Series.Remove(tvoc_2);
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                tempChart.Series.Add(temp_3);
                co2_Chart.Series.Add(co2_3);
                tvoc_Chart.Series.Add(tvoc_3);
                check_All();
            }
            else
            {
                tempChart.Series.Remove(temp_3);
                co2_Chart.Series.Remove(co2_3);
                tvoc_Chart.Series.Remove(tvoc_3);
            }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked)
            {
                tempChart.Series.Add(temp_4);
                co2_Chart.Series.Add(co2_4);
                tvoc_Chart.Series.Add(tvoc_4);
                check_All();
            }
            else
            {
                tempChart.Series.Remove(temp_4);
                co2_Chart.Series.Remove(co2_4);
                tvoc_Chart.Series.Remove(tvoc_4);
            }
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox5.Checked)
            {
                tempChart.Series.Add(temp_5);
                co2_Chart.Series.Add(co2_5);
                tvoc_Chart.Series.Add(tvoc_5);
                check_All();
            }
            else
            {
                tempChart.Series.Remove(temp_5);
                co2_Chart.Series.Remove(co2_5);
                tvoc_Chart.Series.Remove(tvoc_5);
            }
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox6.Checked)
            {
                tempChart.Series.Add(temp_6);
                co2_Chart.Series.Add(co2_6);
                tvoc_Chart.Series.Add(tvoc_6);
                check_All();
            }
            else
            {
                tempChart.Series.Remove(temp_6);
                co2_Chart.Series.Remove(co2_6);
                tvoc_Chart.Series.Remove(tvoc_6);
            }
        }

        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox7.Checked)
            {
                tempChart.Series.Add(temp_7);
                co2_Chart.Series.Add(co2_7);
                tvoc_Chart.Series.Add(tvoc_7);
                check_All();
            }
            else
            {
                tempChart.Series.Remove(temp_7);
                co2_Chart.Series.Remove(co2_7);
                tvoc_Chart.Series.Remove(tvoc_7);
            }
        }

        private void checkBox8_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox8.Checked)
            {
                tempChart.Series.Add(temp_8);
                co2_Chart.Series.Add(co2_8);
                tvoc_Chart.Series.Add(tvoc_8);
                check_All();
            }
            else
            {
                tempChart.Series.Remove(temp_8);
                co2_Chart.Series.Remove(co2_8);
                tvoc_Chart.Series.Remove(tvoc_8);
            }
        }

        private void checkBox9_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox9.Checked)
            {
                tempChart.Series.Remove(temp_1);
                tempChart.Series.Remove(temp_2);
                tempChart.Series.Remove(temp_3);
                tempChart.Series.Remove(temp_4);
                tempChart.Series.Remove(temp_5);
                tempChart.Series.Remove(temp_6);
                tempChart.Series.Remove(temp_7);
                tempChart.Series.Remove(temp_8);

                co2_Chart.Series.Remove(co2_1);
                co2_Chart.Series.Remove(co2_2);
                co2_Chart.Series.Remove(co2_3);
                co2_Chart.Series.Remove(co2_4);
                co2_Chart.Series.Remove(co2_5);
                co2_Chart.Series.Remove(co2_6);
                co2_Chart.Series.Remove(co2_7);
                co2_Chart.Series.Remove(co2_8);

                tvoc_Chart.Series.Remove(tvoc_1);
                tvoc_Chart.Series.Remove(tvoc_2);
                tvoc_Chart.Series.Remove(tvoc_3);
                tvoc_Chart.Series.Remove(tvoc_4);
                tvoc_Chart.Series.Remove(tvoc_5);
                tvoc_Chart.Series.Remove(tvoc_6);
                tvoc_Chart.Series.Remove(tvoc_7);
                tvoc_Chart.Series.Remove(tvoc_8);

                checkBox1.Checked = false;
                checkBox2.Checked = false;
                checkBox3.Checked = false;
                checkBox4.Checked = false;
                checkBox5.Checked = false;
                checkBox6.Checked = false;
                checkBox7.Checked = false;
                checkBox8.Checked = false;
                checkBox10.Checked = false;

                tempChart.Series.Add(temp_avg);
                co2_Chart.Series.Add(co2_avg);
                tvoc_Chart.Series.Add(tvoc_avg);
            }
            else
            {
                tempChart.Series.Remove(temp_avg);
                co2_Chart.Series.Remove(co2_avg);
                tvoc_Chart.Series.Remove(tvoc_avg);
            }
        }

        private void checkBox10_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox10.Checked)
            {
                tempChart.Series.Add(temp_1);
                tempChart.Series.Add(temp_2);
                tempChart.Series.Add(temp_3);
                tempChart.Series.Add(temp_4);
                tempChart.Series.Add(temp_5);
                tempChart.Series.Add(temp_6);
                tempChart.Series.Add(temp_7);
                tempChart.Series.Add(temp_8);

                co2_Chart.Series.Add(co2_1);
                co2_Chart.Series.Add(co2_2);
                co2_Chart.Series.Add(co2_3);
                co2_Chart.Series.Add(co2_4);
                co2_Chart.Series.Add(co2_5);
                co2_Chart.Series.Add(co2_6);
                co2_Chart.Series.Add(co2_7);
                co2_Chart.Series.Add(co2_8);

                tvoc_Chart.Series.Add(tvoc_1);
                tvoc_Chart.Series.Add(tvoc_2);
                tvoc_Chart.Series.Add(tvoc_3);
                tvoc_Chart.Series.Add(tvoc_4);
                tvoc_Chart.Series.Add(tvoc_5);
                tvoc_Chart.Series.Add(tvoc_6);
                tvoc_Chart.Series.Add(tvoc_7);
                tvoc_Chart.Series.Add(tvoc_8);

                checkBox1.Checked = true;
                checkBox2.Checked = true;
                checkBox3.Checked = true;
                checkBox4.Checked = true;
                checkBox5.Checked = true;
                checkBox6.Checked = true;
                checkBox7.Checked = true;
                checkBox8.Checked = true;

                tempChart.Series.Remove(temp_avg);
                co2_Chart.Series.Remove(co2_avg);
                tvoc_Chart.Series.Remove(tvoc_avg);
            }
            else
            {
                tempChart.Series.Remove(temp_1);
                tempChart.Series.Remove(temp_2);
                tempChart.Series.Remove(temp_3);
                tempChart.Series.Remove(temp_4);
                tempChart.Series.Remove(temp_5);
                tempChart.Series.Remove(temp_6);
                tempChart.Series.Remove(temp_7);
                tempChart.Series.Remove(temp_8);

                co2_Chart.Series.Remove(co2_1);
                co2_Chart.Series.Remove(co2_2);
                co2_Chart.Series.Remove(co2_3);
                co2_Chart.Series.Remove(co2_4);
                co2_Chart.Series.Remove(co2_5);
                co2_Chart.Series.Remove(co2_6);
                co2_Chart.Series.Remove(co2_7);
                co2_Chart.Series.Remove(co2_8);

                tvoc_Chart.Series.Remove(tvoc_1);
                tvoc_Chart.Series.Remove(tvoc_2);
                tvoc_Chart.Series.Remove(tvoc_3);
                tvoc_Chart.Series.Remove(tvoc_4);
                tvoc_Chart.Series.Remove(tvoc_5);
                tvoc_Chart.Series.Remove(tvoc_6);
                tvoc_Chart.Series.Remove(tvoc_7);
                tvoc_Chart.Series.Remove(tvoc_8);

                checkBox1.Checked = false;
                checkBox2.Checked = false;
                checkBox3.Checked = false;
                checkBox4.Checked = false;
                checkBox5.Checked = false;
                checkBox6.Checked = false;
                checkBox7.Checked = false;
                checkBox8.Checked = false;
            }
        }

        private void check_All()
        {
            if(checkBox1.Checked && checkBox2.Checked && checkBox3.Checked && checkBox4.Checked && checkBox5.Checked &&
                checkBox6.Checked && checkBox7.Checked && checkBox8.Checked && !checkBox10.Checked)
            {
                checkBox1.Checked = true;
            }
        }

        // This is the method to run when the timer is raised.
        private void TimerEventProcessor_temp(Object myObject, EventArgs myEventArgs)
		{
            if(read_s)
            {
                double temp_ran = Convert.ToDouble(data[0]);
                temp_1.addValue(temp_ran);

                temp_ran = Convert.ToDouble(data[3]);
                temp_2.addValue(temp_ran);

                temp_ran = Convert.ToDouble(data[6]);
                temp_3.addValue(temp_ran);

                temp_ran = Convert.ToDouble(data[9]);
                temp_4.addValue(temp_ran);

                temp_ran = Convert.ToDouble(data[12]);
                temp_5.addValue(temp_ran);

                temp_ran = Convert.ToDouble(data[15]);
                temp_6.addValue(temp_ran);

                temp_ran = Convert.ToDouble(data[18]);
                temp_7.addValue(temp_ran);

                temp_ran = Convert.ToDouble(data[21]);
                temp_8.addValue(temp_ran);

                this.temp_avg.addValue(Convert.ToDouble(data[24]));

                //Console.WriteLine(val);

                if (temp_1.Size > 1)
                {
                    double currVal = temp_1.GetValue(temp_1.Size - 1, 0);

                    if (currVal > tempChart.XAxis.MaxValue)
                    {
                        double span = currVal - temp_1.GetValue(temp_1.Size - 2, 0);
                        tempChart.XAxis.MinValue += span;
                        tempChart.XAxis.MaxValue += span;

                    }
                    tempChart.ChartPanel.InvalidateLayout();
                }
            }			
		}

        // This is the method to run when the timer is raised.
        private void TimerEventProcessor_co2(Object myObject, EventArgs myEventArgs)
        {
            if(read_s)
            {
                double co2_ran = Convert.ToDouble(data[1]);
                co2_1.addValue(co2_ran);

                co2_ran = Convert.ToDouble(data[4]);
                co2_2.addValue(co2_ran);

                co2_ran = Convert.ToDouble(data[7]);
                co2_3.addValue(co2_ran);

                co2_ran = Convert.ToDouble(data[10]);
                co2_4.addValue(co2_ran);

                co2_ran = Convert.ToDouble(data[13]);
                co2_5.addValue(co2_ran);

                co2_ran = Convert.ToDouble(data[16]);
                co2_6.addValue(co2_ran);

                co2_ran = Convert.ToDouble(data[19]);
                co2_7.addValue(co2_ran);

                co2_ran = Convert.ToDouble(data[22]);
                co2_8.addValue(co2_ran);

                this.co2_avg.addValue(Convert.ToDouble(data[25]));

                //Console.WriteLine(val);

                if (co2_1.Size > 1)
                {
                    double currVal = co2_1.GetValue(co2_1.Size - 1, 0);

                    if (currVal > co2_Chart.XAxis.MaxValue)
                    {
                        double span = currVal - co2_1.GetValue(co2_1.Size - 2, 0);
                        co2_Chart.XAxis.MinValue += span;
                        co2_Chart.XAxis.MaxValue += span;

                    }
                    co2_Chart.ChartPanel.InvalidateLayout();
                }
            }
        }

        // This is the method to run when the timer is raised.
        private void TimerEventProcessor_tvoc(Object myObject, EventArgs myEventArgs)
        {
            if(read_s)
            {
                double tvoc_ran = Convert.ToDouble(data[2]);
                tvoc_1.addValue(tvoc_ran);

                tvoc_ran = Convert.ToDouble(data[5]);
                tvoc_2.addValue(tvoc_ran);

                tvoc_ran = Convert.ToDouble(data[8]);
                tvoc_3.addValue(tvoc_ran);

                tvoc_ran = Convert.ToDouble(data[11]);
                tvoc_4.addValue(tvoc_ran);

                tvoc_ran = Convert.ToDouble(data[14]);
                tvoc_5.addValue(tvoc_ran);

                tvoc_ran = Convert.ToDouble(data[17]);
                tvoc_6.addValue(tvoc_ran);

                tvoc_ran = Convert.ToDouble(data[20]);
                tvoc_7.addValue(tvoc_ran);

                tvoc_ran = Convert.ToDouble(data[23]);
                tvoc_8.addValue(tvoc_ran);

                this.tvoc_avg.addValue(Convert.ToDouble(data[26]));

                //Console.WriteLine(val);

                if (tvoc_1.Size > 1)
                {
                    double currVal = tvoc_1.GetValue(tvoc_1.Size - 1, 0);

                    if (currVal > tvoc_Chart.XAxis.MaxValue)
                    {
                        double span = currVal - tvoc_1.GetValue(tvoc_1.Size - 2, 0);
                        tvoc_Chart.XAxis.MinValue += span;
                        tvoc_Chart.XAxis.MaxValue += span;

                    }
                    tvoc_Chart.ChartPanel.InvalidateLayout();
                }
            }
        }

        // *
        private void cc()
        {
            tempChart.Series.Remove(temp_1);
            tempChart.Series.Remove(temp_2);
            tempChart.Series.Remove(temp_3);
            tempChart.Series.Remove(temp_4);
            tempChart.Series.Remove(temp_5);
            tempChart.Series.Remove(temp_6);
            tempChart.Series.Remove(temp_7);
            tempChart.Series.Remove(temp_8);
            tempChart.Series.Remove(temp_avg);

            co2_Chart.Series.Remove(co2_1);
            co2_Chart.Series.Remove(co2_2);
            co2_Chart.Series.Remove(co2_3);
            co2_Chart.Series.Remove(co2_4);
            co2_Chart.Series.Remove(co2_5);
            co2_Chart.Series.Remove(co2_6);
            co2_Chart.Series.Remove(co2_7);
            co2_Chart.Series.Remove(co2_8);
            tempChart.Series.Remove(co2_avg);

            tvoc_Chart.Series.Remove(tvoc_1);
            tvoc_Chart.Series.Remove(tvoc_2);
            tvoc_Chart.Series.Remove(tvoc_3);
            tvoc_Chart.Series.Remove(tvoc_4);
            tvoc_Chart.Series.Remove(tvoc_5);
            tvoc_Chart.Series.Remove(tvoc_6);
            tvoc_Chart.Series.Remove(tvoc_7);
            tvoc_Chart.Series.Remove(tvoc_8);
            tvoc_Chart.Series.Remove(tvoc_avg);

            temp_1.Clear();
            temp_2.Clear();
            temp_3.Clear();
            temp_4.Clear();
            temp_5.Clear();
            temp_6.Clear();
            temp_7.Clear();
            temp_8.Clear();
            temp_avg.Clear();

            co2_1.Clear();
            co2_2.Clear();
            co2_3.Clear();
            co2_4.Clear();
            co2_5.Clear();
            co2_6.Clear();
            co2_7.Clear();
            co2_8.Clear();
            co2_avg.Clear();

            tvoc_1.Clear();
            tvoc_2.Clear();
            tvoc_3.Clear();
            tvoc_4.Clear();
            tvoc_5.Clear();
            tvoc_6.Clear();
            tvoc_7.Clear();
            tvoc_8.Clear();
            tvoc_avg.Clear();

            checkBox1.Enabled = false;
            checkBox2.Enabled = false;
            checkBox3.Enabled = false;
            checkBox4.Enabled = false;
            checkBox5.Enabled = false;
            checkBox6.Enabled = false;
            checkBox7.Enabled = false;
            checkBox8.Enabled = false;
            checkBox9.Enabled = false;
            checkBox10.Enabled = false;
        }
    }
}
