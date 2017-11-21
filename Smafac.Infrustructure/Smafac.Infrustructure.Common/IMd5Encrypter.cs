using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Infrustructure.Common
{
    public interface IMd5Encrypter
    {
        string Encrypt(string input);
    }
}
