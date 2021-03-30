using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Vjezba.Model
{
    public class Client
    {
        [Key]
        public int ID { get; set; }
        [StringLength(20, MinimumLength = 2)]
        [Required(ErrorMessage = "Morate unjeti vaše ime!")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Morate unjeti vaše Prezime!")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Morate unjeti e-mail adresu")]
        [EmailAddress(ErrorMessage = "Kriva e-mail adresa")]
        public string Email { get; set; }
        public char Gender { get; set; }
        public string Address { get; set; }
        [Required(ErrorMessage = "Morate unjeti broj za kontakt!")]
        public string PhoneNumber { get; set; }

        //[Range(0, 100)]
        //public int? WorkingExperience { get; set; }

        [ForeignKey(nameof(City))]
        public int? CityID { get; set; }
        public City City { get; set; }

        public string FullName => $"{FirstName} {LastName}";

        public virtual ICollection<Meeting> Meetings { get; set; }

    }
}
