using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using MVCDemo2.Models.Interface;

namespace MVCDemo2.Models
{
    public class UserModel : IEntity
    {
        [Required]
        [Key]
        public int Id { get; set; }

        [Display(Name = "Förnamn")]
        [Required(ErrorMessage = "Förnamn måste anges")]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        [EmailAddress(ErrorMessage = "Not A valid Email")]
        public string Email { get; set; }
        [DataType(DataType.Date)]
        public DateTime Birthdate { get; set; }
        [Range(100, 10000)]
        public decimal Salary { get; set; }

    }
}