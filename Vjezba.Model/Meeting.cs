using System;
using System.ComponentModel.DataAnnotations;

namespace Vjezba.Model
{
    public class Meeting
    {
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
}
