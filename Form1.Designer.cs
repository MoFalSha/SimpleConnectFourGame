namespace Connect_Four
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.btnRestart = new System.Windows.Forms.Button();
            this.lblPlayerTurn = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Navy;
            this.panel1.Location = new System.Drawing.Point(321, 87);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(640, 490);
            this.panel1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(321, 58);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(82, 23);
            this.button1.TabIndex = 1;
            this.button1.Tag = "1";
            this.button1.Text = "Column 1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.ButtonClicked);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(414, 58);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(82, 23);
            this.button2.TabIndex = 2;
            this.button2.Tag = "2";
            this.button2.Text = "Column 2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.ButtonClicked);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(507, 58);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(82, 23);
            this.button3.TabIndex = 3;
            this.button3.Tag = "3";
            this.button3.Text = "Column 3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.ButtonClicked);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(600, 58);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(82, 23);
            this.button4.TabIndex = 4;
            this.button4.Tag = "4";
            this.button4.Text = "Column 4";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.ButtonClicked);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(693, 58);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(82, 23);
            this.button5.TabIndex = 5;
            this.button5.Tag = "5";
            this.button5.Text = "Column 5";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.ButtonClicked);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(786, 58);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(82, 23);
            this.button6.TabIndex = 6;
            this.button6.Tag = "6";
            this.button6.Text = "Column 6";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.ButtonClicked);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(879, 58);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(82, 23);
            this.button7.TabIndex = 7;
            this.button7.Tag = "7";
            this.button7.Text = "Column 7";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.ButtonClicked);
            // 
            // btnRestart
            // 
            this.btnRestart.Location = new System.Drawing.Point(548, 588);
            this.btnRestart.Name = "btnRestart";
            this.btnRestart.Size = new System.Drawing.Size(186, 56);
            this.btnRestart.TabIndex = 8;
            this.btnRestart.Text = "Restart Game";
            this.btnRestart.UseVisualStyleBackColor = true;
            this.btnRestart.Click += new System.EventHandler(this.btnRestart_Click);
            // 
            // lblPlayerTurn
            // 
            this.lblPlayerTurn.AutoSize = true;
            this.lblPlayerTurn.BackColor = System.Drawing.Color.White;
            this.lblPlayerTurn.Font = new System.Drawing.Font("Georgia", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlayerTurn.ForeColor = System.Drawing.Color.White;
            this.lblPlayerTurn.Location = new System.Drawing.Point(507, -1);
            this.lblPlayerTurn.Name = "lblPlayerTurn";
            this.lblPlayerTurn.Size = new System.Drawing.Size(0, 56);
            this.lblPlayerTurn.TabIndex = 9;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(28)))), ((int)(((byte)(39)))));
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.lblPlayerTurn);
            this.Controls.Add(this.btnRestart);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "ConnectFourMoFal";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button btnRestart;
        private System.Windows.Forms.Label lblPlayerTurn;
    }
}

