using System;

namespace landmark_remark_API.Models
{
    // Marker Note Model
    public class MarkerNote
    {
        public int Id { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public string Note { get; set; }        
        public DateTime CreatedDate { get; set; }
        
        public User User { get; set; }
        public int UserId { get; set; }
    }
}