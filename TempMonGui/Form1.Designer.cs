namespace HardwareMonitorApp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.lblCPUTemperature = new System.Windows.Forms.Label();
            this.lblCPUUsage = new System.Windows.Forms.Label();
            this.lblGPUTemperature = new System.Windows.Forms.Label();
            this.lblGPUUsage = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblRAMUsage = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblCPUTemperature
            // 
            this.lblCPUTemperature.AutoSize = true;
            this.lblCPUTemperature.Font = new System.Drawing.Font("JetBrains Mono", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCPUTemperature.Location = new System.Drawing.Point(51, 8);
            this.lblCPUTemperature.Name = "lblCPUTemperature";
            this.lblCPUTemperature.Size = new System.Drawing.Size(45, 19);
            this.lblCPUTemperature.TabIndex = 0;
            this.lblCPUTemperature.Text = "99°C";
            // 
            // lblCPUUsage
            // 
            this.lblCPUUsage.AutoSize = true;
            this.lblCPUUsage.Font = new System.Drawing.Font("JetBrains Mono", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCPUUsage.Location = new System.Drawing.Point(102, 8);
            this.lblCPUUsage.Name = "lblCPUUsage";
            this.lblCPUUsage.Size = new System.Drawing.Size(45, 19);
            this.lblCPUUsage.TabIndex = 1;
            this.lblCPUUsage.Text = "100%";
            // 
            // lblGPUTemperature
            // 
            this.lblGPUTemperature.AutoSize = true;
            this.lblGPUTemperature.Font = new System.Drawing.Font("JetBrains Mono", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGPUTemperature.Location = new System.Drawing.Point(194, 8);
            this.lblGPUTemperature.Name = "lblGPUTemperature";
            this.lblGPUTemperature.Size = new System.Drawing.Size(45, 19);
            this.lblGPUTemperature.TabIndex = 2;
            this.lblGPUTemperature.Text = "99°C";
            // 
            // lblGPUUsage
            // 
            this.lblGPUUsage.AutoSize = true;
            this.lblGPUUsage.Font = new System.Drawing.Font("JetBrains Mono", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGPUUsage.Location = new System.Drawing.Point(245, 8);
            this.lblGPUUsage.Name = "lblGPUUsage";
            this.lblGPUUsage.Size = new System.Drawing.Size(45, 19);
            this.lblGPUUsage.TabIndex = 3;
            this.lblGPUUsage.Text = "100%";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("JetBrains Mono ExtraBold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.label1.Location = new System.Drawing.Point(12, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 19);
            this.label1.TabIndex = 5;
            this.label1.Text = "CPU";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("JetBrains Mono ExtraBold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DarkTurquoise;
            this.label2.Location = new System.Drawing.Point(153, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 19);
            this.label2.TabIndex = 7;
            this.label2.Text = "GPU";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("JetBrains Mono ExtraBold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.PowderBlue;
            this.label3.Location = new System.Drawing.Point(296, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 19);
            this.label3.TabIndex = 8;
            this.label3.Text = "RAM";
            // 
            // lblRAMUsage
            // 
            this.lblRAMUsage.AutoSize = true;
            this.lblRAMUsage.Font = new System.Drawing.Font("JetBrains Mono", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRAMUsage.Location = new System.Drawing.Point(338, 8);
            this.lblRAMUsage.Name = "lblRAMUsage";
            this.lblRAMUsage.Size = new System.Drawing.Size(45, 19);
            this.lblRAMUsage.TabIndex = 9;
            this.lblRAMUsage.Text = "100%";
            // 
            // Form1
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.ClientSize = new System.Drawing.Size(410, 36);
            this.ControlBox = false;
            this.Controls.Add(this.lblRAMUsage);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblGPUUsage);
            this.Controls.Add(this.lblGPUTemperature);
            this.Controls.Add(this.lblCPUUsage);
            this.Controls.Add(this.lblCPUTemperature);
            this.ForeColor = System.Drawing.SystemColors.Control;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            //this.Load += new System.EventHandler(this.Form1_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCPUTemperature;
        private System.Windows.Forms.Label lblCPUUsage;
        private System.Windows.Forms.Label lblGPUTemperature;
        private System.Windows.Forms.Label lblGPUUsage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblRAMUsage;
    }
}