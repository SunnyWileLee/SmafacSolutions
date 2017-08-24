using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Framework.Infrustructure
{
    class Md5Encrypt : IEncrypt
    {
        public string Encrypt(string input)
        {
            byte[] result = Encoding.Default.GetBytes(input);
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] output = md5.ComputeHash(result);
            return BitConverter.ToString(output).Replace("-", "");
        }
    }
}
