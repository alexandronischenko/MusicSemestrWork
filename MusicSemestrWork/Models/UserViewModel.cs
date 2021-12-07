using System;
using Microsoft.AspNetCore.Http;

namespace MusicSemestrWork.Models
{
    public class UserViewModel
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

        //public bool isToken { get; set; }

        public string NewPassword { get; set; }
        public IFormFile Avatar { get; set; }
    }
}
