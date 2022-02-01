using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication.Models
{
    public class ApplicationResponse
    {
        [Key]
        [Required]
        public int ApplicationId { get; set; }
        //Build Foreign Key Relationship
        [Required]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        [Required(ErrorMessage = "Enter Title")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Enter Year")]
        public int Year { get; set; }
        [Required(ErrorMessage = "Enter Director")]
        public string Director { get; set; }
        [Required(ErrorMessage = "Enter Rating")]
        public string Rating { get; set; }
        public bool Edited { get; set; }
        public string Lentto { get; set; }
        [MaxLength(25)]
        public string Notes { get; set; }
    }
}
