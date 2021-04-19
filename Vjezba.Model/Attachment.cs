using System;
using System.ComponentModel.DataAnnotations;

namespace Vjezba.Model
{
    public class Attachment
    {
        [Key]
        public int ID { get; set; }
        public String File { get; set; }
    }
}
