using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCRM.Models
{
    public class ClientForm
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CompanyName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Message { get; set; }
        public int NumberOfCalls { get; set; }
        public string CallLog { get; set; }
    }
}
