﻿using Microsoft.Extensions.Hosting;
using System.ComponentModel.DataAnnotations;

namespace MVC_MAINTEST.Models
{
    public class User
    {
        [Key]
        public int uId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public ICollection<Post> Posts { get; set; }
    }
}
