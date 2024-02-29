using CourseEnrollmentApp_Portal.Services;
using Microsoft.AspNetCore.Components;

namespace CourseEnrollmentApp_Portal.Pages
{
    public partial class SigninBase : ComponentBase
    {
        [Inject]
        public AuthService AuthService { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
