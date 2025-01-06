#pragma warning disable CA1416 // Validate platform compatibility
using Microsoft.Win32;

namespace USPS
{
    public class UspsUserId
    {
        public static bool TryGetValue(out string userId)
        {
            using RegistryKey? key = Registry.CurrentUser.OpenSubKey(@"USPS");
            if (key != null)
            {
                string? keyValue = key.GetValue("userID")?.ToString();
                if (!string.IsNullOrWhiteSpace(keyValue))
                {
                    userId = keyValue;
                    return true;
                }
                else
                {
                    userId = "";
                    return false;
                }
            }
            else
            {
                userId = "";
                return false;
            }
        }
        public static void SetUserId(string userId)
        {
            try
            {
                using RegistryKey key = Registry.CurrentUser.CreateSubKey(@"USPS");
                key.SetValue("userID", userId);
            }
            catch
            {
               throw new Exception("can't set registry item.");
            }
        }
    }
}
