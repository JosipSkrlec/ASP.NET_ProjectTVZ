using System;
<<<<<<< HEAD
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
=======
using System.ComponentModel.DataAnnotations;
>>>>>>> ca337c58b2cd131e98988edf6f40063ec79d1352

namespace Vjezba.Model
{
    public class Meeting
    {
<<<<<<< HEAD
        public int Id { get; set; }
        public string Location { get; set; }
        public MeetingType Type { get; set; }
        public MeetingStatus Status { get; set; }
        public DateTime? Start { get; set; }
        public DateTime? End { get; set; }
        public string Comments { get; set; }

        [ForeignKey(nameof(Client))]
        public int ClientID { get; set; }
        public Client Client { get; set; }
    }

    public enum MeetingType { InPerson, VideoCall }
    public enum MeetingStatus { Scheduled, Cancelled }
=======
        [Key]
        public int ID { get; set; }
        public string VideoCall { get; set; }
        public DateTime VideoCallStartDate { get; set; }
        public DateTime VideoCallEndDate { get; set; }
        public string Scheduled { get; set; }
        public string Cancelled { get; set; }
        public string Location { get; set; }
        public string Comments { get; set; }


    }
>>>>>>> ca337c58b2cd131e98988edf6f40063ec79d1352
}
