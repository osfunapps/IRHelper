using Microsoft.Win32;
using System;

namespace WindowsFormsApp1
{
    internal class RegistryHandler
    {
        internal static void DisableWindowsErrorReporting(bool disable)
        {
            RegistryKey myKey = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows\\Windows Error Reporting", true);
            if (myKey != null)
            {
                if (disable)
                    myKey.SetValue("DontShowUI", "1", RegistryValueKind.String);
                else
                    myKey.SetValue("DontShowUI", "0", RegistryValueKind.String);
                myKey.Close();
            }
        }
    }
}