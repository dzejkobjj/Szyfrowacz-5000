using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Szyfrowacz_5000
{
    [DataContract]
    class EncryptionDetails
    {
        [DataMember]
        static string algorithmName = "AES";
        [DataMember]
        int keySize;
        [DataMember]
        int blockSize;
        [DataMember]
        string cypherMode;
        [DataMember]
        List<User> userList;
    }
}
