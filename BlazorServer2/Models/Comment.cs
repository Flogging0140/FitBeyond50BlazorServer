using Microsoft.AspNetCore.Identity;
using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;

namespace BlazorServer2.Models
{
    public class Comment
    {
        public int Id { get; set; }

        [Required]
        public string email { get; set; } = default!;

        [Required]
        [MinLength(10)]
        [MaxLength(200)]
        public string Text { get; set; } = default!;

        //public IdentityUser User { get; set; } = default!;
        public string UserId { get; set; } = default!;

        public int BlogPostId { get; set; } = default!;
    }
}
