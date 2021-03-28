<<<<<<< HEAD:Vjezba.Model/Client.cs
﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

=======
﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
//
>>>>>>> ca337c58b2cd131e98988edf6f40063ec79d1352:Vjezba.Web/Mock/Client.cs
namespace Vjezba.Model
{
    public class Client
    {
        [Key]
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public char Gender { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
<<<<<<< HEAD:Vjezba.Model/Client.cs

        [ForeignKey(nameof(City))]
=======
        //[ForeignKey("City")]
>>>>>>> ca337c58b2cd131e98988edf6f40063ec79d1352:Vjezba.Web/Mock/Client.cs
        public int? CityID { get; set; }
        public City City { get; set; }
        public string FullName => $"{FirstName} {LastName}";      

        public virtual ICollection<Meeting> Meetings { get; set; }

    }
}
