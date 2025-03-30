namespace Giaotiep
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.butConnect = new System.Windows.Forms.Button();
            this.butDisconect = new System.Windows.Forms.Button();
            this.btBMI = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.butExit = new System.Windows.Forms.Button();
            this.labelWeight = new System.Windows.Forms.TextBox();
            this.cboBoxCOM = new System.Windows.Forms.ComboBox();
            this.serCOM = new System.IO.Ports.SerialPort(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.labelTrangThai = new System.Windows.Forms.Label();
            this.txHeight = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label1.Location = new System.Drawing.Point(256, 19);
            this.label1.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(197, 44);
            this.label1.TabIndex = 0;
            this.label1.Text = "SerialPort";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(86, 79);
            this.label2.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "COM";
            // 
            // butConnect
            // 
            this.butConnect.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butConnect.ForeColor = System.Drawing.Color.Lime;
            this.butConnect.Location = new System.Drawing.Point(87, 141);
            this.butConnect.Margin = new System.Windows.Forms.Padding(1);
            this.butConnect.Name = "butConnect";
            this.butConnect.Size = new System.Drawing.Size(154, 42);
            this.butConnect.TabIndex = 2;
            this.butConnect.Text = "Connect";
            this.butConnect.UseCompatibleTextRendering = true;
            this.butConnect.UseVisualStyleBackColor = true;
            this.butConnect.Click += new System.EventHandler(this.butConnect_Click);
            // 
            // butDisconect
            // 
            this.butDisconect.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butDisconect.ForeColor = System.Drawing.Color.Red;
            this.butDisconect.Location = new System.Drawing.Point(87, 231);
            this.butDisconect.Margin = new System.Windows.Forms.Padding(1);
            this.butDisconect.Name = "butDisconect";
            this.butDisconect.Size = new System.Drawing.Size(154, 42);
            this.butDisconect.TabIndex = 3;
            this.butDisconect.Text = "Disconnect";
            this.butDisconect.UseVisualStyleBackColor = true;
            this.butDisconect.Click += new System.EventHandler(this.butDisconect_Click);
            // 
            // btBMI
            // 
            this.btBMI.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btBMI.ForeColor = System.Drawing.Color.Yellow;
            this.btBMI.Location = new System.Drawing.Point(369, 225);
            this.btBMI.Margin = new System.Windows.Forms.Padding(1);
            this.btBMI.Name = "btBMI";
            this.btBMI.Size = new System.Drawing.Size(197, 48);
            this.btBMI.TabIndex = 4;
            this.btBMI.Text = "BMI";
            this.btBMI.UseVisualStyleBackColor = true;
            this.btBMI.Click += new System.EventHandler(this.btBMI_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(365, 137);
            this.label3.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 24);
            this.label3.TabIndex = 5;
            this.label3.Text = "Weight";
            // 
            // butExit
            // 
            this.butExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butExit.ForeColor = System.Drawing.Color.Red;
            this.butExit.Location = new System.Drawing.Point(236, 303);
            this.butExit.Margin = new System.Windows.Forms.Padding(1);
            this.butExit.Name = "butExit";
            this.butExit.Size = new System.Drawing.Size(154, 42);
            this.butExit.TabIndex = 6;
            this.butExit.Text = "Exit";
            this.butExit.UseVisualStyleBackColor = true;
            this.butExit.Click += new System.EventHandler(this.butExit_Click);
            // 
            // labelWeight
            // 
            this.labelWeight.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelWeight.Location = new System.Drawing.Point(450, 141);
            this.labelWeight.Margin = new System.Windows.Forms.Padding(1);
            this.labelWeight.Name = "labelWeight";
            this.labelWeight.Size = new System.Drawing.Size(116, 22);
            this.labelWeight.TabIndex = 7;
            // 
            // cboBoxCOM
            // 
            this.cboBoxCOM.FormattingEnabled = true;
            this.cboBoxCOM.Location = new System.Drawing.Point(160, 84);
            this.cboBoxCOM.Margin = new System.Windows.Forms.Padding(1);
            this.cboBoxCOM.Name = "cboBoxCOM";
            this.cboBoxCOM.Size = new System.Drawing.Size(84, 21);
            this.cboBoxCOM.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(367, 79);
            this.label4.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 24);
            this.label4.TabIndex = 9;
            this.label4.Text = "Status: ";
            // 
            // labelTrangThai
            // 
            this.labelTrangThai.AutoSize = true;
            this.labelTrangThai.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTrangThai.Location = new System.Drawing.Point(446, 79);
            this.labelTrangThai.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.labelTrangThai.Name = "labelTrangThai";
            this.labelTrangThai.Size = new System.Drawing.Size(134, 24);
            this.labelTrangThai.TabIndex = 10;
            this.labelTrangThai.Text = "No connection";
            // 
            // txHeight
            // 
            this.txHeight.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txHeight.Location = new System.Drawing.Point(450, 188);
            this.txHeight.Margin = new System.Windows.Forms.Padding(1);
            this.txHeight.Name = "txHeight";
            this.txHeight.Size = new System.Drawing.Size(116, 22);
            this.txHeight.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(365, 184);
            this.label6.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 24);
            this.label6.TabIndex = 13;
            this.label6.Text = "Height";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(662, 371);
            this.Controls.Add(this.txHeight);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.labelTrangThai);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cboBoxCOM);
            this.Controls.Add(this.labelWeight);
            this.Controls.Add(this.butExit);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btBMI);
            this.Controls.Add(this.butDisconect);
            this.Controls.Add(this.butConnect);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button butConnect;
        private System.Windows.Forms.Button butDisconect;
        private System.Windows.Forms.Button btBMI;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button butExit;
        private System.Windows.Forms.TextBox labelWeight;
        private System.Windows.Forms.ComboBox cboBoxCOM;
        private System.IO.Ports.SerialPort serCOM;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labelTrangThai;
        private System.Windows.Forms.TextBox txHeight;
        private System.Windows.Forms.Label label6;
    }
}

