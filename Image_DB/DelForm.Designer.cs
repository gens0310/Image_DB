namespace Image_DB
{
    partial class DelForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DelForm));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbID = new System.Windows.Forms.TextBox();
            this.tbFNAME = new System.Windows.Forms.TextBox();
            this.btnCON = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(16, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "File Name";
            // 
            // tbID
            // 
            this.tbID.Location = new System.Drawing.Point(110, 15);
            this.tbID.Name = "tbID";
            this.tbID.Size = new System.Drawing.Size(100, 21);
            this.tbID.TabIndex = 2;
            // 
            // tbFNAME
            // 
            this.tbFNAME.Location = new System.Drawing.Point(110, 65);
            this.tbFNAME.Name = "tbFNAME";
            this.tbFNAME.Size = new System.Drawing.Size(100, 21);
            this.tbFNAME.TabIndex = 3;
            // 
            // btnCON
            // 
            this.btnCON.Location = new System.Drawing.Point(80, 220);
            this.btnCON.Name = "btnCON";
            this.btnCON.Size = new System.Drawing.Size(75, 23);
            this.btnCON.TabIndex = 4;
            this.btnCON.Text = "Confirm";
            this.btnCON.UseVisualStyleBackColor = true;
            this.btnCON.Click += new System.EventHandler(this.btnCON_Click);
            // 
            // listView1
            // 
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(22, 110);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(188, 100);
            this.listView1.TabIndex = 5;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // DelForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(234, 251);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.btnCON);
            this.Controls.Add(this.tbFNAME);
            this.Controls.Add(this.tbID);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DelForm";
            this.Text = "Delete";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.DelForm_FormClosed);
            this.Load += new System.EventHandler(this.DelForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbID;
        private System.Windows.Forms.TextBox tbFNAME;
        private System.Windows.Forms.Button btnCON;
        private System.Windows.Forms.ListView listView1;
    }
}