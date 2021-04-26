using System.ComponentModel.DataAnnotations;

namespace Vjezba.Model
{
    public class OBJAttachmentTexture
    {
        [Key]
        public int ID { get; set; }
        public string TexturePath { get; set; }


    }
}
