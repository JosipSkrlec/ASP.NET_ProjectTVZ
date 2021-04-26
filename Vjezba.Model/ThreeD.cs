using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

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

        // zapise se tko je kreiramo i updejtao
        public String CreatedBy { get; set; }
        public String UpdatedBy { get; set; }

        [ForeignKey( nameof(ThreeDCategory))]
        public int? CategoryID { get; set; }
        public ThreeDCategory Category { get; set; }

        [ForeignKey(nameof(OBJAttachment))]
        public int? objAttachmentID { get; set; }
        public OBJAttachment objAttachment { get; set; }

    }

}
