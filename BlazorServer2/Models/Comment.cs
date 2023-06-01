using Microsoft.AspNetCore.Identity;
using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorServer2.Models
{
    public class Comment
    {
        public int Id { get; set; }

        [Required]
        public string email { get; set; } = default!;

        [Required]
        public string Text { get; set; } = default!;

        //public IdentityUser User { get; set; } = default!;
        public string UserId { get; set; } = default!;
    }
}
