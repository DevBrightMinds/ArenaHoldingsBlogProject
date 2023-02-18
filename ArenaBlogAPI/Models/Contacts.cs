using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ArenaBlogAPI.Models
{
    public class Contacts
    {
        public int ID { get; set; }
        [Required]
        public string Names { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string Content { get; set; }

    }
}