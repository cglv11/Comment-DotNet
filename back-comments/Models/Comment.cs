using System;
using System.ComponentModel.DataAnnotations;

namespace back_comments.Models
{
    public class Comment
    {
        public int Id { get; set; }
        [Required]
        public string? Title { get; set; }
        [Required]
        public string? Creator { get; set; }
        [Required]
        public string? Text { get; set; }
        [Required]
        public DateTime DateCreation { get; set; }
    }
}
