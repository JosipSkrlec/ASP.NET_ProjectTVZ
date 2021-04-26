using System.ComponentModel.DataAnnotations;

namespace Vjezba.Model
{
    public class ThreeDCategory
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }

    }
}
