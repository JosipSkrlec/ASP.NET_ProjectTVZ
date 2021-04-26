using System.ComponentModel.DataAnnotations;

namespace Vjezba.Model
{
    public class OBJAttachment
    {
        [Key]
        public int ID { get; set; }
        public string OBJFilePath { get; set; }
    }
}
