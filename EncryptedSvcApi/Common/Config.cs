using System;
using System.Collections.Generic;
using System.Fabric;
using System.Linq;
using System.Security;
using System.Threading.Tasks;

namespace EncryptedSvcApi.Common
{
    public static class Config
    {
        public static string JJHeslo;

        public static void Init(StatelessServiceContext context)
        {
            ConfigurationPackage configPackage = context.CodePackageActivationContext.GetConfigurationPackageObject("Config");
            SecureString jjHeslo = configPackage.Settings.Sections["JJConfigSection"].Parameters["JJHeslo"].DecryptValue();
            JJHeslo = Common.SecureStringToString(jjHeslo);
        }
    }
}
