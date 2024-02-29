using CourseEnrollmentApp_Portal.Models;
using CourseEnrollmentApp_Portal.Services;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace CourseEnrollmentApp_Portal.Pages
{
    public partial class SignupBase : ComponentBase
    {
        [Inject]
        public AuthService AuthService { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        [CascadingParameter] public User User { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
    }
}
