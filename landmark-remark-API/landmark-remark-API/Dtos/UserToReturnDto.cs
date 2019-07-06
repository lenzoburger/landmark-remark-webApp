using System;

namespace landmark_remark_API.Dtos
{
    public class UserToReturnDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}