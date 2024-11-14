namespace ITEC_API.DTO.ResponseDTO
{
    public class CourseLevelResponseDTO
    {
        public string CourseId { get; set; }
        public string Level { get; set; }
        public byte[] Thumbnail { get; set; }
        public string Duration { get; set; }
        public decimal CourseFee { get; set; }
        public List<string> Instructors { get; set; }
    }
}
