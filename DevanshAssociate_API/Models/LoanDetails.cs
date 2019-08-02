using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevanshAssociate_API.Models
{
    public class LoanDetails
    {
        //Loan account number
        public string loanAccountNumber { get; set; }

        //Loan account
        public string loanAccountType { get; set; }

        //Loan ammount
        public string loanAmmount { get; set; }

        //Loan ammount
        public string loanEmi { get; set; }

        //Loan ammount
        public string loanPeriod { get; set; }
    }
}
