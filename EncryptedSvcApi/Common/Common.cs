using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Threading.Tasks;

namespace EncryptedSvcApi.Common
{
    public class Common
    {
        public static String SecureStringToString(SecureString value)
        {
            IntPtr bstr = Marshal.SecureStringToBSTR(value);

            try
            {
                return Marshal.PtrToStringBSTR(bstr);
            }
            finally
            {
                Marshal.FreeBSTR(bstr);
            }
        }
    }
}
