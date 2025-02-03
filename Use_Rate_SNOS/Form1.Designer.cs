namespace Use_Rate_SNOS
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
            this.Lb_Year = new System.Windows.Forms.Label();
            this.Lb_STMID = new System.Windows.Forms.Label();
            this.Year = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.DS_Start = new System.Windows.Forms.ComboBox();
            this.DS_End = new System.Windows.Forms.ComboBox();
            this.NS_End = new System.Windows.Forms.ComboBox();
            this.NS_Start = new System.Windows.Forms.ComboBox();
            this.bt_Search = new System.Windows.Forms.Button();
            this.STMID = new System.Windows.Forms.TextBox();
            this.Line_Text = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.DatalistView = new System.Windows.Forms.ListView();
            this.label4 = new System.Windows.Forms.Label();
            this.Mode = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Lb_Year
            // 
            this.Lb_Year.AutoSize = true;
            this.Lb_Year.Location = new System.Drawing.Point(25, 25);
            this.Lb_Year.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Lb_Year.Name = "Lb_Year";
            this.Lb_Year.Size = new System.Drawing.Size(43, 20);
            this.Lb_Year.TabIndex = 1;
            this.Lb_Year.Text = "Year";
            // 
            // Lb_STMID
            // 
            this.Lb_STMID.AutoSize = true;
            this.Lb_STMID.Location = new System.Drawing.Point(152, 25);
            this.Lb_STMID.Name = "Lb_STMID";
            this.Lb_STMID.Size = new System.Drawing.Size(63, 20);
            this.Lb_STMID.TabIndex = 2;
            this.Lb_STMID.Text = "STM ID";
            // 
            // Year
            // 
            this.Year.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Year.FormattingEnabled = true;
            this.Year.Items.AddRange(new object[] {
            "2018",
            "2019",
            "2020",
            "2021"});
            this.Year.Location = new System.Drawing.Point(29, 65);
            this.Year.Name = "Year";
            this.Year.Size = new System.Drawing.Size(121, 28);
            this.Year.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 110);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "Day Shift";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 192);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "Night Shift";
            // 
            // DS_Start
            // 
            this.DS_Start.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DS_Start.FormattingEnabled = true;
            this.DS_Start.Items.AddRange(new object[] {
            "2018",
            "2019",
            "2020",
            "2021"});
            this.DS_Start.Location = new System.Drawing.Point(29, 144);
            this.DS_Start.Name = "DS_Start";
            this.DS_Start.Size = new System.Drawing.Size(121, 28);
            this.DS_Start.TabIndex = 8;
            // 
            // DS_End
            // 
            this.DS_End.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DS_End.FormattingEnabled = true;
            this.DS_End.Items.AddRange(new object[] {
            "2018",
            "2019",
            "2020",
            "2021"});
            this.DS_End.Location = new System.Drawing.Point(283, 144);
            this.DS_End.Name = "DS_End";
            this.DS_End.Size = new System.Drawing.Size(121, 28);
            this.DS_End.TabIndex = 9;
            // 
            // NS_End
            // 
            this.NS_End.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.NS_End.FormattingEnabled = true;
            this.NS_End.Items.AddRange(new object[] {
            "2018",
            "2019",
            "2020",
            "2021"});
            this.NS_End.Location = new System.Drawing.Point(284, 227);
            this.NS_End.Name = "NS_End";
            this.NS_End.Size = new System.Drawing.Size(121, 28);
            this.NS_End.TabIndex = 11;
            // 
            // NS_Start
            // 
            this.NS_Start.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.NS_Start.FormattingEnabled = true;
            this.NS_Start.Items.AddRange(new object[] {
            "2018",
            "2019",
            "2020",
            "2021"});
            this.NS_Start.Location = new System.Drawing.Point(29, 227);
            this.NS_Start.Name = "NS_Start";
            this.NS_Start.Size = new System.Drawing.Size(121, 28);
            this.NS_Start.TabIndex = 10;
            // 
            // bt_Search
            // 
            this.bt_Search.Location = new System.Drawing.Point(284, 313);
            this.bt_Search.Name = "bt_Search";
            this.bt_Search.Size = new System.Drawing.Size(120, 40);
            this.bt_Search.TabIndex = 12;
            this.bt_Search.Text = "Search";
            this.bt_Search.UseVisualStyleBackColor = true;
            this.bt_Search.Click += new System.EventHandler(this.bt_Search_Click);
            // 
            // STMID
            // 
            this.STMID.Location = new System.Drawing.Point(156, 67);
            this.STMID.Name = "STMID";
            this.STMID.Size = new System.Drawing.Size(121, 26);
            this.STMID.TabIndex = 13;
            // 
            // Line_Text
            // 
            this.Line_Text.Location = new System.Drawing.Point(283, 67);
            this.Line_Text.Name = "Line_Text";
            this.Line_Text.Size = new System.Drawing.Size(121, 26);
            this.Line_Text.TabIndex = 15;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(279, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 20);
            this.label3.TabIndex = 14;
            this.label3.Text = "LINE";
            // 
            // DatalistView
            // 
            this.DatalistView.FullRowSelect = true;
            this.DatalistView.GridLines = true;
            this.DatalistView.HideSelection = false;
            this.DatalistView.Location = new System.Drawing.Point(437, 40);
            this.DatalistView.Name = "DatalistView";
            this.DatalistView.Size = new System.Drawing.Size(460, 300);
            this.DatalistView.TabIndex = 410;
            this.DatalistView.UseCompatibleStateImageBehavior = false;
            this.DatalistView.View = System.Windows.Forms.View.Details;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(590, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 20);
            this.label4.TabIndex = 411;
            this.label4.Text = "Data";
            // 
            // Mode
            // 
            this.Mode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Mode.FormattingEnabled = true;
            this.Mode.Items.AddRange(new object[] {
            "Total",
            "Day",
            "Night"});
            this.Mode.Location = new System.Drawing.Point(29, 320);
            this.Mode.Name = "Mode";
            this.Mode.Size = new System.Drawing.Size(121, 28);
            this.Mode.TabIndex = 412;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(25, 283);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 20);
            this.label5.TabIndex = 413;
            this.label5.Text = "Mode";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(924, 381);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.Mode);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.DatalistView);
            this.Controls.Add(this.Line_Text);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.STMID);
            this.Controls.Add(this.bt_Search);
            this.Controls.Add(this.NS_End);
            this.Controls.Add(this.NS_Start);
            this.Controls.Add(this.DS_End);
            this.Controls.Add(this.DS_Start);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Year);
            this.Controls.Add(this.Lb_STMID);
            this.Controls.Add(this.Lb_Year);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Use_Rate_Report";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label Lb_Year;
        private System.Windows.Forms.Label Lb_STMID;
        private System.Windows.Forms.ComboBox Year;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox DS_Start;
        private System.Windows.Forms.ComboBox DS_End;
        private System.Windows.Forms.ComboBox NS_End;
        private System.Windows.Forms.ComboBox NS_Start;
        private System.Windows.Forms.Button bt_Search;
        private System.Windows.Forms.TextBox STMID;
        private System.Windows.Forms.TextBox Line_Text;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListView DatalistView;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox Mode;
        private System.Windows.Forms.Label label5;
    }
}

