using System.ComponentModel.DataAnnotations;

namespace harryisdev.Models
{
    public class BlogMaster
    {
        [Key]
        public int Id { get; set; }

        public int ImageID { get; set; } = 0;

        [Required]
        public string BlogTitle { get; set; } = string.Empty;

        [Required]
        public string BlogData { get; set; } = string.Empty;

        public int CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; } = DateTime.Now;
    }
}
