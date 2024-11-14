namespace ITEC_API.DTO.RequestDTO
{
    public class CourseRequestDTO
    {
        public string CourseId { get; set; }
        public string CourseName { get; set; }
        public string Level { get; set; }
        public IFormFile Thumbnail { get; set; }
        public string Duration { get; set; }
        public decimal CourseFee { get; set; }
    }
}
