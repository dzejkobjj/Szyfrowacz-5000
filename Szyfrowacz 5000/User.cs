using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Szyfrowacz_5000
{
    [DataContract]
    public class User
    {
        [DataMember]
        public string userId { get; set; }
        [DataMember]
        public string password { get; set; }
        public User(string userId, string password)
        {
            this.userId = userId;
            this.password = password;
        }
        override public string ToString()
        {
            return userId;
        }
    }
}
