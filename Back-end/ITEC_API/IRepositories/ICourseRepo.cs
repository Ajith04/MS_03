using ITEC_API.Models;

namespace ITEC_API.IRepositories
{
    public interface ICourseRepo
    {
        Task addNewCourse(MainCourse mainCourse, CourseLevel courseLevel);
        Task<List<MainCourse>> getAllCourses();
    }
}
