using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Vjezba.Model
{
    public class ThreeDModel
    {
        public int Id { get; set; }
        public string Location { get; set; }
        public MeetingType Type { get; set; }
        public MeetingStatus Status { get; set; }
        public DateTime? Start { get; set; }
        public DateTime? End { get; set; }
        public string Comments { get; set; }

        //[ForeignKey(nameof(Client))]
        public int ClientID { get; set; }
        public Client Client { get; set; }
    }

}
