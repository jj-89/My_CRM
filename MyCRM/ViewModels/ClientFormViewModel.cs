using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyCRM.ViewModels
{
    public class ClientFormViewModel
    {
        public int ClientID { get; set; }

        [Required(ErrorMessage = "Your first name is required.")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Your last name is required.")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }


        public string CompanyName { get; set; }


        public string Email { get; set; }


        public int PhoneNumber { get; set; }

        [Required(ErrorMessage = "I need to know which product/service you are interested in, and your preferred method of contact.")]
        [Display(Name = "Brief description of the product/service you are interested in.")]
        public string Message { get; set; }

    }
}
