using CourseEnrollmentApp_Portal.Models;
using CourseEnrollmentApp_Portal.Services;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using static CourseEnrollmentApp_Portal.Services.Common;

namespace CourseEnrollmentApp_Portal.Pages
{
    public partial class StudentCoursesPageBase : ComponentBase, IDisposable
    {
        [Inject]
        public AuthService AuthService { get; set; }
        [Inject]
        HttpService HttpService { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        [Inject]
        LoadingService LoadingService { get; set; }
        [CascadingParameter]
        public User User { get; set; }
        public record Employee(string Name, string Position, int YearsEmployed, int Salary, int Rating);

        public List<Course> Courses;
        protected override async Task OnInitializedAsync()
        {
            LoadingService.OnLoadingStateChanged += StateHasChanged;

            await GetCourses();
        }

        private async Task GetCourses()
        {
            Courses = await HttpService.SendGetAsync<List<Course>>($"/api/studentenrollment/{User.UserId}");
        }

        public async Task Deregister(long courseId)
        {
            try
            {
                if (User is not null && User.UserId is not null)
                {

#nullable enable
                    await HttpService.SendDeleteAsync<StudentEnrollment?>($"/api/studentenrollment/{User.UserId}/{courseId}");
#nullable disable
                    await GetCourses();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }
        public void GoToCourse(long Id)
        {
            NavigationManager.NavigateTo($"/{PAGES.course}/{Id}");
        }
        void IDisposable.Dispose() => LoadingService.OnLoadingStateChanged -= StateHasChanged;
    }
}
