using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevanshAssociate_API.Models
{
    public class CustomerData
    {
        //Customer ID
        public int customerId { get; set; }

        //Customer Name
        public string customerName { get; set; }

        //Buisness Name
        public string buisnessName { get; set; }

        //Loan type ID
        public int loan { get; set; }

        //Loan type ID
        public int otherBankloanType { get; set; }

        //Buisness Address
        public string buisnessAddress { get; set; }

        //Permanent Address
        public string permanentAddress { get; set; }

        //Contact Number
        public string primaryContactNumber { get; set; }

        //Contact Number
        public string secondaryContactNumber { get; set; }

        //Work In Period
        public int workInPeriod { get; set; }

        //Line Of Buisness
        public string lineOfBuisness { get; set; }

        //Monthly Income
        public int monthlyIncome { get; set; }

        //Net Monthly Income
        public int netMonthlyIncome { get; set; }

        //Loan Amount
        public int loanAmount { get; set; }

        //Other faimly Income
        public int otherFaimlyIncome { get; set; }

        //Previous account details
        public string currentAccountingAndSavingAccount { get; set; }

        //Other Bank Loan
        public string otherBankLoan { get; set; }

        //Loan Details  
        public string loanDetails { get; set; }

        //Bank Name
        public string bankName { get; set; }

        //EMI
        public int otherLoanEmi { get; set; }

        //Buisness Proof any registration
        public string buisnessProofAnyRegistration { get; set; }

        //Property valuation
        public string propertyValuation { get; set; }

        //First Refrence 
        public string refrenceOne { get; set; }

        //Second Reference
        public string refrenceTwo { get; set; }

        //ITR 3 year 
        public string iTR3Year { get; set; }

        //Visit BY
        public string visitBy { get; set; }

        //Property valuation
        public string companyName { get; set; }

        //Company Address
        public string companyAddress { get; set; }

        //PAN card
        public string panCard { get; set; }

        //Refer By
        public string referBy { get; set; }

        //customerReaction
        public bool customerReaction { get; set; }

        //assignTo
        public string assignTo { get; set; }

        //processStep
        public int processStep { get; set; }

        //Irs refrence
        public int isReference { get; set; }

        //refrence ID
        public int referenceId { get; set; }

        // Refernece count
        public int referenceCount { get; set; }

    }
}
