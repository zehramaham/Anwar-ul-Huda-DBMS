namespace WindowsFormsApp1
{
    partial class ExistingSponser
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExistingSponser));
            this.button1 = new System.Windows.Forms.Button();
            this.ESponserDGV = new System.Windows.Forms.DataGridView();
            this.button3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ESponserDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(682, 403);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(106, 35);
            this.button1.TabIndex = 29;
            this.button1.Text = "End";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // ESponserDGV
            // 
            this.ESponserDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ESponserDGV.Cursor = System.Windows.Forms.Cursors.Default;
            this.ESponserDGV.Location = new System.Drawing.Point(26, 24);
            this.ESponserDGV.Name = "ESponserDGV";
            this.ESponserDGV.RowHeadersWidth = 51;
            this.ESponserDGV.RowTemplate.Height = 24;
            this.ESponserDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ESponserDGV.Size = new System.Drawing.Size(746, 355);
            this.ESponserDGV.TabIndex = 31;
            this.ESponserDGV.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ESponserDGV_CellClick);
            this.ESponserDGV.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ESponserDGV_CellContentClick);
            this.ESponserDGV.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ESponserDGV_CellDoubleClick);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(541, 403);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(107, 35);
            this.button3.TabIndex = 32;
            this.button3.Text = "Previous";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.Button3_Click);
            // 
            // ExistingSponser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.ESponserDGV);
            this.Controls.Add(this.button1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ExistingSponser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sponsers";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ExistingSponser_FormClosed);
            this.Load += new System.EventHandler(this.ExistingSponser_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ESponserDGV)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView ESponserDGV;
        private System.Windows.Forms.Button button3;
    }
}