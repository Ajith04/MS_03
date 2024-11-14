using ITEC_API.DTO.RequestDTO;
using ITEC_API.DTO.ResponseDTO;
using ITEC_API.IRepositories;
using ITEC_API.IServices;
using ITEC_API.Models;

namespace ITEC_API.Services
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepo _icourserepo;
        public CourseService(ICourseRepo icourserepo)
        {
            _icourserepo = icourserepo;
        }

        public async Task addNewCourse(CourseRequestDTO courseRequest)
        {
            
                var courseLevel = new CourseLevel()
                {
                    CourseId = courseRequest.CourseId,
                    Level = courseRequest.Level,
                    Duration = courseRequest.Duration,
                    CourseFee = courseRequest.CourseFee,
                };

                if (courseRequest.Thumbnail != null)
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        await courseRequest.Thumbnail.CopyToAsync(memoryStream);
                        courseLevel.Thumbnail = memoryStream.ToArray();
                    }
                }


                var mainCourse = new MainCourse()
                {
                    CourseName = courseRequest.CourseName,
                    CourseLevels = new List<CourseLevel>() { courseLevel }
                };

                await _icourserepo.addNewCourse(mainCourse, courseLevel);

            


        }


        public async Task<List<MainCourseResponseDTO>> getAllCourses()
        {

            var allCourses = await _icourserepo.getAllCourses();

            var courseList = new List<MainCourseResponseDTO>();

            foreach (var course in allCourses)
            {
                var mainCourseResponse = new MainCourseResponseDTO
                {
                    CourseName = course.CourseName,
                    CourseLevelResponse = new List<CourseLevelResponseDTO>()

                };

                foreach (var level in course.CourseLevels)
                {
                    var courseLevelResponse = new CourseLevelResponseDTO
                    {
                        CourseId = level.CourseId,
                        Level = level.Level,
                        Thumbnail = level.Thumbnail,
                        Duration = level.Duration,
                        CourseFee = level.CourseFee,
                        Instructors = new List<String>()
                    };

                    foreach(var instructorEnrollment in level.InstructorEnrollments)
                    {
                        if(instructorEnrollment.Instructor != null && !courseLevelResponse.Instructors.Contains(instructorEnrollment.Instructor.InstructorName))
                        {
                            courseLevelResponse.Instructors.Add(instructorEnrollment.Instructor.InstructorName);
                        }
                    }

                    mainCourseResponse.CourseLevelResponse.Add(courseLevelResponse);
                }

                courseList.Add(mainCourseResponse);
            }

            return courseList;
        }
    }
}
