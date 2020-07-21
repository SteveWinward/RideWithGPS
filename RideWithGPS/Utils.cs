using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;

namespace RideWithGPS
{
    public static class ExtensionMethods
    {
        public static DateTime UnixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        public static String ConvertToString(this SecureString value)
        {
            IntPtr valuePtr = IntPtr.Zero;
            try
            {
                valuePtr = Marshal.SecureStringToGlobalAllocUnicode(value);
                return Marshal.PtrToStringUni(valuePtr);
            }
            finally
            {
                Marshal.ZeroFreeGlobalAllocUnicode(valuePtr);
            }
        }

        public static SecureString ConvertToSecureString(this string value)
        {
            SecureString sec = new SecureString();

            value.ToCharArray().ToList().ForEach(sec.AppendChar);

            sec.MakeReadOnly();

            return sec;
        }

        public static DateTime ConvertToDateTimeFromTotalSeconds(this int seconds)
        {
            DateTime dateTime = UnixEpoch.AddSeconds(seconds).ToLocalTime();

            return dateTime;
        }

        public static int CovertToTotalSecondsFromDateTime(this DateTime time)
        {
            return (int)time.Subtract(UnixEpoch).TotalSeconds;
        }
    }
}
