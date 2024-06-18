
namespace DFU_Utility
{
    partial class Mainform
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Mainform));
            this.txtFirmware = new System.Windows.Forms.TextBox();
            this.btnSelectDfuFile = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.buttonInstallSTM32Driver = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.ButtonStm32 = new System.Windows.Forms.Button();
            this.ButtonGD32 = new System.Windows.Forms.Button();
            this.buttonInstallGd32Driver = new System.Windows.Forms.Button();
            this.groupBoxGD32 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBoxGD32.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtFirmware
            // 
            this.txtFirmware.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFirmware.Location = new System.Drawing.Point(363, 16);
            this.txtFirmware.Name = "txtFirmware";
            this.txtFirmware.ReadOnly = true;
            this.txtFirmware.Size = new System.Drawing.Size(824, 35);
            this.txtFirmware.TabIndex = 1;
            this.txtFirmware.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtFirmware.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.txtFirmware_MouseDoubleClick);
            // 
            // btnSelectDfuFile
            // 
            this.btnSelectDfuFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelectDfuFile.Location = new System.Drawing.Point(197, 12);
            this.btnSelectDfuFile.MaximumSize = new System.Drawing.Size(165, 45);
            this.btnSelectDfuFile.MinimumSize = new System.Drawing.Size(165, 45);
            this.btnSelectDfuFile.Name = "btnSelectDfuFile";
            this.btnSelectDfuFile.Size = new System.Drawing.Size(165, 45);
            this.btnSelectDfuFile.TabIndex = 10;
            this.btnSelectDfuFile.Text = "Select File";
            this.btnSelectDfuFile.UseVisualStyleBackColor = true;
            this.btnSelectDfuFile.Click += new System.EventHandler(this.btnSelectDfuFile_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox1.Location = new System.Drawing.Point(363, 57);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(824, 520);
            this.richTextBox1.TabIndex = 11;
            this.richTextBox1.Text = "";
            // 
            // buttonInstallSTM32Driver
            // 
            this.buttonInstallSTM32Driver.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonInstallSTM32Driver.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonInstallSTM32Driver.Location = new System.Drawing.Point(0, 34);
            this.buttonInstallSTM32Driver.MaximumSize = new System.Drawing.Size(165, 100);
            this.buttonInstallSTM32Driver.MinimumSize = new System.Drawing.Size(165, 100);
            this.buttonInstallSTM32Driver.Name = "buttonInstallSTM32Driver";
            this.buttonInstallSTM32Driver.Size = new System.Drawing.Size(165, 100);
            this.buttonInstallSTM32Driver.TabIndex = 10;
            this.buttonInstallSTM32Driver.Text = "Install\r\nSTM32\r\nDriver";
            this.buttonInstallSTM32Driver.UseVisualStyleBackColor = true;
            this.buttonInstallSTM32Driver.Click += new System.EventHandler(this.btnDriverInstaller_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.ForeColor = System.Drawing.Color.Yellow;
            this.label1.Location = new System.Drawing.Point(7, 356);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(350, 226);
            this.label1.TabIndex = 2;
            this.label1.Text = "if dfu device is not detected,\r\nplease put device in DFU mode,\r\npress both reset " +
    "and DFU button.\r\nrelease reset button,\r\nthen release dfu button.\r\nif this does n" +
    "ot work \r\nplease install USB driver";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.ForeColor = System.Drawing.Color.Yellow;
            this.label2.Location = new System.Drawing.Point(851, 481);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(350, 103);
            this.label2.TabIndex = 2;
            this.label2.Text = "Afert uploading the firmware. please toggle the reset button on board to restart " +
    "the device.";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.MaximumSize = new System.Drawing.Size(165, 45);
            this.button1.MinimumSize = new System.Drawing.Size(165, 45);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(165, 45);
            this.button1.TabIndex = 10;
            this.button1.Text = "Device Helper";
            this.button1.UseCompatibleTextRendering = true;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ButtonStm32
            // 
            this.ButtonStm32.Location = new System.Drawing.Point(171, 28);
            this.ButtonStm32.MaximumSize = new System.Drawing.Size(165, 100);
            this.ButtonStm32.MinimumSize = new System.Drawing.Size(165, 100);
            this.ButtonStm32.Name = "ButtonStm32";
            this.ButtonStm32.Size = new System.Drawing.Size(165, 100);
            this.ButtonStm32.TabIndex = 13;
            this.ButtonStm32.Text = "STM32 Upload";
            this.ButtonStm32.UseVisualStyleBackColor = true;
            this.ButtonStm32.Click += new System.EventHandler(this.ButtonStm32_Click);
            // 
            // ButtonGD32
            // 
            this.ButtonGD32.Location = new System.Drawing.Point(165, 21);
            this.ButtonGD32.MaximumSize = new System.Drawing.Size(165, 100);
            this.ButtonGD32.MinimumSize = new System.Drawing.Size(165, 100);
            this.ButtonGD32.Name = "ButtonGD32";
            this.ButtonGD32.Size = new System.Drawing.Size(165, 100);
            this.ButtonGD32.TabIndex = 14;
            this.ButtonGD32.Text = "GD32 Upload";
            this.ButtonGD32.UseVisualStyleBackColor = true;
            this.ButtonGD32.Click += new System.EventHandler(this.ButtonGD32_Click);
            // 
            // buttonInstallGd32Driver
            // 
            this.buttonInstallGd32Driver.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonInstallGd32Driver.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonInstallGd32Driver.Location = new System.Drawing.Point(6, 21);
            this.buttonInstallGd32Driver.MaximumSize = new System.Drawing.Size(165, 100);
            this.buttonInstallGd32Driver.MinimumSize = new System.Drawing.Size(165, 100);
            this.buttonInstallGd32Driver.Name = "buttonInstallGd32Driver";
            this.buttonInstallGd32Driver.Size = new System.Drawing.Size(165, 100);
            this.buttonInstallGd32Driver.TabIndex = 15;
            this.buttonInstallGd32Driver.Text = "Install\r\nGD32\r\nDriver";
            this.buttonInstallGd32Driver.UseVisualStyleBackColor = true;
            this.buttonInstallGd32Driver.Click += new System.EventHandler(this.buttonInstallGd32Driver_Click);
            // 
            // groupBoxGD32
            // 
            this.groupBoxGD32.Controls.Add(this.buttonInstallGd32Driver);
            this.groupBoxGD32.Controls.Add(this.ButtonGD32);
            this.groupBoxGD32.Location = new System.Drawing.Point(12, 203);
            this.groupBoxGD32.Name = "groupBoxGD32";
            this.groupBoxGD32.Size = new System.Drawing.Size(336, 150);
            this.groupBoxGD32.TabIndex = 16;
            this.groupBoxGD32.TabStop = false;
            this.groupBoxGD32.Text = "groupBox1";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.buttonInstallSTM32Driver);
            this.groupBox2.Controls.Add(this.ButtonStm32);
            this.groupBox2.ForeColor = System.Drawing.Color.Lime;
            this.groupBox2.Location = new System.Drawing.Point(12, 63);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(345, 134);
            this.groupBox2.TabIndex = 17;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "STM32";
            // 
            // Mainform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 30F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1199, 589);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBoxGD32);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnSelectDfuFile);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtFirmware);
            this.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.Name = "Mainform";
            this.Text = "DFU_Utility";
            this.groupBoxGD32.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtFirmware;
        public System.Windows.Forms.Button btnSelectDfuFile;
        private System.Windows.Forms.RichTextBox richTextBox1;
        public System.Windows.Forms.Button buttonInstallSTM32Driver;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button ButtonStm32;
        private System.Windows.Forms.Button ButtonGD32;
        public System.Windows.Forms.Button buttonInstallGd32Driver;
        private System.Windows.Forms.GroupBox groupBoxGD32;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}

