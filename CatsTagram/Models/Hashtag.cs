using System.ComponentModel.DataAnnotations;

namespace CatsTagram.Models
{
    public class Hashtag
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(280)]

        public string Text { get;  }
        public int CatPostId { get; set; }
        public Post Post { get; set; }
    }
}
