namespace CourseEnrollmentApp_Portal.Models
{
    public class StudentEnrollment : CommonModel
    {
        public string StudentId { get; set; }
        public long CourseId { get; set; }
        public Student Student { get; set; }
        public Course Course { get; set; }
    }
}
