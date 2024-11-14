using ITEC_API.Database;
using ITEC_API.IRepositories;
using ITEC_API.Models;
using Microsoft.EntityFrameworkCore;

namespace ITEC_API.Repositories
{
    public class CourseRepo : ICourseRepo
    {
        private readonly ITECDbContext _itecdbcontext;

        public CourseRepo(ITECDbContext itecdbcontext)
        {
            _itecdbcontext = itecdbcontext;
        }

        public async Task addNewCourse(MainCourse mainCourse, CourseLevel courseLevel)
        {
            var existCourse = await _itecdbcontext.MainCourses.SingleOrDefaultAsync(r => r.CourseName == mainCourse.CourseName);

            if (existCourse == null) {
                await _itecdbcontext.MainCourses.AddAsync(mainCourse);
                await _itecdbcontext.SaveChangesAsync();
            }
            else
            {
                courseLevel.MainCourseId = existCourse.MainCourseId;
                await _itecdbcontext.CourseLevels.AddAsync(courseLevel);
                await _itecdbcontext.SaveChangesAsync();
            }
        }

        public async Task<List<MainCourse>> getAllCourses()
        {
            var allCourses = await _itecdbcontext.MainCourses
                .Include(mc => mc.CourseLevels)
                .ThenInclude(cl => cl.InstructorEnrollments)
                .ThenInclude(ie => ie.Instructor).ToListAsync();
            
            return allCourses;
        }
    }
}
