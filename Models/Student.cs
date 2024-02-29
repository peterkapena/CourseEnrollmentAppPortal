namespace CourseEnrollmentApp_Portal.Models
{
    public class Student
    {
        public string StudentId { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public ICollection<StudentEnrollment> StudentEnrollments { get; set; }
    }
}
