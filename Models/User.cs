using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial1.Models
{
    public class User
    {
        // Date
        public string name { get; set; }
        public string document { get; set; }
        public string password { get; set; }
        

        //Constructor
        public User() 
        {
            name = string.Empty;
            document = string.Empty;
            password = string.Empty;
        }
    }
}
