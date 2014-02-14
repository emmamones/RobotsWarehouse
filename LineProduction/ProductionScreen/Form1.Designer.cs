namespace ProductionScreen
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
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnPause = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ListBoxNotificaciones = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lblRobots = new System.Windows.Forms.TextBox();
            this.lblStock = new System.Windows.Forms.TextBox();
            this.txtNBS = new System.Windows.Forms.TextBox();
            this.lblStations = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtNAP = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtNBR = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(48, 99);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(185, 84);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(48, 309);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(185, 82);
            this.btnStop.TabIndex = 1;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(361, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Avalible Stations:";
            // 
            // btnPause
            // 
            this.btnPause.Location = new System.Drawing.Point(48, 200);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(185, 84);
            this.btnPause.TabIndex = 4;
            this.btnPause.Text = "Pause";
            this.btnPause.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(537, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "Avalible Robots :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(718, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(125, 16);
            this.label3.TabIndex = 7;
            this.label3.Text = "Stock Wharehouse:";
            // 
            // ListBoxNotificaciones
            // 
            this.ListBoxNotificaciones.FormattingEnabled = true;
            this.ListBoxNotificaciones.Location = new System.Drawing.Point(294, 99);
            this.ListBoxNotificaciones.Name = "ListBoxNotificaciones";
            this.ListBoxNotificaciones.Size = new System.Drawing.Size(589, 381);
            this.ListBoxNotificaciones.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(527, 74);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Notificaciones";
            // 
            // lblRobots
            // 
            this.lblRobots.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRobots.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lblRobots.Location = new System.Drawing.Point(653, 32);
            this.lblRobots.Name = "lblRobots";
            this.lblRobots.Size = new System.Drawing.Size(35, 22);
            this.lblRobots.TabIndex = 12;
            this.lblRobots.Text = "4";
            // 
            // lblStock
            // 
            this.lblStock.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStock.Location = new System.Drawing.Point(849, 32);
            this.lblStock.Name = "lblStock";
            this.lblStock.Size = new System.Drawing.Size(35, 22);
            this.lblStock.TabIndex = 12;
            this.lblStock.Text = "40";
            // 
            // txtNBS
            // 
            this.txtNBS.Location = new System.Drawing.Point(487, 6);
            this.txtNBS.Name = "txtNBS";
            this.txtNBS.Size = new System.Drawing.Size(35, 20);
            this.txtNBS.TabIndex = 12;
            this.txtNBS.Text = "8";
            // 
            // lblStations
            // 
            this.lblStations.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStations.Location = new System.Drawing.Point(478, 32);
            this.lblStations.Name = "lblStations";
            this.lblStations.Size = new System.Drawing.Size(44, 22);
            this.lblStations.TabIndex = 12;
            this.lblStations.Text = "5";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(579, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "N Box Robot";
            // 
            // txtNAP
            // 
            this.txtNAP.Location = new System.Drawing.Point(320, 32);
            this.txtNAP.Name = "txtNAP";
            this.txtNAP.Size = new System.Drawing.Size(35, 20);
            this.txtNAP.TabIndex = 12;
            this.txtNAP.Text = "3";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(400, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "N Box Station";
            // 
            // txtNBR
            // 
            this.txtNBR.Location = new System.Drawing.Point(653, 6);
            this.txtNBR.Name = "txtNBR";
            this.txtNBR.Size = new System.Drawing.Size(35, 20);
            this.txtNBR.TabIndex = 12;
            this.txtNBR.Text = "2";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(238, 37);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(76, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "N Avalible Pos";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(927, 520);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtNBR);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtNAP);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtNBS);
            this.Controls.Add(this.lblStock);
            this.Controls.Add(this.lblStations);
            this.Controls.Add(this.lblRobots);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ListBoxNotificaciones);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnPause);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnStart);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

            }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnPause;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox ListBoxNotificaciones;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox lblRobots;
        private System.Windows.Forms.TextBox lblStock;
        private System.Windows.Forms.TextBox txtNBS;
        private System.Windows.Forms.TextBox lblStations;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtNAP;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtNBR;
        private System.Windows.Forms.Label label7;
        }
    }

