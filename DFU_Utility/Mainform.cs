using DeviceProgramming.FileFormat;
using LibUsbDotNet;
using LibUsbDotNet.Main;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;

namespace DFU_Utility
{
    public partial class Mainform : Form
    {
        int selectedPID, selectedVID;
        bool isDetected = false;
        bool IsRunningProcess = false;
        public string DfuSourceFileName { get; private set; }

        public Mainform()
        {
            InitializeComponent();
            string path = Properties.Settings.Default.firwarePath;
            if (File.Exists(path))
            {
                txtFirmware.Text = Path.GetFileName(path);
                txtFirmware.Tag = path;
            }
            btnProgram.Enabled = false;
            cmbDevices.Items.Add("GD32 Microcontrollers");
            cmbDevices.Items.Add("STM32 Microcontrollers");
            cmbDevices.SelectedIndex = 0;
            this.Text = "DFU_Utility v" + RevisionHistory.GetCurrentVersion();


        }
       
        private void txtFirmware_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            SelectSourceFile();

        }

        public string GetDefaultDirectoryPathOfSourceFile()
        {
            string sourceFileDirectoryPath = Application.StartupPath + @"\bin\Firmware\";
            if (!Directory.Exists(sourceFileDirectoryPath)) sourceFileDirectoryPath = @"C:";
            return sourceFileDirectoryPath;
        }
        
        public void SelectSourceFile()
        {
            OpenFileDialog OFD = new OpenFileDialog();
            OFD.InitialDirectory = GetDefaultDirectoryPathOfSourceFile();//supposed to be where repetrel was installed
            OFD.Filter = "Bin files (*.bin)|*.bin|All files (*.*)|*.*";
            OFD.FilterIndex = 1;
            System.Media.SystemSounds.Asterisk.Play();
            DialogResult DR = OFD.ShowDialog();
            if (DR != DialogResult.OK) return;//not a happy result so leave without updating anything

            DfuSourceFileName = OFD.FileName;//save new filepath for future use by programming utility


            txtFirmware.Text = Path.GetFileName(DfuSourceFileName);
            txtFirmware.Tag = DfuSourceFileName;
            Properties.Settings.Default.firwarePath = DfuSourceFileName;
            Properties.Settings.Default.Save();
            ChangeAvaliableStatus();
        }

        private void btnSelectDfuFile_Click(object sender, EventArgs e)
        {
            SelectSourceFile();
        }

        private void btnProgram_Click(object sender, EventArgs e)
        {
            uploadFirmware();
        }

        private void uploadFirmware()
        {
            if(!File.Exists(txtFirmware.Tag?.ToString()))
            {
                MessageBox.Show("Please choose the firmware file(*.DFU).");
                return;
            }
            if(!isDetected)
            {
                MessageBox.Show("Device was not detected");
                return;
            }

            IsRunningProcess = true;
            string appPath = Application.StartupPath;
            string app = $"{appPath}/dfu-util/dfu-util.exe";
            string args = $"-a 0 -s 0x08000000 -D {txtFirmware.Tag?.ToString()}";
            Process process = new Process();
            process.EnableRaisingEvents = true;
            process.StartInfo.FileName = app;
            process.StartInfo.Arguments = args;
            process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.OutputDataReceived += new DataReceivedEventHandler(Process_OutputDataReceived);
            process.StartInfo.RedirectStandardError = true;
            process.ErrorDataReceived += new DataReceivedEventHandler(Process_OutputDataReceived);
            process.Exited += Process_Exited;
            process.Start();
            // Start the asynchronous read of the standard output stream.
            process.BeginOutputReadLine();
            process.BeginErrorReadLine();
            process.Start();
            richTextBox1.Clear();
        }

        private void Process_Exited(object sender, EventArgs e)
        {
            IsRunningProcess = false;
        }

        private void Process_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            Console.WriteLine(e.Data);
            try
            {
                if (this.InvokeRequired)
                {
                    if (this.InvokeRequired)
                    {
                        this.Invoke((MethodInvoker)delegate ()
                        {
                            ReceivedDataFromProcess(e.Data);
                        });
                    }
                }
                else
                {
                    ReceivedDataFromProcess(e.Data);
                }

            }
            catch (Exception)
            {

            }

        }
        private void ReplaceLastLine(string newText)
        {
            // Get the text of the RichTextBox
            string text = richTextBox1.Text;

            // Find the position of the last newline character
            int lastNewLineIndex = text.LastIndexOf('\n');

            // Calculate the start position of the last line
            int startIndex = lastNewLineIndex + 1;

            // Set the selection to the last line
            richTextBox1.SelectionStart = startIndex;
            richTextBox1.SelectionLength = text.Length - startIndex;

            // Replace the selected text with the new text
            richTextBox1.SelectedText = newText;
        }
        string organizatePrompt(string data)
        {
            int startPos = data.IndexOf('[');
            int endPos = data.IndexOf(']');
            string res = "";
            if (startPos > 0 && endPos > 0)
            {
                res = data.Substring(0, startPos-1);
                res += data.Substring(endPos+1);
                res += "\t" + data.Substring(startPos, endPos - startPos + 1);
            }
            else res = data;
            return res;
        }

        private void ReceivedDataFromProcess(string data)
        {

            if (data == null || data.Length == 0) return;
            data = data.Trim(new char[] { ' ', '\n' });
            if (data.StartsWith("Warning:")) return;
            if (data.StartsWith("A valid DFU")) return;
            if(data.StartsWith("No DFU capable USB "))
            {
                IsRunningProcess = false;
                return;
            }
            bool isDump = false;
            if(data.StartsWith("Erase") || data.StartsWith("Download") && data.IndexOf("%") > 0)
            {
                data = organizatePrompt(data);
                if (data.IndexOf(" 0%") > 0)
                {
                    richTextBox1.AppendText("\n" + data);
                    richTextBox1.SelectionStart = richTextBox1.Text.Length;
                    richTextBox1.SelectionLength = 0;
                    richTextBox1.ScrollToCaret();
                    isDump = true;
                }
                else 
                {
                    ReplaceLastLine(data);
                    isDump = true;
                }
            }

            if (!isDump)
            {
                richTextBox1.AppendText("\n" + data);
            }
            if (data.StartsWith("File downloaded successfully"))
            {
                IsRunningProcess = false;
                ChangeAvaliableStatus();
            }
            if (!isDump)
            {
                richTextBox1.SelectionStart = richTextBox1.Text.Length;
                richTextBox1.SelectionLength = 0;
                richTextBox1.ScrollToCaret();
            }
        }

        public void DetectDevices()
        {
            selectedPID = cmbDevices.SelectedIndex == 0 ? 0x0189 : 0xDF11;
            selectedVID = cmbDevices.SelectedIndex == 0 ? 0x28e9 : 0x0483;
            bool detected = false;
            foreach (UsbRegistry device in UsbDevice.AllDevices)
            {
                if (device.Vid == selectedVID && device.Pid == selectedPID)
                {
                    detected = true;
                }
            }
            isDetected = detected;
            ChangeAvaliableStatus();
        }
    

        private void cmbDevices_SelectedIndexChanged(object sender, EventArgs e)
        {
            DetectDevices();
        }

        private void btnDriverInstaller_Click(object sender, EventArgs e)
        {
            string appPath = Application.StartupPath;
            string app = $"{appPath}/dfu-util/wdi-simple.exe";
            string args = $"--vid {selectedVID.ToString("X")} --pid {selectedPID.ToString("X")} -t 0 -b";
            var process = new Process();// (app, args);
            process.StartInfo.FileName = app;
            process.StartInfo.Arguments = args;
            process.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DetectDevices();
        }

        public void ChangeAvaliableStatus()
        {
            bool status = IsRunningProcess ? false : isDetected;
            btnDriverInstaller.Enabled = isDetected;
            lblStatus.Text = isDetected? "Detected": "Not Detected";
            lblStatus.ForeColor = isDetected ? Color.Lime: Color.Yellow;
            btnProgram.Enabled = status && File.Exists(txtFirmware.Tag?.ToString());
            btnProgram.ForeColor = status ? Color.Yellow : Color.Gray;
            cmbDevices.Enabled = !IsRunningProcess;
        }
    }
}
