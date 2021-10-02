namespace WindowsFormsApp1
{
    partial class BasicInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BasicInfo));
            this.label1 = new System.Windows.Forms.Label();
            this.NameTB = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.AgeAtAdmisTB = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.DOB = new System.Windows.Forms.DateTimePicker();
            this.DOAdmission = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.ReasonTB = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.BasInfoGB = new System.Windows.Forms.GroupBox();
            this.DODepart = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.CurrentStateCB = new System.Windows.Forms.CheckBox();
            this.BasInfoGB.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name:";
            this.label1.Click += new System.EventHandler(this.Label1_Click);
            // 
            // NameTB
            // 
            this.NameTB.Location = new System.Drawing.Point(188, 16);
            this.NameTB.Name = "NameTB";
            this.NameTB.Size = new System.Drawing.Size(240, 22);
            this.NameTB.TabIndex = 1;
            this.NameTB.TextChanged += new System.EventHandler(this.TextBox1_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Date of Birth:";
            // 
            // AgeAtAdmisTB
            // 
            this.AgeAtAdmisTB.Location = new System.Drawing.Point(188, 179);
            this.AgeAtAdmisTB.Name = "AgeAtAdmisTB";
            this.AgeAtAdmisTB.Size = new System.Drawing.Size(240, 22);
            this.AgeAtAdmisTB.TabIndex = 5;
            this.AgeAtAdmisTB.TextChanged += new System.EventHandler(this.TextBox3_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 184);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(121, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Age at Admission:";
            this.label3.Click += new System.EventHandler(this.Label3_Click);
            // 
            // DOB
            // 
            this.DOB.Location = new System.Drawing.Point(188, 69);
            this.DOB.Name = "DOB";
            this.DOB.Size = new System.Drawing.Size(240, 22);
            this.DOB.TabIndex = 6;
            // 
            // DOAdmission
            // 
            this.DOAdmission.Location = new System.Drawing.Point(188, 123);
            this.DOAdmission.Name = "DOAdmission";
            this.DOAdmission.Size = new System.Drawing.Size(240, 22);
            this.DOAdmission.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 128);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(126, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "Date of Admission:";
            this.label4.Click += new System.EventHandler(this.Label4_Click);
            // 
            // ReasonTB
            // 
            this.ReasonTB.Location = new System.Drawing.Point(188, 232);
            this.ReasonTB.Name = "ReasonTB";
            this.ReasonTB.Size = new System.Drawing.Size(240, 22);
            this.ReasonTB.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 237);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(150, 17);
            this.label5.TabIndex = 9;
            this.label5.Text = "Reason for Admission:";
            this.label5.Click += new System.EventHandler(this.Label5_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(375, 400);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(145, 35);
            this.button1.TabIndex = 11;
            this.button1.Text = "Save and Next";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(200, 400);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(106, 35);
            this.button2.TabIndex = 12;
            this.button2.Text = "Previous";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // BasInfoGB
            // 
            this.BasInfoGB.Controls.Add(this.DODepart);
            this.BasInfoGB.Controls.Add(this.label6);
            this.BasInfoGB.Controls.Add(this.CurrentStateCB);
            this.BasInfoGB.Controls.Add(this.ReasonTB);
            this.BasInfoGB.Controls.Add(this.label5);
            this.BasInfoGB.Controls.Add(this.DOAdmission);
            this.BasInfoGB.Controls.Add(this.label4);
            this.BasInfoGB.Controls.Add(this.DOB);
            this.BasInfoGB.Controls.Add(this.AgeAtAdmisTB);
            this.BasInfoGB.Controls.Add(this.label3);
            this.BasInfoGB.Controls.Add(this.label2);
            this.BasInfoGB.Controls.Add(this.NameTB);
            this.BasInfoGB.Controls.Add(this.label1);
            this.BasInfoGB.Location = new System.Drawing.Point(12, 12);
            this.BasInfoGB.Name = "BasInfoGB";
            this.BasInfoGB.Size = new System.Drawing.Size(452, 369);
            this.BasInfoGB.TabIndex = 13;
            this.BasInfoGB.TabStop = false;
            // 
            // DODepart
            // 
            this.DODepart.Location = new System.Drawing.Point(188, 327);
            this.DODepart.Name = "DODepart";
            this.DODepart.Size = new System.Drawing.Size(240, 22);
            this.DODepart.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 332);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(105, 17);
            this.label6.TabIndex = 12;
            this.label6.Text = "Date of Depart:";
            // 
            // CurrentStateCB
            // 
            this.CurrentStateCB.AutoSize = true;
            this.CurrentStateCB.Location = new System.Drawing.Point(11, 284);
            this.CurrentStateCB.Name = "CurrentStateCB";
            this.CurrentStateCB.Size = new System.Drawing.Size(208, 21);
            this.CurrentStateCB.TabIndex = 11;
            this.CurrentStateCB.Text = "Currently, living in the hostel";
            this.CurrentStateCB.UseVisualStyleBackColor = true;
            this.CurrentStateCB.CheckedChanged += new System.EventHandler(this.CheckBox1_CheckedChanged);
            // 
            // BasicInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(532, 453);
            this.Controls.Add(this.BasInfoGB);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "BasicInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Basic Information";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.BasicInfo_FormClosed);
            this.Load += new System.EventHandler(this.Form3_Load);
            this.BasInfoGB.ResumeLayout(false);
            this.BasInfoGB.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox NameTB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox AgeAtAdmisTB;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker DOB;
        private System.Windows.Forms.DateTimePicker DOAdmission;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox ReasonTB;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox BasInfoGB;
        private System.Windows.Forms.DateTimePicker DODepart;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox CurrentStateCB;
    }
}