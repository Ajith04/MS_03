using ITEC_API.Models;

namespace ITEC_API.DTO.ResponseDTO
{
    public class MainCourseResponseDTO
    {
        public string CourseName { get; set; }
        public List<CourseLevelResponseDTO> CourseLevelResponse { get; set; }
    }
}
