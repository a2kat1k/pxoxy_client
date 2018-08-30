# pxoxy_client
![alt text]( http://klimukphotos.s3.amazonaws.com/proxy.png  "Main Form")


This program makes you connections from global proxy.
`Easy to use`. Just provide ip address and port and click `set` button.
After this you can check your ip from 2ip.ru 
Also it has `get` and `disable` buttons.
`Get` will return your proxy address if you has one.
And `disable` - will disable any proxy.

>Usage

``` csharp

[DllImport("wininet.dll", SetLastError = true, CharSet = CharSet.Auto)]
    public static extern bool InternetSetOption(IntPtr hInternet, int
        dwOption, IntPtr lpBuffer, int dwBufferLength);
            
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

```
