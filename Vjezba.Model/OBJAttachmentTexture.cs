using System.ComponentModel.DataAnnotations;

namespace Vjezba.Model
{
    public class OBJAttachmentTexture
    {
        [Key]
        public int ID { get; set; }
        public string AlbedoTexturePath { get; set; }
        public string NormalTexturePath { get; set; }
        public string HightTexturePath { get; set; }


    }
}
