using ITEC_API.DTO.RequestDTO;
using ITEC_API.DTO.ResponseDTO;

namespace ITEC_API.IServices
{
    public interface ICourseService
    {
        Task addNewCourse(CourseRequestDTO courseRequest);
        Task<List<MainCourseResponseDTO>> getAllCourses();
    }
}
