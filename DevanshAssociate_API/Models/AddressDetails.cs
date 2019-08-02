using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevanshAssociate_API.Models
{
    public class AddressDetails
    {
        //Address Line
        public string addressLine { get; set; }

        //City
        public string city { get; set; }

        //State
        public string state { get; set; }

        //Postal code
        public string postalCode { get; set; }        
    }
}
