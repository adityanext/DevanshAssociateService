using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevanshAssociate_API.Models
{
    public class BankData
    {
        //Loan account
        public int bankId { get; set; }

        //Loan account number
        public string bankName { get; set; }

        //Loan ammount
        public string bankDetails { get; set; }

        //Loan ammount
        public string bankType { get; set; }       
    }
}
