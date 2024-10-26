using System.ComponentModel.DataAnnotations;

namespace harryisdev.Models
{
    public class BlogMaster
    {
        [Key]
        public int Id { get; set; }

        public int ImageID { get; set; } = 0;

        [Required(ErrorMessage = "Blog title is required")]
        [MaxLength(100, ErrorMessage = "Title cannot be more than 100 characters")]
        public string BlogTitle { get; set; } = string.Empty;

        [Required(ErrorMessage = "Blog content is required")]
        //[MaxLength(500, ErrorMessage = "Content cannot exceed 500 characters")]
        public string BlogData { get; set; } = string.Empty;

        public int CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; } = DateTime.Now;
    }
}
