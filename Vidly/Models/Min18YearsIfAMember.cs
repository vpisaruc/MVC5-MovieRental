using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Min18YearsIfAMember : ValidationAttribute
    {
        // пишем свою логику для валидации даты рождения
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer) validationContext.ObjectInstance;
            // если тип подписки PayAsYouGo то возраст нам не важен
            if (customer.MembershipTypeId == MembershipType.Unknown || 
                customer.MembershipTypeId == MembershipType.PayAsYouGo)
            {
                return ValidationResult.Success;
            }
            if (customer.BirthDate == null)
            {
                return new ValidationResult("Birth Date is required");
            }

            var age = DateTime.Today.Year - customer.BirthDate.Year;

            return (age >= 18)
                ? ValidationResult.Success
                : new ValidationResult("Customer should be at least 18 years old to go on a membership.");

        }
    }
}