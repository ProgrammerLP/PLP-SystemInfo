using Microsoft.Win32;
using System;
using System.Drawing;

namespace PLP_SystemInfo
{
    public static class SystemInfo
    {
        public static bool IsDarkModeEnabled => Registry.GetValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Themes\\Personalize", "AppsUseLightTheme", -1) is null;

        public static string GetWindowsAccentColor()
        {
            Color color = GetAccentColor();
            string c = "#" + color.R.ToString("X2") + color.G.ToString("X2") + color.B.ToString("X2");
            return c;
        }

        public static Color GetAccentColor()
        {
            const String DWM_KEY = @"Software\Microsoft\Windows\DWM";
            using (RegistryKey dwmKey = Registry.CurrentUser.OpenSubKey(DWM_KEY, RegistryKeyPermissionCheck.ReadSubTree))
            {
                const String KEY_EX_MSG = "The \"HKCU\\" + DWM_KEY + "\" registry key does not exist.";
                if (dwmKey is null) throw new InvalidOperationException(KEY_EX_MSG);

                Object accentColorObj = dwmKey.GetValue("AccentColor");
                if (accentColorObj is Int32 accentColorDword)
                {
                    return ParseDWordColor(accentColorDword);
                }
                else
                {
                    const String VALUE_EX_MSG = "The \"HKCU\\" + DWM_KEY + "\\AccentColor\" registry key value could not be parsed as an ABGR color.";
                    throw new InvalidOperationException(VALUE_EX_MSG);
                }
            }

        }

        private static Color ParseDWordColor(Int32 color)
        {
            Byte
                a = (byte)((color >> 24) & 0xFF),
                b = (byte)((color >> 16) & 0xFF),
                g = (byte)((color >> 8) & 0xFF),
                r = (byte)((color >> 0) & 0xFF);

            return Color.FromArgb(a, r, g, b);
        }
    }
}
