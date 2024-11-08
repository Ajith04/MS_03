using ITEC_API.DTO.RequestDTO;
using ITEC_API.IRepositories;
using ITEC_API.Models;

namespace ITEC_API.Services
{
    public class CourseService
    {
        private readonly ICourseRepo _icourserepo;
        public CourseService(ICourseRepo icourserepo)
        {
            _icourserepo = icourserepo;
        }

        public async Task addNewCourse(MainCourseRequestDTO maincourserequestdto)
        {
            var mainCourse = new MainCourse()
            {
                CourseName = maincourserequestdto.CourseName,
                
            };
        }
    }
}
