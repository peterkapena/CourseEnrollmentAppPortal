using System.ComponentModel.DataAnnotations;

namespace CourseEnrollmentApp_Portal.Models
{
    public class Course
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        public long Id { get; set; }
        public ICollection<StudentEnrollment> StudentEnrollments { get; set; }

    }
}
