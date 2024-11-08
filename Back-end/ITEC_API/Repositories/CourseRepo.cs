using ITEC_API.Database;

namespace ITEC_API.Repositories
{
    public class CourseRepo
    {
        private readonly ITECDbContext _itecdbcontext;

        public CourseRepo(ITECDbContext itecdbcontext)
        {
            _itecdbcontext = itecdbcontext;
        }
    }
}
