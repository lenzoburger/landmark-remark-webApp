using System;
using System.ComponentModel.DataAnnotations;

namespace landmark_remark_API.Dtos
{
    public class UserRegisterDto
    {
        [Required]
        public string Username { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 8, ErrorMessage = "You must specify a password between 8 and 20 characters.")]
        public string Password { get; set; }

        [Required]
        public string Email { get; set; }

        public DateTime CreatedDate { get; set; }

        public UserRegisterDto()
        {
            CreatedDate = DateTime.Now;
        }
    }
}