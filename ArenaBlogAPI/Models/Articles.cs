using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ArenaBlogAPI.Models
{
    public class Articles
    {
        public int ID { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        public string ArticleName { get; set; }
        [Required]
        public string DateCreated { get; set; }
        [Required]
        public string ImageUrl { get; set; }
        [Required]
        public string Content { get; set; }
    }
}