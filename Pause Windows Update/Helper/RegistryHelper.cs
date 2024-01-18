using Microsoft.Win32;

namespace Pause_Windows_Update
{
    /// <summary>
    /// AUTHOR: FASTCHEN
    /// WEBSITE: https://fastchen.com
    /// ProjectCrateTIME: 2024-01-18
    /// GITHUB: https://github.com/FastChen/Pause-Windows-Update
    /// </summary>
    internal class RegistryHelper
    {
        public static void SetValue(RegistryHive key, string sub, string name, object value)
        {
            RegistryKey reg = RegistryKey.OpenBaseKey(key, Environment.Is64BitOperatingSystem ? RegistryView.Registry64 : RegistryView.Default);
            var getKey =  reg.OpenSubKey(sub, true);
            getKey.SetValue(name, value);
            getKey.Close();
        }

        public static string GetValue(RegistryHive key, string sub, string name)
        {
            string? keyValue = string.Empty;
            RegistryKey reg = RegistryKey.OpenBaseKey(key, Environment.Is64BitOperatingSystem ? RegistryView.Registry64 : RegistryView.Default);
            var getKey = reg.OpenSubKey(sub, true);
            keyValue = getKey.GetValue(name) != null ? getKey.GetValue(name).ToString() : "";
            getKey.Close();

            return keyValue;
        }

        public static void DeleteValue(RegistryHive key, string sub, string name)
        {
            try
            {
                RegistryKey reg = RegistryKey.OpenBaseKey(key, Environment.Is64BitOperatingSystem ? RegistryView.Registry64 : RegistryView.Default);
                var getKey = reg.OpenSubKey(sub, true);
                getKey.DeleteValue(name);
                getKey.Close();
            }
            catch { }

        }
    }
}
