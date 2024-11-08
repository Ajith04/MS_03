using System.ComponentModel.DataAnnotations;

namespace ITEC_API.Models
{
    public class CourseLevel
    {
        [Key]
        public string CourseId { get; set; }
        public string Level {  get; set; }
        public int MainCourseId { get; set; }
        public virtual MainCourse MainCourse { get; set; }
        public byte[] Thumbnail { get; set; }
        public string Duration { get; set; }
        public decimal CourseFee { get; set; }

        public virtual ICollection<InstructorEnrollment> InstructorEnrollments { get; set; }
    }
}
