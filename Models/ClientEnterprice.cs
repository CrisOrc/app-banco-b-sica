using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial1.Models
{
    public class ClientEnterprice : User
    {
        //Data
        public double amount {get; set;}
        public double revenue { get; set;}
        public double time { get; set;}
        public double credit { get; set;}

        //Constructor
        public ClientEnterprice()
        {
            amount = 0;
            revenue = 0;
            time = 0;
            credit = 0;
        }    
    }
}
