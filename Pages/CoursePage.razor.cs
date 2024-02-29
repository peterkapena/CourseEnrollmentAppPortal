using CourseEnrollmentApp_Portal.Models;
using CourseEnrollmentApp_Portal.Services;
using Microsoft.AspNetCore.Components;
using static CourseEnrollmentApp_Portal.Services.Common;

namespace CourseEnrollmentApp_Portal.Pages
{
    public partial class ICoursePageBase : ComponentBase, IDisposable
    {
        [Inject]
        public AuthService AuthService { get; set; }
        [Inject]
        HttpService HttpService { get; set; }
        [Inject]
        LoadingService LoadingService { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        [CascadingParameter]
        public User User { get; set; }
        [Parameter]
        public long Id { get; set; }
        public bool ErrorHappened;
        public record Employee(string Name, string Position, int YearsEmployed, int Salary, int Rating);

        public Course Course;
        public StudentEnrollment StudentEnrollment;
        protected override async Task OnInitializedAsync()
        {
            LoadingService.OnLoadingStateChanged += StateHasChanged;
            Course = await HttpService.SendGetAsync<Course>($"/api/course/{Id}");
            StudentEnrollment = await HttpService.SendGetAsync<StudentEnrollment>($"/api/StudentEnrollment/{User.UserId}/{Id}");
        }

        public async Task Enroll()
        {
            LoadingService.ShowLoading();
            try
            {
                if (User is not null && User.UserId is not null && Id > 0)
                {
                    var enrollment = await HttpService.SendPostAsync<StudentEnrollment>($"/api/studentenrollment/{User.UserId}/{Id}");
                    if (enrollment != null)
                    {
                        LoadingService.HideLoading();
                        NavigationManager.NavigateTo($"/{PAGES.mycourses}");
                    }
                }
            }
            catch (Exception)
            {
                ErrorHappened = true;
            }
            LoadingService.HideLoading();
        }
        void IDisposable.Dispose() => LoadingService.OnLoadingStateChanged -= StateHasChanged;
    }
}
