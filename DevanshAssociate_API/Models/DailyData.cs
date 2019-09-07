using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevanshAssociate_API.Models
{
    public class DailyData
    {
        public int id { get; set; }
        public string name { get; set; }
        public string primaryContactNumber { get; set; }
        public string secondaryContactNumber { get; set; }
        public int customerReaction { get; set; }
        public string assignTo { get; set; }
    }
}
