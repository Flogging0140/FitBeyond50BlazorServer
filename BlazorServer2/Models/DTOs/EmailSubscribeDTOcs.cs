using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;

namespace BlazorServer2.Models.DTOs
{
    public class EmailSubscribeDTO
    {
        [EmailAddress]
        [System.ComponentModel.DataAnnotations.Required]
        public string EmailAddress { get; set; } = default!;
    }
}
