using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CatsTagram.Models
{
    public class Post
    {
        [Key]

        public int Id { get; set; }

        [Required]
        [Display (Name = "AuthorName")]
        public string AuthorName { get; set; }

        public string AuthorEmail { get; set; } = "default@email.com";


        [MaxLength(255)]
        [Display(Name = "Comment")]
        public string Comment { get; set; }

        public DateTime DateAdded { get; set; }

        [Required]

        [Display(Name = "ImageData")]
        public string ImageData { get; set; }

        
       

        public ICollection<Hashtag> Hashtags { get; set; }
    }

}
