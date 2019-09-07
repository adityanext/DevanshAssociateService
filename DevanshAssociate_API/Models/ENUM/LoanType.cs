using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevanshAssociate_API.Models.ENUM
{
    public enum LoanType
    {
        /// <summary>
        /// Personal loan
        /// </summary>
        PersonalLoan = 1,

        /// <summary>
        /// Buisness Loan
        /// </summary>
        BuisnessLoan = 2,

        /// <summary>
        /// Loan against property
        /// </summary>
        LoanAgainstProperty = 3,

        /// <summary>
        /// Home Loan
        /// </summary>
        HomeLoan = 4,

        /// <summary>
        /// Education Loan
        /// </summary>
        EducationLoan = 5,

        /// <summary>
        /// Property Loan
        /// </summary>
        PropertyLoan = 6
    }

    public enum OperationType
    {
        SAVE = 1,
        GET_All = 2,
        UPDATE = 3,
        DELETE = 4,
        GET = 5,
        PROCESSSTEP = 6,
    }
}
