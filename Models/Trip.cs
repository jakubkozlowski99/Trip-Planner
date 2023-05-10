﻿using System.ComponentModel.DataAnnotations;

namespace Test_web_app.Models
{
    public class Trip
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(15)]
        public string Title { get; set; }

        public string? Description { get; set; }
        public string? User { get; set; }

    }
}
