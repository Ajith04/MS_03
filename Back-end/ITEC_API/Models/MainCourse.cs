using System.ComponentModel.DataAnnotations;

namespace ITEC_API.Models
{
    public class MainCourse
    {
        [Key]
        public int MainCourseId { get; set; }
        public string CourseName { get; set; }

        public virtual ICollection<CourseLevel> CourseLevels { get; set; }
    }
}
