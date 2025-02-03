namespace SNOS.SC_1080.Monitor
{
    partial class Monitor
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
            CodeArtEng.Gauge.Themes.ThemeColors themeColors1 = new CodeArtEng.Gauge.Themes.ThemeColors();
            CodeArtEng.Gauge.Themes.ThemeColors themeColors2 = new CodeArtEng.Gauge.Themes.ThemeColors();
            CodeArtEng.Gauge.Themes.ThemeColors themeColors3 = new CodeArtEng.Gauge.Themes.ThemeColors();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Monitor));
            this.Close = new System.Windows.Forms.Button();
            this.btn_Back = new System.Windows.Forms.Button();
            this.MC4 = new System.Windows.Forms.Button();
            this.MC3 = new System.Windows.Forms.Button();
            this.Coiltype = new System.Windows.Forms.Label();
            this.Line_Sp = new System.Windows.Forms.Label();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.btn_Next = new System.Windows.Forms.Button();
            this.Now_Time = new System.Windows.Forms.Label();
            this.Auto = new System.Windows.Forms.Label();
            this.Mode = new System.Windows.Forms.Button();
            this.MC2 = new System.Windows.Forms.Button();
            this.MC1 = new System.Windows.Forms.Button();
            this.result_lable = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.MC_Name = new System.Windows.Forms.Label();
            this.LineSpeedCaption = new System.Windows.Forms.Label();
            this.Results = new CodeArtEng.Gauge.CircularGauge();
            this.Latest_worktimeLabel = new System.Windows.Forms.Label();
            this.Plan = new CodeArtEng.Gauge.CircularGauge();
            this.StopMinLabel = new System.Windows.Forms.Label();
            this.StartTimeCaption = new System.Windows.Forms.Label();
            this.PowOnMinLabel = new System.Windows.Forms.Label();
            this.StopCaption = new System.Windows.Forms.Label();
            this.AlertLabel = new System.Windows.Forms.Label();
            this.PowOnDateLabel = new System.Windows.Forms.Label();
            this.StatusCaption = new System.Windows.Forms.Label();
            this.RunMinLabel = new System.Windows.Forms.Label();
            this.StopDayLabel = new System.Windows.Forms.Label();
            this.RunDayLabel = new System.Windows.Forms.Label();
            this.RunCaption = new System.Windows.Forms.Label();
            this.StatusLabel = new System.Windows.Forms.Label();
            this.Error_Message = new System.Windows.Forms.Label();
            this.Length = new CodeArtEng.Gauge.CircularGauge();
            this.Thick = new CodeArtEng.Gauge.RectangleIndicator();
            this.Linespeed = new CodeArtEng.Gauge.LinearGauge();
            this.Workrate = new CodeArtEng.Gauge.CircularGauge();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.PowOnCaption = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.last_size = new System.Windows.Forms.Label();
            this.Rest_PLst = new System.Windows.Forms.Label();
            this.Recoiler_Status = new System.Windows.Forms.PictureBox();
            this.CS_name = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.Recoiler_Status)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // Close
            // 
            this.Close.BackColor = System.Drawing.Color.Black;
            this.Close.Font = new System.Drawing.Font("Microsoft Sans Serif", 32F);
            this.Close.ForeColor = System.Drawing.Color.Lime;
            this.Close.Location = new System.Drawing.Point(1622, 120);
            this.Close.Name = "Close";
            this.Close.Size = new System.Drawing.Size(250, 80);
            this.Close.TabIndex = 0;
            this.Close.Text = "Close";
            this.Close.UseVisualStyleBackColor = false;
            this.Close.Click += new System.EventHandler(this.Close_Click);
            // 
            // btn_Back
            // 
            this.btn_Back.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btn_Back.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F);
            this.btn_Back.ForeColor = System.Drawing.Color.Lime;
            this.btn_Back.Location = new System.Drawing.Point(506, 980);
            this.btn_Back.Name = "btn_Back";
            this.btn_Back.Size = new System.Drawing.Size(80, 80);
            this.btn_Back.TabIndex = 130;
            this.btn_Back.Text = "<";
            this.btn_Back.UseVisualStyleBackColor = false;
            this.btn_Back.Click += new System.EventHandler(this.btn_Back_Click);
            // 
            // MC4
            // 
            this.MC4.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.MC4.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F);
            this.MC4.ForeColor = System.Drawing.Color.Lime;
            this.MC4.Location = new System.Drawing.Point(1516, 980);
            this.MC4.Name = "MC4";
            this.MC4.Size = new System.Drawing.Size(255, 80);
            this.MC4.TabIndex = 128;
            this.MC4.Text = "MC4";
            this.MC4.UseVisualStyleBackColor = false;
            this.MC4.Click += new System.EventHandler(this.MC4_Click);
            // 
            // MC3
            // 
            this.MC3.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.MC3.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F);
            this.MC3.ForeColor = System.Drawing.Color.Lime;
            this.MC3.Location = new System.Drawing.Point(1213, 980);
            this.MC3.Name = "MC3";
            this.MC3.Size = new System.Drawing.Size(255, 80);
            this.MC3.TabIndex = 127;
            this.MC3.Text = "MC3";
            this.MC3.UseVisualStyleBackColor = false;
            this.MC3.Click += new System.EventHandler(this.MC3_Click);
            // 
            // Coiltype
            // 
            this.Coiltype.BackColor = System.Drawing.Color.Transparent;
            this.Coiltype.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Coiltype.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.Coiltype.ForeColor = System.Drawing.Color.Aqua;
            this.Coiltype.Location = new System.Drawing.Point(50, 404);
            this.Coiltype.Name = "Coiltype";
            this.Coiltype.Size = new System.Drawing.Size(251, 43);
            this.Coiltype.TabIndex = 126;
            this.Coiltype.Text = "Master Coil";
            this.Coiltype.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Line_Sp
            // 
            this.Line_Sp.BackColor = System.Drawing.Color.Transparent;
            this.Line_Sp.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Line_Sp.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Line_Sp.ForeColor = System.Drawing.Color.Aqua;
            this.Line_Sp.Location = new System.Drawing.Point(303, 837);
            this.Line_Sp.Name = "Line_Sp";
            this.Line_Sp.Size = new System.Drawing.Size(250, 86);
            this.Line_Sp.TabIndex = 124;
            this.Line_Sp.Text = "120 m/min";
            this.Line_Sp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timer2
            // 
            this.timer2.Interval = 15000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // btn_Next
            // 
            this.btn_Next.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btn_Next.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F);
            this.btn_Next.ForeColor = System.Drawing.Color.Lime;
            this.btn_Next.Location = new System.Drawing.Point(1799, 980);
            this.btn_Next.Name = "btn_Next";
            this.btn_Next.Size = new System.Drawing.Size(80, 80);
            this.btn_Next.TabIndex = 129;
            this.btn_Next.Text = ">";
            this.btn_Next.UseVisualStyleBackColor = false;
            this.btn_Next.Click += new System.EventHandler(this.btn_Next_Click);
            // 
            // Now_Time
            // 
            this.Now_Time.BackColor = System.Drawing.Color.Transparent;
            this.Now_Time.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Now_Time.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F);
            this.Now_Time.ForeColor = System.Drawing.Color.Aqua;
            this.Now_Time.Location = new System.Drawing.Point(1207, 120);
            this.Now_Time.Name = "Now_Time";
            this.Now_Time.Size = new System.Drawing.Size(409, 80);
            this.Now_Time.TabIndex = 123;
            this.Now_Time.Text = "dd/MM/yyyy HH:mm:ss";
            this.Now_Time.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Auto
            // 
            this.Auto.BackColor = System.Drawing.Color.Transparent;
            this.Auto.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Auto.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F);
            this.Auto.ForeColor = System.Drawing.Color.Lime;
            this.Auto.Location = new System.Drawing.Point(265, 984);
            this.Auto.Name = "Auto";
            this.Auto.Size = new System.Drawing.Size(216, 68);
            this.Auto.TabIndex = 122;
            this.Auto.Text = "Auto";
            this.Auto.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Auto.Click += new System.EventHandler(this.Auto_Click);
            // 
            // Mode
            // 
            this.Mode.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Mode.Font = new System.Drawing.Font("Microsoft Sans Serif", 40F);
            this.Mode.ForeColor = System.Drawing.Color.Lime;
            this.Mode.Location = new System.Drawing.Point(50, 984);
            this.Mode.Name = "Mode";
            this.Mode.Size = new System.Drawing.Size(216, 70);
            this.Mode.TabIndex = 121;
            this.Mode.Text = "Mode";
            this.Mode.UseVisualStyleBackColor = false;
            this.Mode.Click += new System.EventHandler(this.Mode_Click);
            // 
            // MC2
            // 
            this.MC2.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.MC2.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F);
            this.MC2.ForeColor = System.Drawing.Color.Lime;
            this.MC2.Location = new System.Drawing.Point(909, 980);
            this.MC2.Name = "MC2";
            this.MC2.Size = new System.Drawing.Size(255, 80);
            this.MC2.TabIndex = 120;
            this.MC2.Text = "LV-1";
            this.MC2.UseVisualStyleBackColor = false;
            this.MC2.Click += new System.EventHandler(this.MC2_Click);
            // 
            // MC1
            // 
            this.MC1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.MC1.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F);
            this.MC1.ForeColor = System.Drawing.Color.Lime;
            this.MC1.Location = new System.Drawing.Point(609, 980);
            this.MC1.Name = "MC1";
            this.MC1.Size = new System.Drawing.Size(255, 80);
            this.MC1.TabIndex = 118;
            this.MC1.Text = "SL-1";
            this.MC1.UseVisualStyleBackColor = false;
            this.MC1.Click += new System.EventHandler(this.MC1_Click);
            // 
            // result_lable
            // 
            this.result_lable.BackColor = System.Drawing.Color.Transparent;
            this.result_lable.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.result_lable.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.result_lable.ForeColor = System.Drawing.Color.White;
            this.result_lable.Location = new System.Drawing.Point(730, 404);
            this.result_lable.Name = "result_lable";
            this.result_lable.Size = new System.Drawing.Size(239, 43);
            this.result_lable.TabIndex = 117;
            this.result_lable.Text = "Number Of Cut";
            this.result_lable.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F);
            this.label7.ForeColor = System.Drawing.Color.Lime;
            this.label7.Location = new System.Drawing.Point(0, 950);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(1920, 10);
            this.label7.TabIndex = 116;
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MC_Name
            // 
            this.MC_Name.BackColor = System.Drawing.Color.Transparent;
            this.MC_Name.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.MC_Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 70F);
            this.MC_Name.ForeColor = System.Drawing.Color.Lime;
            this.MC_Name.Location = new System.Drawing.Point(786, 120);
            this.MC_Name.Name = "MC_Name";
            this.MC_Name.Size = new System.Drawing.Size(352, 168);
            this.MC_Name.TabIndex = 115;
            this.MC_Name.Text = "SL-01";
            this.MC_Name.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LineSpeedCaption
            // 
            this.LineSpeedCaption.BackColor = System.Drawing.Color.Transparent;
            this.LineSpeedCaption.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.LineSpeedCaption.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.LineSpeedCaption.ForeColor = System.Drawing.Color.Lime;
            this.LineSpeedCaption.Location = new System.Drawing.Point(50, 837);
            this.LineSpeedCaption.Name = "LineSpeedCaption";
            this.LineSpeedCaption.Size = new System.Drawing.Size(251, 86);
            this.LineSpeedCaption.TabIndex = 114;
            this.LineSpeedCaption.Text = "Line Speed\n(m/min)";
            this.LineSpeedCaption.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Results
            // 
            this.Results.AnimationEnabled = false;
            this.Results.ErrorLimit = 300D;
            this.Results.Font = new System.Drawing.Font("Microsoft Sans Serif", 35F);
            this.Results.FontTitle = new System.Drawing.Font("Arial", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Results.FontUnitLabel = new System.Drawing.Font("Arial", 23F);
            this.Results.GaugePanelPadding = 3;
            this.Results.Location = new System.Drawing.Point(878, 553);
            this.Results.Margin = new System.Windows.Forms.Padding(6);
            this.Results.Maximum = 1000D;
            this.Results.Name = "Results";
            this.Results.PointerWidth = 12;
            this.Results.ResetValue = 0D;
            this.Results.ScaleFactor = 1D;
            this.Results.Size = new System.Drawing.Size(260, 260);
            this.Results.TabIndex = 113;
            this.Results.Theme = CodeArtEng.Gauge.GaugeTheme.Dark;
            this.Results.Title = "";
            this.Results.Unit = "Results\n(m)";
            this.Results.UserDefinedColors.Base = themeColors1;
            themeColors2.PointerColor = System.Drawing.Color.Red;
            this.Results.UserDefinedColors.Error = themeColors2;
            themeColors3.PointerColor = System.Drawing.Color.Orange;
            this.Results.UserDefinedColors.Warning = themeColors3;
            this.Results.Value = 500D;
            this.Results.WarningLimit = 500D;
            // 
            // Latest_worktimeLabel
            // 
            this.Latest_worktimeLabel.BackColor = System.Drawing.Color.Transparent;
            this.Latest_worktimeLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Latest_worktimeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F);
            this.Latest_worktimeLabel.ForeColor = System.Drawing.Color.Aqua;
            this.Latest_worktimeLabel.Location = new System.Drawing.Point(337, 219);
            this.Latest_worktimeLabel.Name = "Latest_worktimeLabel";
            this.Latest_worktimeLabel.Size = new System.Drawing.Size(200, 69);
            this.Latest_worktimeLabel.TabIndex = 101;
            this.Latest_worktimeLabel.Text = "0 min.";
            this.Latest_worktimeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Plan
            // 
            this.Plan.AnimationEnabled = false;
            this.Plan.ErrorLimit = 300D;
            this.Plan.Font = new System.Drawing.Font("Microsoft Sans Serif", 35F);
            this.Plan.FontTitle = new System.Drawing.Font("Arial", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Plan.FontUnitLabel = new System.Drawing.Font("Arial", 23F);
            this.Plan.GaugePanelPadding = 3;
            this.Plan.Location = new System.Drawing.Point(551, 553);
            this.Plan.Margin = new System.Windows.Forms.Padding(6);
            this.Plan.Maximum = 1000D;
            this.Plan.Name = "Plan";
            this.Plan.PointerWidth = 12;
            this.Plan.ResetValue = 0D;
            this.Plan.ScaleFactor = 1D;
            this.Plan.Size = new System.Drawing.Size(260, 260);
            this.Plan.TabIndex = 112;
            this.Plan.Theme = CodeArtEng.Gauge.GaugeTheme.Dark;
            this.Plan.Title = "";
            this.Plan.Unit = "Plan\n(m)";
            this.Plan.Value = 1D;
            this.Plan.WarningLimit = 500D;
            // 
            // StopMinLabel
            // 
            this.StopMinLabel.BackColor = System.Drawing.Color.Transparent;
            this.StopMinLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.StopMinLabel.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StopMinLabel.ForeColor = System.Drawing.Color.Aqua;
            this.StopMinLabel.Location = new System.Drawing.Point(1651, 321);
            this.StopMinLabel.Name = "StopMinLabel";
            this.StopMinLabel.Size = new System.Drawing.Size(220, 40);
            this.StopMinLabel.TabIndex = 111;
            this.StopMinLabel.Text = "0 min.";
            this.StopMinLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // StartTimeCaption
            // 
            this.StartTimeCaption.BackColor = System.Drawing.Color.Transparent;
            this.StartTimeCaption.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.StartTimeCaption.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold);
            this.StartTimeCaption.ForeColor = System.Drawing.Color.Lime;
            this.StartTimeCaption.Location = new System.Drawing.Point(50, 219);
            this.StartTimeCaption.Name = "StartTimeCaption";
            this.StartTimeCaption.Size = new System.Drawing.Size(287, 69);
            this.StartTimeCaption.TabIndex = 100;
            this.StartTimeCaption.Text = "Latest work time";
            this.StartTimeCaption.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PowOnMinLabel
            // 
            this.PowOnMinLabel.BackColor = System.Drawing.Color.Transparent;
            this.PowOnMinLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PowOnMinLabel.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PowOnMinLabel.ForeColor = System.Drawing.Color.Aqua;
            this.PowOnMinLabel.Location = new System.Drawing.Point(1651, 213);
            this.PowOnMinLabel.Name = "PowOnMinLabel";
            this.PowOnMinLabel.Size = new System.Drawing.Size(220, 40);
            this.PowOnMinLabel.TabIndex = 110;
            this.PowOnMinLabel.Text = "0 min.";
            this.PowOnMinLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // StopCaption
            // 
            this.StopCaption.BackColor = System.Drawing.Color.Transparent;
            this.StopCaption.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.StopCaption.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StopCaption.ForeColor = System.Drawing.Color.Lime;
            this.StopCaption.Location = new System.Drawing.Point(1208, 321);
            this.StopCaption.Name = "StopCaption";
            this.StopCaption.Size = new System.Drawing.Size(223, 40);
            this.StopCaption.TabIndex = 102;
            this.StopCaption.Text = "Stop time";
            this.StopCaption.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // AlertLabel
            // 
            this.AlertLabel.BackColor = System.Drawing.Color.Yellow;
            this.AlertLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.AlertLabel.Font = new System.Drawing.Font("Arial", 25F, System.Drawing.FontStyle.Bold);
            this.AlertLabel.ForeColor = System.Drawing.Color.Red;
            this.AlertLabel.Location = new System.Drawing.Point(50, 310);
            this.AlertLabel.Name = "AlertLabel";
            this.AlertLabel.Size = new System.Drawing.Size(287, 63);
            this.AlertLabel.TabIndex = 103;
            this.AlertLabel.Text = "Alert";
            this.AlertLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.AlertLabel.Visible = false;
            // 
            // PowOnDateLabel
            // 
            this.PowOnDateLabel.BackColor = System.Drawing.Color.Transparent;
            this.PowOnDateLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PowOnDateLabel.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PowOnDateLabel.ForeColor = System.Drawing.Color.Aqua;
            this.PowOnDateLabel.Location = new System.Drawing.Point(1431, 213);
            this.PowOnDateLabel.Name = "PowOnDateLabel";
            this.PowOnDateLabel.Size = new System.Drawing.Size(220, 40);
            this.PowOnDateLabel.TabIndex = 106;
            this.PowOnDateLabel.Text = "0h 0m 0s";
            this.PowOnDateLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // StatusCaption
            // 
            this.StatusCaption.BackColor = System.Drawing.Color.Transparent;
            this.StatusCaption.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.StatusCaption.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StatusCaption.ForeColor = System.Drawing.Color.Lime;
            this.StatusCaption.Location = new System.Drawing.Point(50, 120);
            this.StatusCaption.Name = "StatusCaption";
            this.StatusCaption.Size = new System.Drawing.Size(287, 80);
            this.StatusCaption.TabIndex = 98;
            this.StatusCaption.Text = "Current Status";
            this.StatusCaption.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // RunMinLabel
            // 
            this.RunMinLabel.BackColor = System.Drawing.Color.Transparent;
            this.RunMinLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.RunMinLabel.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RunMinLabel.ForeColor = System.Drawing.Color.Aqua;
            this.RunMinLabel.Location = new System.Drawing.Point(1651, 268);
            this.RunMinLabel.Name = "RunMinLabel";
            this.RunMinLabel.Size = new System.Drawing.Size(220, 40);
            this.RunMinLabel.TabIndex = 109;
            this.RunMinLabel.Text = "0 min.";
            this.RunMinLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // StopDayLabel
            // 
            this.StopDayLabel.BackColor = System.Drawing.Color.Transparent;
            this.StopDayLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.StopDayLabel.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StopDayLabel.ForeColor = System.Drawing.Color.Aqua;
            this.StopDayLabel.Location = new System.Drawing.Point(1431, 321);
            this.StopDayLabel.Name = "StopDayLabel";
            this.StopDayLabel.Size = new System.Drawing.Size(220, 40);
            this.StopDayLabel.TabIndex = 107;
            this.StopDayLabel.Text = "0h 0m 0s";
            this.StopDayLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // RunDayLabel
            // 
            this.RunDayLabel.BackColor = System.Drawing.Color.Transparent;
            this.RunDayLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.RunDayLabel.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RunDayLabel.ForeColor = System.Drawing.Color.Aqua;
            this.RunDayLabel.Location = new System.Drawing.Point(1431, 268);
            this.RunDayLabel.Name = "RunDayLabel";
            this.RunDayLabel.Size = new System.Drawing.Size(220, 40);
            this.RunDayLabel.TabIndex = 108;
            this.RunDayLabel.Text = "0h 0m 0s";
            this.RunDayLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // RunCaption
            // 
            this.RunCaption.BackColor = System.Drawing.Color.Transparent;
            this.RunCaption.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.RunCaption.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RunCaption.ForeColor = System.Drawing.Color.Lime;
            this.RunCaption.Location = new System.Drawing.Point(1208, 268);
            this.RunCaption.Name = "RunCaption";
            this.RunCaption.Size = new System.Drawing.Size(223, 40);
            this.RunCaption.TabIndex = 104;
            this.RunCaption.Text = "Auto Run time";
            this.RunCaption.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // StatusLabel
            // 
            this.StatusLabel.BackColor = System.Drawing.Color.Green;
            this.StatusLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.StatusLabel.Font = new System.Drawing.Font("Arial", 45F);
            this.StatusLabel.ForeColor = System.Drawing.Color.White;
            this.StatusLabel.Location = new System.Drawing.Point(337, 120);
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(429, 80);
            this.StatusLabel.TabIndex = 99;
            this.StatusLabel.Text = "Status";
            this.StatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Error_Message
            // 
            this.Error_Message.BackColor = System.Drawing.Color.Transparent;
            this.Error_Message.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Error_Message.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.Error_Message.ForeColor = System.Drawing.Color.Yellow;
            this.Error_Message.Location = new System.Drawing.Point(338, 310);
            this.Error_Message.Name = "Error_Message";
            this.Error_Message.Size = new System.Drawing.Size(802, 63);
            this.Error_Message.TabIndex = 97;
            this.Error_Message.Text = "Error Message";
            this.Error_Message.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Error_Message.Visible = false;
            // 
            // Length
            // 
            this.Length.AnimationEnabled = false;
            this.Length.ErrorLimit = double.NaN;
            this.Length.Font = new System.Drawing.Font("Microsoft Sans Serif", 35F);
            this.Length.FontTitle = new System.Drawing.Font("Arial", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Length.FontUnitLabel = new System.Drawing.Font("Arial", 23F);
            this.Length.Location = new System.Drawing.Point(50, 553);
            this.Length.Margin = new System.Windows.Forms.Padding(6);
            this.Length.Maximum = 1000D;
            this.Length.Name = "Length";
            this.Length.PointerWidth = 12;
            this.Length.ResetValue = 0D;
            this.Length.ScaleFactor = 1D;
            this.Length.Size = new System.Drawing.Size(251, 260);
            this.Length.TabIndex = 96;
            this.Length.Theme = CodeArtEng.Gauge.GaugeTheme.Dark;
            this.Length.Title = "";
            this.Length.Unit = "Length\n(m)";
            this.Length.Value = 1000D;
            this.Length.WarningLimit = double.NaN;
            // 
            // Thick
            // 
            this.Thick.AnimationEnabled = false;
            this.Thick.CornerSize = 30;
            this.Thick.DrawStyle = CodeArtEng.Gauge.RectangleIndicatorDrawStyle.RoundedRectangle;
            this.Thick.ErrorLimit = 2D;
            this.Thick.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F);
            this.Thick.FontTitle = new System.Drawing.Font("Arial", 25F);
            this.Thick.FontUnitLabel = new System.Drawing.Font("Arial", 22F);
            this.Thick.Location = new System.Drawing.Point(50, 460);
            this.Thick.Maximum = 20D;
            this.Thick.Name = "Thick";
            this.Thick.ResetValue = 0D;
            this.Thick.ScaleFactor = 1D;
            this.Thick.Size = new System.Drawing.Size(251, 93);
            this.Thick.TabIndex = 94;
            this.Thick.Theme = CodeArtEng.Gauge.GaugeTheme.Dark;
            this.Thick.Title = "";
            this.Thick.Unit = "Thickness (mm)";
            this.Thick.Value = 1.1D;
            this.Thick.WarningLimit = 1D;
            // 
            // Linespeed
            // 
            this.Linespeed.AnimationEnabled = false;
            this.Linespeed.BottomBarHeight = 0;
            this.Linespeed.ErrorLimit = double.NaN;
            this.Linespeed.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F);
            this.Linespeed.InvertLimit = true;
            this.Linespeed.LabelWidth = 90;
            this.Linespeed.Location = new System.Drawing.Point(551, 837);
            this.Linespeed.Maximum = 160D;
            this.Linespeed.Name = "Linespeed";
            this.Linespeed.ResetValue = 0D;
            this.Linespeed.ScaleFactor = 1D;
            this.Linespeed.SegmentGap = 5;
            this.Linespeed.SegmentSize = 5;
            this.Linespeed.Size = new System.Drawing.Size(587, 86);
            this.Linespeed.TabIndex = 93;
            this.Linespeed.Theme = CodeArtEng.Gauge.GaugeTheme.Light_Dark_Background;
            this.Linespeed.Title = "";
            this.Linespeed.Unit = "m/min";
            this.Linespeed.Value = 160D;
            this.Linespeed.WarningLimit = 30D;
            // 
            // Workrate
            // 
            this.Workrate.AnimationEnabled = false;
            this.Workrate.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Workrate.ErrorLimit = 40D;
            this.Workrate.Font = new System.Drawing.Font("Microsoft Sans Serif", 45F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Workrate.FontTitle = new System.Drawing.Font("Arial", 45F);
            this.Workrate.FontUnitLabel = new System.Drawing.Font("Arial", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Workrate.InvertLimit = true;
            this.Workrate.Location = new System.Drawing.Point(1297, 423);
            this.Workrate.Margin = new System.Windows.Forms.Padding(6);
            this.Workrate.Maximum = 100D;
            this.Workrate.Name = "Workrate";
            this.Workrate.PointerWidth = 45;
            this.Workrate.ResetValue = 0D;
            this.Workrate.ScaleFactor = 1D;
            this.Workrate.Size = new System.Drawing.Size(500, 500);
            this.Workrate.TabIndex = 95;
            this.Workrate.Theme = CodeArtEng.Gauge.GaugeTheme.Dark;
            this.Workrate.Title = "";
            this.Workrate.Unit = "Working rates\n(%)";
            this.Workrate.Value = 0D;
            this.Workrate.WarningLimit = 70D;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // PowOnCaption
            // 
            this.PowOnCaption.BackColor = System.Drawing.Color.Transparent;
            this.PowOnCaption.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PowOnCaption.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PowOnCaption.ForeColor = System.Drawing.Color.Lime;
            this.PowOnCaption.Location = new System.Drawing.Point(1208, 213);
            this.PowOnCaption.Name = "PowOnCaption";
            this.PowOnCaption.Size = new System.Drawing.Size(223, 40);
            this.PowOnCaption.TabIndex = 105;
            this.PowOnCaption.Text = "Power On time";
            this.PowOnCaption.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F);
            this.label2.ForeColor = System.Drawing.Color.Lime;
            this.label2.Location = new System.Drawing.Point(1168, 120);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(10, 829);
            this.label2.TabIndex = 131;
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // last_size
            // 
            this.last_size.BackColor = System.Drawing.Color.Transparent;
            this.last_size.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.last_size.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F);
            this.last_size.ForeColor = System.Drawing.Color.Aqua;
            this.last_size.Location = new System.Drawing.Point(566, 219);
            this.last_size.Name = "last_size";
            this.last_size.Size = new System.Drawing.Size(200, 69);
            this.last_size.TabIndex = 132;
            this.last_size.Text = "1000(m)";
            this.last_size.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Rest_PLst
            // 
            this.Rest_PLst.BackColor = System.Drawing.Color.Transparent;
            this.Rest_PLst.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Rest_PLst.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.Rest_PLst.ForeColor = System.Drawing.Color.Aqua;
            this.Rest_PLst.Location = new System.Drawing.Point(299, 404);
            this.Rest_PLst.Name = "Rest_PLst";
            this.Rest_PLst.Size = new System.Drawing.Size(254, 43);
            this.Rest_PLst.TabIndex = 133;
            this.Rest_PLst.Text = "Recoiler Status";
            this.Rest_PLst.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Recoiler_Status
            // 
            this.Recoiler_Status.Image = global::SNOS.Properties.Resources.Off_Status;
            this.Recoiler_Status.Location = new System.Drawing.Point(380, 472);
            this.Recoiler_Status.Name = "Recoiler_Status";
            this.Recoiler_Status.Size = new System.Drawing.Size(104, 81);
            this.Recoiler_Status.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Recoiler_Status.TabIndex = 134;
            this.Recoiler_Status.TabStop = false;
            // 
            // CS_name
            // 
            this.CS_name.BackColor = System.Drawing.Color.Transparent;
            this.CS_name.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.CS_name.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CS_name.ForeColor = System.Drawing.Color.Lime;
            this.CS_name.Location = new System.Drawing.Point(1622, 23);
            this.CS_name.Name = "CS_name";
            this.CS_name.Size = new System.Drawing.Size(249, 80);
            this.CS_name.TabIndex = 135;
            this.CS_name.Text = "Current Status";
            this.CS_name.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::SNOS.Properties.Resources.logo_White;
            this.pictureBox1.Location = new System.Drawing.Point(50, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(235, 91);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 177;
            this.pictureBox1.TabStop = false;
            // 
            // Monitor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(1920, 1080);
            this.ControlBox = false;
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.CS_name);
            this.Controls.Add(this.Recoiler_Status);
            this.Controls.Add(this.Rest_PLst);
            this.Controls.Add(this.last_size);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn_Back);
            this.Controls.Add(this.MC4);
            this.Controls.Add(this.MC3);
            this.Controls.Add(this.Coiltype);
            this.Controls.Add(this.Line_Sp);
            this.Controls.Add(this.btn_Next);
            this.Controls.Add(this.Now_Time);
            this.Controls.Add(this.Auto);
            this.Controls.Add(this.Mode);
            this.Controls.Add(this.MC2);
            this.Controls.Add(this.MC1);
            this.Controls.Add(this.result_lable);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.MC_Name);
            this.Controls.Add(this.LineSpeedCaption);
            this.Controls.Add(this.Results);
            this.Controls.Add(this.Latest_worktimeLabel);
            this.Controls.Add(this.Plan);
            this.Controls.Add(this.StopMinLabel);
            this.Controls.Add(this.StartTimeCaption);
            this.Controls.Add(this.PowOnMinLabel);
            this.Controls.Add(this.StopCaption);
            this.Controls.Add(this.AlertLabel);
            this.Controls.Add(this.PowOnDateLabel);
            this.Controls.Add(this.StatusCaption);
            this.Controls.Add(this.RunMinLabel);
            this.Controls.Add(this.StopDayLabel);
            this.Controls.Add(this.RunDayLabel);
            this.Controls.Add(this.RunCaption);
            this.Controls.Add(this.StatusLabel);
            this.Controls.Add(this.Error_Message);
            this.Controls.Add(this.Length);
            this.Controls.Add(this.Thick);
            this.Controls.Add(this.Linespeed);
            this.Controls.Add(this.Workrate);
            this.Controls.Add(this.PowOnCaption);
            this.Controls.Add(this.Close);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "Monitor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menu";
            this.Load += new System.EventHandler(this.Monitor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Recoiler_Status)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button Close;
        private System.Windows.Forms.Button btn_Back;
        private System.Windows.Forms.Button MC4;
        private System.Windows.Forms.Button MC3;
        private System.Windows.Forms.Label Coiltype;
        private System.Windows.Forms.Label Line_Sp;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Button btn_Next;
        private System.Windows.Forms.Label Now_Time;
        private System.Windows.Forms.Label Auto;
        private System.Windows.Forms.Button Mode;
        private System.Windows.Forms.Button MC2;
        private System.Windows.Forms.Button MC1;
        private System.Windows.Forms.Label result_lable;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label MC_Name;
        private System.Windows.Forms.Label LineSpeedCaption;
        private CodeArtEng.Gauge.CircularGauge Results;
        private System.Windows.Forms.Label Latest_worktimeLabel;
        private CodeArtEng.Gauge.CircularGauge Plan;
        private System.Windows.Forms.Label StopMinLabel;
        private System.Windows.Forms.Label StartTimeCaption;
        private System.Windows.Forms.Label PowOnMinLabel;
        private System.Windows.Forms.Label StopCaption;
        private System.Windows.Forms.Label AlertLabel;
        private System.Windows.Forms.Label PowOnDateLabel;
        private System.Windows.Forms.Label StatusCaption;
        private System.Windows.Forms.Label RunMinLabel;
        private System.Windows.Forms.Label StopDayLabel;
        private System.Windows.Forms.Label RunDayLabel;
        private System.Windows.Forms.Label RunCaption;
        private System.Windows.Forms.Label StatusLabel;
        private System.Windows.Forms.Label Error_Message;
        private CodeArtEng.Gauge.CircularGauge Length;
        private CodeArtEng.Gauge.RectangleIndicator Thick;
        private CodeArtEng.Gauge.LinearGauge Linespeed;
        private CodeArtEng.Gauge.CircularGauge Workrate;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label PowOnCaption;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label last_size;
        private System.Windows.Forms.Label Rest_PLst;
        private System.Windows.Forms.PictureBox Recoiler_Status;
        private System.Windows.Forms.Label CS_name;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}