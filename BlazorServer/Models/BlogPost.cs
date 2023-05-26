using System.ComponentModel.DataAnnotations;

namespace BlazorServer.Models
{
    public class BlogPost
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string PostTitle { get; set; } = default!;

        //[Column(TypeName = "text")]
        [Required]
        public string? PostHtmlContent { get; set; } = default!;
        public string PostAuthor { get; set; } = "Boyd Hanel";
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
    }
}
