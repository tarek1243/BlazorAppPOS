using Microsoft.AspNetCore.DataProtection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralUtil
{
   public class GeneralUtilEncryption
    {
        private const string Purpose = "x";
        private readonly IDataProtectionProvider _provider;

        public GeneralUtilEncryption(IDataProtectionProvider provider)
        {
            _provider = provider;
        }

        public string Encrypt(string plainText)
        {
            var protector = _provider.CreateProtector(Purpose);
            return protector.Protect(plainText);
        }

        public string Decrypt(string cipherText)
        {
            var protector = _provider.CreateProtector(Purpose);
            return protector.Unprotect(cipherText);
        }


    }
}
