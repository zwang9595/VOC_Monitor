
namespace Test1
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.Connect = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.checkBox5 = new System.Windows.Forms.CheckBox();
            this.checkBox6 = new System.Windows.Forms.CheckBox();
            this.checkBox7 = new System.Windows.Forms.CheckBox();
            this.checkBox8 = new System.Windows.Forms.CheckBox();
            this.tempChart = new MindFusion.Charting.WinForms.LineChart();
            this.co2_Chart = new MindFusion.Charting.WinForms.LineChart();
            this.tvoc_Chart = new MindFusion.Charting.WinForms.LineChart();
            this.checkBox9 = new System.Windows.Forms.CheckBox();
            this.comBox = new System.Windows.Forms.TextBox();
            this.receive = new System.Windows.Forms.TextBox();
            this.checkBox10 = new System.Windows.Forms.CheckBox();
            this.menuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Location = new System.Drawing.Point(0, 28);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1902, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuStrip2
            // 
            this.menuStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Connect,
            this.toolStripMenuItem1});
            this.menuStrip2.Location = new System.Drawing.Point(0, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Size = new System.Drawing.Size(1902, 28);
            this.menuStrip2.TabIndex = 1;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // Connect
            // 
            this.Connect.Name = "Connect";
            this.Connect.Size = new System.Drawing.Size(84, 24);
            this.Connect.Text = "Connect";
            this.Connect.Click += new System.EventHandler(this.Connect_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(60, 24);
            this.toolStripMenuItem1.Text = "Clear";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(12, 33);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(85, 19);
            this.checkBox1.TabIndex = 2;
            this.checkBox1.Text = "Sensor1";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(103, 33);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(85, 19);
            this.checkBox2.TabIndex = 3;
            this.checkBox2.Text = "Sensor2";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(194, 33);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(85, 19);
            this.checkBox3.TabIndex = 4;
            this.checkBox3.Text = "Sensor3";
            this.checkBox3.UseVisualStyleBackColor = true;
            this.checkBox3.CheckedChanged += new System.EventHandler(this.checkBox3_CheckedChanged);
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Location = new System.Drawing.Point(285, 33);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(85, 19);
            this.checkBox4.TabIndex = 5;
            this.checkBox4.Text = "Sensor4";
            this.checkBox4.UseVisualStyleBackColor = true;
            this.checkBox4.CheckedChanged += new System.EventHandler(this.checkBox4_CheckedChanged);
            // 
            // checkBox5
            // 
            this.checkBox5.AutoSize = true;
            this.checkBox5.Location = new System.Drawing.Point(376, 33);
            this.checkBox5.Name = "checkBox5";
            this.checkBox5.Size = new System.Drawing.Size(85, 19);
            this.checkBox5.TabIndex = 6;
            this.checkBox5.Text = "Sensor5";
            this.checkBox5.UseVisualStyleBackColor = true;
            this.checkBox5.CheckedChanged += new System.EventHandler(this.checkBox5_CheckedChanged);
            // 
            // checkBox6
            // 
            this.checkBox6.AutoSize = true;
            this.checkBox6.Location = new System.Drawing.Point(467, 33);
            this.checkBox6.Name = "checkBox6";
            this.checkBox6.Size = new System.Drawing.Size(85, 19);
            this.checkBox6.TabIndex = 7;
            this.checkBox6.Text = "Sensor6";
            this.checkBox6.UseVisualStyleBackColor = true;
            this.checkBox6.CheckedChanged += new System.EventHandler(this.checkBox6_CheckedChanged);
            // 
            // checkBox7
            // 
            this.checkBox7.AutoSize = true;
            this.checkBox7.Location = new System.Drawing.Point(558, 33);
            this.checkBox7.Name = "checkBox7";
            this.checkBox7.Size = new System.Drawing.Size(85, 19);
            this.checkBox7.TabIndex = 8;
            this.checkBox7.Text = "Sensor7";
            this.checkBox7.UseVisualStyleBackColor = true;
            this.checkBox7.CheckedChanged += new System.EventHandler(this.checkBox7_CheckedChanged);
            // 
            // checkBox8
            // 
            this.checkBox8.AutoSize = true;
            this.checkBox8.Location = new System.Drawing.Point(649, 33);
            this.checkBox8.Name = "checkBox8";
            this.checkBox8.Size = new System.Drawing.Size(85, 19);
            this.checkBox8.TabIndex = 9;
            this.checkBox8.Text = "Sensor8";
            this.checkBox8.UseVisualStyleBackColor = true;
            this.checkBox8.CheckedChanged += new System.EventHandler(this.checkBox8_CheckedChanged);
            // 
            // tempChart
            // 
            this.tempChart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tempChart.LegendTitle = "Legend";
            this.tempChart.Location = new System.Drawing.Point(13, 67);
            this.tempChart.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tempChart.Name = "tempChart";
            this.tempChart.Padding = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.tempChart.ShowLegend = true;
            this.tempChart.Size = new System.Drawing.Size(900, 450);
            this.tempChart.SubtitleFontName = null;
            this.tempChart.SubtitleFontSize = null;
            this.tempChart.SubtitleFontStyle = null;
            this.tempChart.TabIndex = 10;
            this.tempChart.Text = "lineChart";
            this.tempChart.Theme.UniformSeriesFill = new MindFusion.Drawing.SolidBrush("#FF90EE90");
            this.tempChart.Theme.UniformSeriesStroke = new MindFusion.Drawing.SolidBrush("#FF000000");
            this.tempChart.Theme.UniformSeriesStrokeThickness = 2D;
            this.tempChart.TitleFontName = null;
            this.tempChart.TitleFontSize = null;
            this.tempChart.TitleFontStyle = null;
            // 
            // co2_Chart
            // 
            this.co2_Chart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.co2_Chart.LegendTitle = "Legend";
            this.co2_Chart.Location = new System.Drawing.Point(989, 67);
            this.co2_Chart.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.co2_Chart.Name = "co2_Chart";
            this.co2_Chart.Padding = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.co2_Chart.ShowLegend = true;
            this.co2_Chart.Size = new System.Drawing.Size(900, 450);
            this.co2_Chart.SubtitleFontName = null;
            this.co2_Chart.SubtitleFontSize = null;
            this.co2_Chart.SubtitleFontStyle = null;
            this.co2_Chart.TabIndex = 11;
            this.co2_Chart.Text = "lineChart1";
            this.co2_Chart.Theme.UniformSeriesFill = new MindFusion.Drawing.SolidBrush("#FF90EE90");
            this.co2_Chart.Theme.UniformSeriesStroke = new MindFusion.Drawing.SolidBrush("#FF000000");
            this.co2_Chart.Theme.UniformSeriesStrokeThickness = 2D;
            this.co2_Chart.TitleFontName = null;
            this.co2_Chart.TitleFontSize = null;
            this.co2_Chart.TitleFontStyle = null;
            // 
            // tvoc_Chart
            // 
            this.tvoc_Chart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tvoc_Chart.LegendTitle = "Legend";
            this.tvoc_Chart.Location = new System.Drawing.Point(497, 571);
            this.tvoc_Chart.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tvoc_Chart.Name = "tvoc_Chart";
            this.tvoc_Chart.Padding = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.tvoc_Chart.ShowLegend = true;
            this.tvoc_Chart.Size = new System.Drawing.Size(900, 450);
            this.tvoc_Chart.SubtitleFontName = null;
            this.tvoc_Chart.SubtitleFontSize = null;
            this.tvoc_Chart.SubtitleFontStyle = null;
            this.tvoc_Chart.TabIndex = 12;
            this.tvoc_Chart.Text = "lineChart2";
            this.tvoc_Chart.Theme.UniformSeriesFill = new MindFusion.Drawing.SolidBrush("#FF90EE90");
            this.tvoc_Chart.Theme.UniformSeriesStroke = new MindFusion.Drawing.SolidBrush("#FF000000");
            this.tvoc_Chart.Theme.UniformSeriesStrokeThickness = 2D;
            this.tvoc_Chart.TitleFontName = null;
            this.tvoc_Chart.TitleFontSize = null;
            this.tvoc_Chart.TitleFontStyle = null;
            // 
            // checkBox9
            // 
            this.checkBox9.AutoSize = true;
            this.checkBox9.Location = new System.Drawing.Point(740, 33);
            this.checkBox9.Name = "checkBox9";
            this.checkBox9.Size = new System.Drawing.Size(85, 19);
            this.checkBox9.TabIndex = 13;
            this.checkBox9.Text = "Average";
            this.checkBox9.UseVisualStyleBackColor = true;
            this.checkBox9.CheckedChanged += new System.EventHandler(this.checkBox9_CheckedChanged);
            // 
            // comBox
            // 
            this.comBox.Location = new System.Drawing.Point(1790, 27);
            this.comBox.Name = "comBox";
            this.comBox.Size = new System.Drawing.Size(112, 25);
            this.comBox.TabIndex = 14;
            // 
            // receive
            // 
            this.receive.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.receive.Location = new System.Drawing.Point(887, 27);
            this.receive.Name = "receive";
            this.receive.Size = new System.Drawing.Size(897, 25);
            this.receive.TabIndex = 15;
            // 
            // checkBox10
            // 
            this.checkBox10.AutoSize = true;
            this.checkBox10.Location = new System.Drawing.Point(828, 33);
            this.checkBox10.Name = "checkBox10";
            this.checkBox10.Size = new System.Drawing.Size(53, 19);
            this.checkBox10.TabIndex = 16;
            this.checkBox10.Text = "All";
            this.checkBox10.UseVisualStyleBackColor = true;
            this.checkBox10.CheckedChanged += new System.EventHandler(this.checkBox10_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1902, 1033);
            this.Controls.Add(this.checkBox10);
            this.Controls.Add(this.receive);
            this.Controls.Add(this.comBox);
            this.Controls.Add(this.checkBox9);
            this.Controls.Add(this.tvoc_Chart);
            this.Controls.Add(this.co2_Chart);
            this.Controls.Add(this.tempChart);
            this.Controls.Add(this.checkBox8);
            this.Controls.Add(this.checkBox7);
            this.Controls.Add(this.checkBox6);
            this.Controls.Add(this.checkBox5);
            this.Controls.Add(this.checkBox4);
            this.Controls.Add(this.checkBox3);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.menuStrip2);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "SGP30 Monitor";
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripMenuItem Connect;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.CheckBox checkBox5;
        private System.Windows.Forms.CheckBox checkBox6;
        private System.Windows.Forms.CheckBox checkBox7;
        private System.Windows.Forms.CheckBox checkBox8;
        private MindFusion.Charting.WinForms.LineChart tempChart;
        private MindFusion.Charting.WinForms.LineChart co2_Chart;
        private MindFusion.Charting.WinForms.LineChart tvoc_Chart;
        private System.Windows.Forms.CheckBox checkBox9;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.TextBox comBox;
        private System.Windows.Forms.TextBox receive;
        private System.Windows.Forms.CheckBox checkBox10;
    }
}

