using CourseEnrollmentApp_Portal.Models;
using CourseEnrollmentApp_Portal.Services;
using Microsoft.AspNetCore.Components;
using static CourseEnrollmentApp_Portal.Services.Common;

namespace CourseEnrollmentApp_Portal.Pages
{
    public partial class IndexBase : ComponentBase
    {
        [Inject]
        public AuthService AuthService { get; set; }
        [Inject]
        HttpService HttpService { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        [CascadingParameter]
        public User User { get; set; }
        public record Employee(string Name, string Position, int YearsEmployed, int Salary, int Rating);
        public string Email { get; set; }
        public string Password { get; set; }
        public IEnumerable<Employee> employees;

        public IEnumerable<Course> Courses;
        protected override async Task OnInitializedAsync()
        {
            Courses = await HttpService.SendGetAsync<IEnumerable<Course>>("/api/course");
        }
        public void GoToCourse(long Id)
        {
            NavigationManager.NavigateTo($"/{PAGES.course}/{Id}");
        }
    }
}
