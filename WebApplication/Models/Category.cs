﻿using System;
using System.ComponentModel.DataAnnotations;
namespace WebApplication.Models
{
    public class Category
    {
        [Key]
        [Required]
        public int CategoryId { get; set; }

        public string CategoryName { get; set; }
        
        
    }
}
