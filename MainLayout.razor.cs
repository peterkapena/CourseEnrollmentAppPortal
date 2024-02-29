using Blazored.LocalStorage;
using CourseEnrollmentApp_Portal.Models;
using CourseEnrollmentApp_Portal.Services;
using Microsoft.AspNetCore.Components;
using static CourseEnrollmentApp_Portal.Services.Common;

namespace CourseEnrollmentApp_Portal
{
    public partial class MainLayoutBase : LayoutComponentBase
    {
        [Inject]
        public AuthService AuthService { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        [Inject]
        public ILocalStorageService LocalStorage { get; set; }
        [Inject]
        public LoadingService LoadingService { get; set; }
        public User User { get; set; }
        //public bool isLoading = true;

        protected override async Task OnInitializedAsync()
        {
            User = await AuthService.GetCurrentUserAsync();
            //isLoading = false; // Authentication check completed
            LoadingService.HideLoading();
            if (!AuthService.IsAuthenticated)
            {
                NavigationManager.NavigateTo($"{PAGES.signin}");
            }
        }
    }
}
