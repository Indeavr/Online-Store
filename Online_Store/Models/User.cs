﻿using System.ComponentModel.DataAnnotations;

namespace Online_Store.Models
{
    public class User
    {
        public User()
        {
        }

        public User(string username, string hashedPassword)
        {
            this.Username = username;
            this.Password = hashedPassword;
        }

        public int Id { get; set; }

        [Required]
        [StringLength(12, MinimumLength = 2, ErrorMessage = "Username must be between 2 and 12 symbols long")]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        public int? CardId { get; set; }

        public virtual Cart Cart { get; set; }

        public virtual Seller Seller { get; set; }
    }
}
