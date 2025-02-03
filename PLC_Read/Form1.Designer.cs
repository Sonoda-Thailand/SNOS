namespace PLC_Read
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
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Lenght = new System.Windows.Forms.TextBox();
            this.speed = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.thick = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Result = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.plan = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btn_Read = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(166, 9);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(118, 59);
            this.button3.TabIndex = 2;
            this.button3.Text = "Connect";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(304, 9);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(113, 59);
            this.button4.TabIndex = 3;
            this.button4.Text = "Discon";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 24);
            this.label3.TabIndex = 8;
            this.label3.Text = "label3";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 96);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 24);
            this.label1.TabIndex = 9;
            this.label1.Text = "製品長さ W200";
            // 
            // Lenght
            // 
            this.Lenght.Location = new System.Drawing.Point(304, 96);
            this.Lenght.Name = "Lenght";
            this.Lenght.Size = new System.Drawing.Size(207, 29);
            this.Lenght.TabIndex = 10;
            // 
            // speed
            // 
            this.speed.Location = new System.Drawing.Point(304, 147);
            this.speed.Name = "speed";
            this.speed.Size = new System.Drawing.Size(207, 29);
            this.speed.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 147);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(142, 24);
            this.label2.TabIndex = 11;
            this.label2.Text = "ライン速度 W202";
            // 
            // thick
            // 
            this.thick.Location = new System.Drawing.Point(304, 203);
            this.thick.Name = "thick";
            this.thick.Size = new System.Drawing.Size(207, 29);
            this.thick.TabIndex = 14;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(32, 203);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(144, 24);
            this.label4.TabIndex = 13;
            this.label4.Text = "コイル板厚 W204";
            // 
            // Result
            // 
            this.Result.Location = new System.Drawing.Point(304, 262);
            this.Result.Name = "Result";
            this.Result.Size = new System.Drawing.Size(207, 29);
            this.Result.TabIndex = 16;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(32, 262);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(161, 24);
            this.label5.TabIndex = 15;
            this.label5.Text = "ライン停止長 W206";
            // 
            // plan
            // 
            this.plan.Location = new System.Drawing.Point(304, 312);
            this.plan.Name = "plan";
            this.plan.Size = new System.Drawing.Size(207, 29);
            this.plan.TabIndex = 18;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(32, 312);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(246, 24);
            this.label6.TabIndex = 17;
            this.label6.Text = "アンコイラコイルセット長さ W208";
            // 
            // btn_Read
            // 
            this.btn_Read.Location = new System.Drawing.Point(436, 13);
            this.btn_Read.Name = "btn_Read";
            this.btn_Read.Size = new System.Drawing.Size(119, 55);
            this.btn_Read.TabIndex = 19;
            this.btn_Read.Text = "Read";
            this.btn_Read.UseVisualStyleBackColor = true;
            this.btn_Read.Click += new System.EventHandler(this.btn_Read_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(567, 368);
            this.Controls.Add(this.btn_Read);
            this.Controls.Add(this.plan);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.Result);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.thick);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.speed);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Lenght);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Lenght;
        private System.Windows.Forms.TextBox speed;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox thick;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox Result;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox plan;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btn_Read;
        private System.Windows.Forms.Timer timer1;
    }
}