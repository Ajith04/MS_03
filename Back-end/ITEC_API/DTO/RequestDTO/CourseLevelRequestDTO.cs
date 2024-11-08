using ITEC_API.Models;

namespace ITEC_API.DTO.RequestDTO
{
    public class CourseLevelRequestDTO
    {
        public string CourseId { get; set; }
        public string Level { get; set; }
        public byte[] Thumbnail { get; set; }
        public string Duration { get; set; }
        public decimal CourseFee { get; set; }
    }
}
