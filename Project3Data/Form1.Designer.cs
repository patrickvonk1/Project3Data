namespace Project3Data
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
        /// gavin push test
        /// test 777777
        /// test new
        /// //hoi leslie gay
        /// succes gavin
        /// /fuck you
        /// WAT MOET IK DOEN
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
            this.firefoxSubTabControl1 = new FirefoxSubTabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.firefoxSubTabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // firefoxSubTabControl1
            // 
            this.firefoxSubTabControl1.Controls.Add(this.tabPage1);
            this.firefoxSubTabControl1.Controls.Add(this.tabPage2);
            this.firefoxSubTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.firefoxSubTabControl1.ItemSize = new System.Drawing.Size(100, 40);
            this.firefoxSubTabControl1.Location = new System.Drawing.Point(0, 0);
            this.firefoxSubTabControl1.Name = "firefoxSubTabControl1";
            this.firefoxSubTabControl1.SelectedIndex = 0;
            this.firefoxSubTabControl1.Size = new System.Drawing.Size(1893, 1052);
            this.firefoxSubTabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.firefoxSubTabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.White;
            this.tabPage1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tabPage1.BackgroundImage")));
            this.tabPage1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.tabPage1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(79)))), ((int)(((byte)(90)))));
            this.tabPage1.Location = new System.Drawing.Point(8, 48);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1877, 996);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Parkeer & Weer";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(7, 880);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(387, 58);
            this.button1.TabIndex = 0;
            this.button1.Text = "Add Parkingmodels to database";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.White;
            this.tabPage2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tabPage2.BackgroundImage")));
            this.tabPage2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tabPage2.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.tabPage2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(79)))), ((int)(((byte)(90)))));
            this.tabPage2.Location = new System.Drawing.Point(8, 48);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1877, 996);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1893, 1052);
            this.Controls.Add(this.firefoxSubTabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Project 3, Team 1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.firefoxSubTabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private FirefoxSubTabControl firefoxSubTabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
    }
}

