using System;

namespace landmark_remark_API.Dtos
{
    public class MarkerNoteForReturnDto
    {
        public int Id { get; set; }
        public int Longitude { get; set; }
        public int Latitude { get; set; }
        public string Note { get; set; }
        public DateTime CreatedDate { get; set; }

        public int UserId { get; set; }
        public string Username { get; set; }
    }
}