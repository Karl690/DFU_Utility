﻿using DeviceProgramming.FileFormat;
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
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;

namespace DFU_Utility
{
    public partial class Mainform : Form
    {
        bool IsRunningProcess = false;
        int detectedDevices = -1;
        string RunProcessType = ""; //Uploading, Geting
        public DFUDevice[] dfuDevices = new DFUDevice[2];
        public DFUDevice[] checkingDfuDevices;
        public string DfuSourceFileName { get; private  set; }
        
        public Mainform()
        {
            InitializeComponent();
            timer1.Interval = 1000;
            string path = Properties.Settings.Default.firwarePath;
            if (File.Exists(path))
            {
                txtFirmware.Text = Path.GetFileName(path);
                txtFirmware.Tag = path;
            }

            DFUDevice stm32 = new DFUDevice();
            stm32.type = DEVICEINDEX.STM32;
            stm32.VID = 0x0483; stm32.PID = 0xDF11; stm32.Serial = ""; stm32.isConnected = false; stm32.Type = "STM32";
            DFUDevice gd32 = new DFUDevice();
            gd32.type = DEVICEINDEX.GD32;
            gd32.VID = 0x28e9; gd32.PID = 0x0189; gd32.Serial = ""; gd32.isConnected = false; gd32.Type = "GD32";

            dfuDevices[(int)DEVICEINDEX.STM32] = stm32;
            dfuDevices[(int)DEVICEINDEX.GD32] = gd32;
            checkingDfuDevices = (DFUDevice[])dfuDevices.Clone();
            
            this.Text = "DFU_Utility v" + RevisionHistory.GetCurrentVersion();
            
        }
        public void resetDevices()
        {
            checkingDfuDevices[0].isConnected = false;
            checkingDfuDevices[1].isConnected = false;
            checkingDfuDevices[0].Serial = "";
            checkingDfuDevices[1].Serial = "";
        }
        public void setStatusDevices()
        {
            try
            {
                if (this.InvokeRequired)
                {
                    this.Invoke((MethodInvoker)delegate ()
                    {
                        ChangeAvaliableStatus();
                    });
                }
                else
                {
                    ChangeAvaliableStatus();
                }

            }
            catch (Exception)
            {

            }
        }
       
        private void txtFirmware_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            SelectSourceFile();

        }

        public string GetDefaultDirectoryPathOfSourceFile()
        {
            string sourceFileDirectoryPath = Properties.Settings.Default.firwarePath;
            if (Properties.Settings.Default.firwarePath != "")
            {
                sourceFileDirectoryPath = Path.GetDirectoryName(Properties.Settings.Default.firwarePath);

            }
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

        public void runProcesss(string app, string args)
        {
            try
            {
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
                //process.Start();
            } catch(Exception)
            {

            }
        }

        private void uploadFirmware(bool Stm32)
        {
            if(IsRunningProcess)
            {
                MessageBox.Show("it is downloading now.");
                return;
            }
            if(!File.Exists(txtFirmware.Tag?.ToString()))
            {
                MessageBox.Show("Please choose the firmware file(*.bin).");
                return;
            }
            DFUDevice selcetedDevice = Stm32 ? dfuDevices[0] : dfuDevices[1];

            if (!selcetedDevice.isConnected)
            {
                MessageBox.Show("Device was not detected");
                return;
            }
            RunProcessType = "Uploading";
            IsRunningProcess = true;

            string appPath = Application.StartupPath;
            string app = $"{appPath}/dfu-util/dfu-util.exe";
            string args = $"-d 0x{selcetedDevice.VID.ToString("x")}:0x{selcetedDevice.PID.ToString("x")} -a 0 -s 0x08000000:leave -D {txtFirmware.Tag?.ToString()}";
            args += $" -S {selcetedDevice.Serial}";
            Console.WriteLine(args);
            runProcesss(app, args);
        }

        private void Process_Exited(object sender, EventArgs e)
        {
            IsRunningProcess = false;
            if(RunProcessType == "Getting")
            {
                setStatusDevices();
                
            }
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
                            switch (RunProcessType)
                            {
                                case "Uploading": UploadingReceivedDataFromProcess(e.Data); break;
                                case "Getting": GettingReceivedDataFromProcess(e.Data); break;
                            }
                            
                        });
                    }
                }
                else
                {
                    switch (RunProcessType)
                    {
                        case "Uploading": UploadingReceivedDataFromProcess(e.Data); break;
                        case "Getting": GettingReceivedDataFromProcess(e.Data); break;
                    }
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
        private void parseDeviceData(string data)
        {
            if (!data.StartsWith("Found DFU:")) return;
            int start = data.IndexOf("[");
            int end = data.IndexOf("]");
            try
            {
                if (start > 0 && end > start)
                {
                    string temp = data.Substring(start + 1, end - start - 1);
                    string[] vpid = temp.Split(':');
                    int vid, pid;
                    if (vpid.Length != 2) return;
                    vid = Convert.ToInt32(vpid[0], 16);
                    pid = Convert.ToInt32(vpid[1], 16);
                    int deviceId = 0;
                    if(vid == 0x483 && pid == 0xDF11) //STM32
                    {
                        deviceId = (int)(int)DEVICEINDEX.STM32;
                    }else if(vid == 0x28e9 && pid == 0x0189) //GD32
                    {
                        deviceId = (int)(int)DEVICEINDEX.GD32;
                    }
                    dfuDevices[deviceId].isConnected = true;
                    int aa = data.IndexOf("name=\"@Internal Flash  /0x08000000");
                    if (aa > 0)
                    {
                        int start_pos = data.IndexOf("serial=\"");
                        if (start_pos < 0) return;
                        start_pos += 8;
                        int end_pos = data.IndexOf("\"", start_pos);
                        if (end_pos < 0) return;
                        dfuDevices[deviceId].Serial = data.Substring(start_pos, end_pos - start_pos);
                    }                    
                }
            }catch(Exception)
            {

            }
            
        }
        private void GettingReceivedDataFromProcess(string data)
        {
            if (data == null || data.Length == 0) return;
            parseDeviceData(data);
        }

        private void UploadingReceivedDataFromProcess(string data)
        {

            if (data == null || data.Length == 0) return;
            data = data.Trim(new char[] { ' ', '\n' });
            if (data.StartsWith("Warning:")) return;
            if (data.StartsWith("A   DFU")) return;
            if (data.StartsWith("Error during"))
            {
                IsRunningProcess = false;
                return;
            }
            if (data.IndexOf("LIBUSB_ERROR_TIMEOUT") > 0)
            {
                IsRunningProcess = false;
                return;
            }
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
                RunProcessType = ""; 
                ChangeAvaliableStatus();
            }
            if (!isDump)
            {
                richTextBox1.SelectionStart = richTextBox1.Text.Length;
                richTextBox1.SelectionLength = 0;
                richTextBox1.ScrollToCaret();
            }
        }

       
    
        private void checkStatus()
        {
            int detectedNum = 0;
            ManagementObjectCollection collection;
            using (var searcher = new ManagementObjectSearcher(@"SELECT * FROM Win32_PnPEntity where DeviceID Like ""USB%"""))
                collection = searcher.Get();
            bool isStm32 = false;
            bool isGd32 = false;
            foreach (var device in collection)
            {
                string name = device.GetPropertyValue("Name").ToString().ToLower();
                if (name.IndexOf("bootloader") < 0) continue;
                if(name.StartsWith("stm32"))
                {
                    isStm32 = true;
                }else if(name.StartsWith("gd32"))
                {
                    isGd32 = true;
                }
                detectedNum++;
            }
            collection.Dispose();
            if (detectedDevices == detectedNum) return;
            detectedDevices = detectedNum;
            dfuDevices[0].isConnected = isStm32;
            dfuDevices[1].isConnected = isGd32;
            if (!isStm32) dfuDevices[0].Serial = "";
            if (!isGd32) dfuDevices[1].Serial = "";
            RunProcessType = "Getting";
            string appPath = Application.StartupPath;
            string app = $"{appPath}/dfu-util/dfu-util.exe";
            string args = $"-l";
            runProcesss(app, args);
        }
       

        private void btnDriverStm32Installer_Click(object sender, EventArgs e)
        {
            if(dfuDevices[0].isConnected) return;
            string appPath = Application.StartupPath;
            string app = $"{appPath}/dfu-util/wdi-simple.exe";
            DFUDevice dev = dfuDevices[0];
            string args = $"--vid {dev.VID.ToString("X")} --pid {dev.PID.ToString("X")} -t 0 -b";
            var process = new Process();// (app, args);
            try
            {
                process.StartInfo.FileName = app;
                process.StartInfo.Arguments = args;
                process.Start();
            }
            catch (Exception)
            {

            }
            
        }

        private void timer1_Tick(object sender, EventArgs e)
                    {
            if (IsRunningProcess) return;
            checkStatus();
        }

        public void ChangeAvaliableStatus()
        {
            bool isAnyDetected = false;
            foreach(var dev in dfuDevices)
            {
                if(dev.type == DEVICEINDEX.STM32)
                {
                    groupBoxSTM.Text = $"STM32 {(dev.isConnected ? "Detected" : "Not Detected")}";
                    groupBoxSTM.ForeColor = dev.isConnected ? Color.Lime : Color.Red;
                    if (dev.isConnected)
                    {
                        buttonInstallSTM32Driver.BackColor = buttonInstallSTM32Driver.FlatAppearance.MouseDownBackColor = buttonInstallSTM32Driver.FlatAppearance.MouseOverBackColor = Color.Gray;
                        buttonInstallSTM32Driver.ForeColor = Color.Black;
                        ButtonStm32.BackColor = ButtonStm32.FlatAppearance.MouseDownBackColor = ButtonStm32.FlatAppearance.MouseOverBackColor = Color.Black;
                        ButtonStm32.ForeColor = Color.Lime;
                    }
                    else
                    {
                        buttonInstallSTM32Driver.BackColor = buttonInstallSTM32Driver.FlatAppearance.MouseDownBackColor = buttonInstallSTM32Driver.FlatAppearance.MouseOverBackColor = Color.Black;
                        buttonInstallSTM32Driver.ForeColor = Color.Red;
                        ButtonStm32.BackColor = ButtonStm32.FlatAppearance.MouseDownBackColor = ButtonStm32.FlatAppearance.MouseOverBackColor = Color.Gray;
                        ButtonStm32.ForeColor = Color.Black;
                    }
                }
                else
                {
                    groupBoxGD.Text = $"GD32 {(dev.isConnected ? "Detected" : "Not Detected")}";
                    groupBoxGD.ForeColor = dev.isConnected ? Color.Lime : Color.Red;
                    if (dev.isConnected)
                    {
                        buttonInstallGd32Driver.BackColor = buttonInstallGd32Driver.FlatAppearance.MouseDownBackColor = buttonInstallGd32Driver.FlatAppearance.MouseOverBackColor = Color.Gray;
                        buttonInstallGd32Driver.ForeColor = Color.Black;
                        ButtonGD32.BackColor = ButtonGD32.FlatAppearance.MouseDownBackColor = ButtonGD32.FlatAppearance.MouseOverBackColor = Color.Black;
                        ButtonGD32.ForeColor = Color.Lime;
                    }
                    else
                    {
                        buttonInstallGd32Driver.BackColor = buttonInstallGd32Driver.FlatAppearance.MouseDownBackColor = buttonInstallGd32Driver.FlatAppearance.MouseOverBackColor = Color.Black;
                        buttonInstallGd32Driver.ForeColor = Color.Red;
                        ButtonGD32.BackColor = ButtonGD32.FlatAppearance.MouseDownBackColor = ButtonGD32.FlatAppearance.MouseOverBackColor = Color.Gray;
                        ButtonGD32.ForeColor = Color.Black;
                    }
                }
                if(dev.isConnected)
                {
                    isAnyDetected = true;
                }
            }
            // buttonInstallSTM32Driver.Enabled = !IsRunningProcess;
            //buttonInstallGd32Driver.Enabled = !IsRunningProcess;
            //btnProgram.Enabled = isAnyDetected && File.Exists(txtFirmware.Tag?.ToString());
            //btnProgram.ForeColor = isAnyDetected ? Color.Yellow : Color.Gray;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string appPath = Application.StartupPath;
            string app = $"{appPath}/dfu-util/DeviceHelper.exe";
            Process process = new Process();
            process.EnableRaisingEvents = true;
            process.StartInfo.FileName = app;
            process.Start();
            // Start the asynchronous read of the standard output stream.
            
        }

        private void ButtonStm32_Click(object sender, EventArgs e)
        {
            if (IsRunningProcess) return;
            if (!dfuDevices[0].isConnected) return;
            uploadFirmware(true);
        }

        private void ButtonGD32_Click(object sender, EventArgs e)
        {
            if (IsRunningProcess) return;
            if (!dfuDevices[1].isConnected) return;
            uploadFirmware(false);
        }

        private void buttonInstallGd32Driver_Click(object sender, EventArgs e)
        {
            if (dfuDevices[1].isConnected) return;
            string appPath = Application.StartupPath;
            string app = $"{appPath}/dfu-util/wdi-simple.exe";
            DFUDevice dev = dfuDevices[1];
            string args = $"--vid {dev.VID.ToString("X")} --pid {dev.PID.ToString("X")} -t 0 -b";
            var process = new Process();// (app, args);
            try
            {
                process.StartInfo.FileName = app;
                process.StartInfo.Arguments = args;
                process.Start();
            }
            catch (Exception)
            {

            }

        }

        private void btnPictureShowHide_Click(object sender, EventArgs e)
        {
            pictureBoxScreen.Visible = !pictureBoxScreen.Visible;
            if (pictureBoxScreen.Visible)
            {
                btnPictureShowHide.Text = "<<";
                richTextBox1.Left = 760;
                richTextBox1.Width = this.Width - richTextBox1.Left - 20;
            }
            else {
                btnPictureShowHide.Text = ">>";
                richTextBox1.Left = 363;
                richTextBox1.Width = this.Width - richTextBox1.Left - 20;
            }
                
        }
    }
    public class DFUDevice
    {
        public DEVICEINDEX type;
        public int VID;
        public int PID;
        public string Serial;
        public string Type; // GD32, STM32
        public bool isConnected;
    }

    public enum DEVICEINDEX
    {
        STM32 = 0,
        GD32 = 1
    }
}
