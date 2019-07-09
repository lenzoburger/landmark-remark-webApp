using System;

namespace landmark_remark_API.Dtos
{
    public class MarkerNoteCreateDto
    {
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public string Note { get; set; }
        public DateTime CreatedDate { get; set; }

        public int UserId  { get; set; }
        public MarkerNoteCreateDto()
        {
            CreatedDate = DateTime.Now;
        }
    }
}