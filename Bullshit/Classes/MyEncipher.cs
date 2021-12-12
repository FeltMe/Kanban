using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bullshit.Classes
{
    public class MyEncipher
    {
        private const int Key = 3;

        public string Encryption(string data) //Encryption some information
        {
            string newdata = "";
            foreach (char ch in data.ToCharArray())
            {
                char tmp = (char)(ch ^ Key);
                newdata += tmp;
            }
            return newdata;
        }
    }
}
