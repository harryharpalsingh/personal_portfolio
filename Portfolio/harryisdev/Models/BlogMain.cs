using System.ComponentModel.DataAnnotations;

namespace harryisdev.Models
{
    public class BlogMain
    {
        [Key]
        public int Id { get; set; }

        public int ImageID { get; set; } = 0;

        [Required]
        public string ContentText { get; set; } = string.Empty;

        public int CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; } = DateTime.Now;
    }
}
