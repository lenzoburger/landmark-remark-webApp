using System;

namespace landmark_remark_API.Dtos
{
    public class MarkerNoteForReturnDto
    {
        public int Id { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public string Note { get; set; }
        public DateTime CreatedDate { get; set; }

        public int UserId { get; set; }
        public string Username { get; set; }
    }
}