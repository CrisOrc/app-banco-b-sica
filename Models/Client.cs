using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial1.Models
{
    public class Client : User
    {
        public double balance {  get; set; }
        public double ret {  get; set; }
        public double dep { get; set; }


        //Constructor
        public Client() 
        {
            balance = 0;
            ret = 0;
            dep = 0;
        }
    }    
}
