using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Runtime.InteropServices;

namespace WindowsFormsProxy
{

    public partial class Form1
    {
        [DllImport("wininet.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern bool InternetSetOption(IntPtr hInternet, int
            dwOption, IntPtr lpBuffer, int dwBufferLength);

        public const int INTERNET_OPTION_SETTINGS_CHANGED = 39;
        public const int INTERNET_OPTION_REFRESH = 37;

        public Form1()
        {
            InitializeComponent();
        }

        public Form1(string s)
        {
            MessageBox.Show(s);
            InitializeComponent();
        }
        // This function is what is called after editing the registry - this causes internet explorer to update its proxy even if it is already open.
        // It also effects the web browser control in any VB.net application that is running.
        public void globalProxy_apply()
        {
            bool settingsReturn = false;
            bool refreshReturn = false;
            settingsReturn = InternetSetOption(IntPtr.Zero, INTERNET_OPTION_SETTINGS_CHANGED, IntPtr.Zero, 0);
            if (!settingsReturn)
                MessageBox.Show(@"Error 001: Line ""InternetSetOption(IntPtr.Zero, INTERNET_OPTION_SETTINGS_CHANGED, IntPtr.Zero, 0)"" failed.", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            refreshReturn = InternetSetOption(IntPtr.Zero, INTERNET_OPTION_REFRESH, IntPtr.Zero, 0);
            if (!refreshReturn)
                MessageBox.Show(@"Error 002: Line ""InternetSetOption(IntPtr.Zero, INTERNET_OPTION_REFRESH, IntPtr.Zero, 0)"" failed.", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public bool globalProxy_IsProxyEnabled()
        {
            try
            {
                RegistryKey Regs = Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Internet Settings", RegistryKeyPermissionCheck.ReadWriteSubTree);
                if (Regs.GetValue("ProxyEnable") != null)
                {
                    if (Regs.GetValue("ProxyEnable").ToString() == "0")
                        return false;
                    else
                        return true;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error 01X: " + ex.Message, @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public string globalProxy_GetProxyServer()
        {
            try
            {
                RegistryKey Regs = Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Internet Settings", RegistryKeyPermissionCheck.ReadWriteSubTree);
                if (Regs.GetValue("ProxyServer") != null)
                    return Regs.GetValue("ProxyServer").ToString();
                else
                    return "";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error 02X: " + ex.Message, @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "";
            }
        }

        public void globalProxy_DisableProxy()
        {
            RegistryKey regkey;
            try
            {
                regkey = Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Internet Settings");
                regkey.SetValue("ProxyEnable", false, RegistryValueKind.DWord);
                regkey.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error 03X: " + ex.Message, @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            globalProxy_apply();
        }

        public void globalProxy_SetProxy(string ServerName)
        {
            RegistryKey regkey;
            try
            {
                regkey = Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Internet Settings");
                regkey.SetValue("ProxyServer", ServerName, RegistryValueKind.Unknown);
                regkey.SetValue("ProxyEnable", true, RegistryValueKind.DWord);
                regkey.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error 04X: " + ex.Message, @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            globalProxy_apply();
        }

        private void B_Set_Click(System.Object sender, System.EventArgs e)
        {
            if (TextBox1.Text == "")
                globalProxy_DisableProxy();
            else
                globalProxy_SetProxy(TextBox1.Text + ":" + textBox2.Text);
        }

        private void B_Disable_Click(System.Object sender, System.EventArgs e)
        {
            globalProxy_DisableProxy();
        }

        private void B_Get_Click(System.Object sender, System.EventArgs e)
        {
            if (globalProxy_IsProxyEnabled())
            {
                string s = globalProxy_GetProxyServer();
                TextBox1.Text = s.Split(':')[0];
                textBox2.Text = s.Split(':')[1];
            }
            else
            {
                TextBox1.Text = "";
                textBox2.Text = "";
            }
                
        }
    }
}


