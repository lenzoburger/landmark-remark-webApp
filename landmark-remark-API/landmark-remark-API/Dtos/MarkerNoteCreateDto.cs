using System;

namespace landmark_remark_API.Dtos
{
    public class MarkerNoteCreateDto
    {
        public int Longitude { get; set; }
        public int Latitude { get; set; }
        public string Note { get; set; }
        public DateTime CreatedDate { get; set; }

        public int UserId  { get; set; }
        public MarkerNoteCreateDto()
        {
            CreatedDate = DateTime.Now;
        }
    }
}