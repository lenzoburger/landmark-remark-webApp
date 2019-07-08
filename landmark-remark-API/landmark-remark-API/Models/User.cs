using System;
using System.Collections.Generic;

namespace landmark_remark_API.Models
{
     // User Model
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string Email { get; set; }        
        public DateTime CreatedDate { get; set; }
        public ICollection<MarkerNote> UserMarkerNotes{ get; set; }       
    }
}