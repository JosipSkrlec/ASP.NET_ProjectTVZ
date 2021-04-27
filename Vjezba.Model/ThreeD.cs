using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vjezba.Model
{
    public class ThreeD
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Comment is required")]
        public string Comment { get; set; }
        public DateTime UploadedDateTime { get; set; }

        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }

        [ForeignKey( nameof(ThreeDCategory))]
        [Required(ErrorMessage = "Category need to be selected")]
        public int CategoryID { get; set; }
        public ThreeDCategory Category { get; set; }

        [ForeignKey(nameof(OBJAttachment))]
        public int? objAttachmentID { get; set; }
        public OBJAttachment objAttachment { get; set; }

        //[ForeignKey(nameof(OBJAttachmentTexture))]
        //[Required(ErrorMessage = "Texture need to be selected")]
        //public int TextureID { get; set; }
        //public OBJAttachmentTexture Texture { get; set; }
    }

}
