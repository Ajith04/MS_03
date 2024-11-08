using ITEC_API.DTO.RequestDTO;

namespace ITEC_API.IServices
{
    public interface ICourseService
    {
        Task addNewCourse(MainCourseRequestDTO maincourserequestdto);
    }
}
