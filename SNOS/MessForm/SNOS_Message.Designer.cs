namespace SNOS.MessForm
{
    partial class SNOS_Message
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SNOS_Message));
            this.Mes_type = new System.Windows.Forms.Label();
            this.Close = new System.Windows.Forms.Button();
            this.Message_Text = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Mes_type
            // 
            this.Mes_type.BackColor = System.Drawing.Color.Transparent;
            this.Mes_type.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Mes_type.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Mes_type.ForeColor = System.Drawing.Color.Lime;
            this.Mes_type.Location = new System.Drawing.Point(12, 19);
            this.Mes_type.Name = "Mes_type";
            this.Mes_type.Size = new System.Drawing.Size(676, 87);
            this.Mes_type.TabIndex = 107;
            this.Mes_type.Text = "Error";
            this.Mes_type.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Close
            // 
            this.Close.BackColor = System.Drawing.Color.Black;
            this.Close.Font = new System.Drawing.Font("Microsoft Sans Serif", 32F);
            this.Close.ForeColor = System.Drawing.Color.Lime;
            this.Close.Location = new System.Drawing.Point(226, 293);
            this.Close.Name = "Close";
            this.Close.Size = new System.Drawing.Size(250, 80);
            this.Close.TabIndex = 1;
            this.Close.Text = "Close";
            this.Close.UseVisualStyleBackColor = false;
            this.Close.Click += new System.EventHandler(this.Close_Click);
            // 
            // Message_Text
            // 
            this.Message_Text.BackColor = System.Drawing.Color.Transparent;
            this.Message_Text.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Message_Text.Font = new System.Drawing.Font("Arial", 20F);
            this.Message_Text.ForeColor = System.Drawing.Color.Aqua;
            this.Message_Text.Location = new System.Drawing.Point(12, 118);
            this.Message_Text.Name = "Message_Text";
            this.Message_Text.Size = new System.Drawing.Size(676, 146);
            this.Message_Text.TabIndex = 108;
            this.Message_Text.Text = "Text show area";
            this.Message_Text.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SNOS_Message
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(700, 400);
            this.ControlBox = false;
            this.Controls.Add(this.Message_Text);
            this.Controls.Add(this.Mes_type);
            this.Controls.Add(this.Close);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SNOS_Message";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SNOS_Message";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label Mes_type;
        private System.Windows.Forms.Button Close;
        private System.Windows.Forms.Label Message_Text;
    }
}