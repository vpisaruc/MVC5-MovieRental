using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.Dtos
{
    public class CustomerDto
    {
        public int Id { get; set; }

        // forbids nulls in Name column
        [Required(ErrorMessage = "Please enter the Name!")]
        // Limits characters in string 
        [StringLength(255)]
        public string Name { get; set; }

        //[Min18YearsIfAMember]
        public DateTime BirthDate { get; set; }

        public bool IsSubscribedToNewsLetter { get; set; }

        public byte MembershipTypeId { get; set; }

        public MembershipTypeDto MembershipType { get; set; }
        
    }
}