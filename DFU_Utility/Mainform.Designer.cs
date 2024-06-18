
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
            this.lblStatusStm32 = new System.Windows.Forms.Label();
            this.btnSelectDfuFile = new System.Windows.Forms.Button();
            this.btnProgram = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.btnDriverInstaller = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblStatusGD32 = new System.Windows.Forms.Label();
            this.RDStm32 = new System.Windows.Forms.RadioButton();
            this.RDGD32 = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
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
            // lblStatusStm32
            // 
            this.lblStatusStm32.ForeColor = System.Drawing.Color.Red;
            this.lblStatusStm32.Location = new System.Drawing.Point(110, 67);
            this.lblStatusStm32.Name = "lblStatusStm32";
            this.lblStatusStm32.Size = new System.Drawing.Size(242, 93);
            this.lblStatusStm32.TabIndex = 2;
            this.lblStatusStm32.Text = "No Detected";
            // 
            // btnSelectDfuFile
            // 
            this.btnSelectDfuFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelectDfuFile.Location = new System.Drawing.Point(192, 12);
            this.btnSelectDfuFile.MaximumSize = new System.Drawing.Size(160, 45);
            this.btnSelectDfuFile.MinimumSize = new System.Drawing.Size(160, 45);
            this.btnSelectDfuFile.Name = "btnSelectDfuFile";
            this.btnSelectDfuFile.Size = new System.Drawing.Size(160, 45);
            this.btnSelectDfuFile.TabIndex = 10;
            this.btnSelectDfuFile.Text = "Select File";
            this.btnSelectDfuFile.UseVisualStyleBackColor = true;
            this.btnSelectDfuFile.Click += new System.EventHandler(this.btnSelectDfuFile_Click);
            // 
            // btnProgram
            // 
            this.btnProgram.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.btnProgram.FlatAppearance.BorderColor = System.Drawing.Color.Yellow;
            this.btnProgram.FlatAppearance.BorderSize = 3;
            this.btnProgram.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProgram.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProgram.ForeColor = System.Drawing.Color.Yellow;
            this.btnProgram.Location = new System.Drawing.Point(12, 12);
            this.btnProgram.MaximumSize = new System.Drawing.Size(160, 45);
            this.btnProgram.MinimumSize = new System.Drawing.Size(160, 45);
            this.btnProgram.Name = "btnProgram";
            this.btnProgram.Size = new System.Drawing.Size(160, 45);
            this.btnProgram.TabIndex = 9;
            this.btnProgram.Text = "Program";
            this.btnProgram.UseVisualStyleBackColor = true;
            this.btnProgram.Click += new System.EventHandler(this.btnProgram_Click);
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
            // btnDriverInstaller
            // 
            this.btnDriverInstaller.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDriverInstaller.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDriverInstaller.Location = new System.Drawing.Point(12, 532);
            this.btnDriverInstaller.MaximumSize = new System.Drawing.Size(360, 45);
            this.btnDriverInstaller.MinimumSize = new System.Drawing.Size(160, 45);
            this.btnDriverInstaller.Name = "btnDriverInstaller";
            this.btnDriverInstaller.Size = new System.Drawing.Size(340, 45);
            this.btnDriverInstaller.TabIndex = 10;
            this.btnDriverInstaller.Text = "WinUSB Driver Install";
            this.btnDriverInstaller.UseVisualStyleBackColor = true;
            this.btnDriverInstaller.Click += new System.EventHandler(this.btnDriverInstaller_Click);
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
            this.label1.Location = new System.Drawing.Point(7, 369);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(350, 103);
            this.label1.TabIndex = 2;
            this.label1.Text = "if GD or STM dfu device is not detected, please install WinUSB driver";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.ForeColor = System.Drawing.Color.Yellow;
            this.label2.Location = new System.Drawing.Point(7, 266);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(350, 103);
            this.label2.TabIndex = 2;
            this.label2.Text = "Afert uploading the firmware. please toggle the reset button on board to restart " +
    "the device.";
            // 
            // lblStatusGD32
            // 
            this.lblStatusGD32.ForeColor = System.Drawing.Color.Red;
            this.lblStatusGD32.Location = new System.Drawing.Point(110, 160);
            this.lblStatusGD32.Name = "lblStatusGD32";
            this.lblStatusGD32.Size = new System.Drawing.Size(242, 106);
            this.lblStatusGD32.TabIndex = 2;
            this.lblStatusGD32.Text = "No Detected";
            // 
            // RDStm32
            // 
            this.RDStm32.AutoSize = true;
            this.RDStm32.ForeColor = System.Drawing.Color.White;
            this.RDStm32.Location = new System.Drawing.Point(17, 67);
            this.RDStm32.Name = "RDStm32";
            this.RDStm32.Size = new System.Drawing.Size(94, 34);
            this.RDStm32.TabIndex = 12;
            this.RDStm32.TabStop = true;
            this.RDStm32.Text = "STM32";
            this.RDStm32.UseVisualStyleBackColor = true;
            // 
            // RDGD32
            // 
            this.RDGD32.AutoSize = true;
            this.RDGD32.ForeColor = System.Drawing.Color.White;
            this.RDGD32.Location = new System.Drawing.Point(17, 158);
            this.RDGD32.Name = "RDGD32";
            this.RDGD32.Size = new System.Drawing.Size(82, 34);
            this.RDGD32.TabIndex = 12;
            this.RDGD32.TabStop = true;
            this.RDGD32.Text = "GD32";
            this.RDGD32.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(12, 481);
            this.button1.MaximumSize = new System.Drawing.Size(360, 45);
            this.button1.MinimumSize = new System.Drawing.Size(160, 45);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(340, 45);
            this.button1.TabIndex = 10;
            this.button1.Text = "Device Helper";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Mainform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 30F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1199, 589);
            this.Controls.Add(this.RDGD32);
            this.Controls.Add(this.RDStm32);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnDriverInstaller);
            this.Controls.Add(this.btnSelectDfuFile);
            this.Controls.Add(this.btnProgram);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblStatusGD32);
            this.Controls.Add(this.lblStatusStm32);
            this.Controls.Add(this.txtFirmware);
            this.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.Name = "Mainform";
            this.Text = "DFU_Utility";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtFirmware;
        private System.Windows.Forms.Label lblStatusStm32;
        public System.Windows.Forms.Button btnSelectDfuFile;
        private System.Windows.Forms.Button btnProgram;
        private System.Windows.Forms.RichTextBox richTextBox1;
        public System.Windows.Forms.Button btnDriverInstaller;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblStatusGD32;
        private System.Windows.Forms.RadioButton RDStm32;
        private System.Windows.Forms.RadioButton RDGD32;
        public System.Windows.Forms.Button button1;
    }
}

