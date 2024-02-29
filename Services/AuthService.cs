using System.Net.Http.Headers;
using System.Text.Json;
using System.Text;
using CourseEnrollmentApp_Portal.Models;
using Blazored.LocalStorage;

namespace CourseEnrollmentApp_Portal.Services
{
    public class AuthService
    {
        private readonly HttpService _httpService;
        private readonly ILocalStorageService _localStorage;
        private bool _isAuthenticated;
        public User CurrentUser { get; private set; }

        public AuthService(HttpService httpService, ILocalStorageService localStorage)
        {
            _httpService = httpService;
            _localStorage = localStorage;
        }

        public bool IsAuthenticated => _isAuthenticated;

        public async Task<bool> Signin(string email, string password)
        {
            var data = new
            {
                email,
                password
            };
            var user = await _httpService.SendPostAsync<User>("user/login", data, false);
            await _localStorage.SetItemAsync("user", user);
            _httpService.SetBearerToken(user.Token);
            _isAuthenticated = true;
            return true;
        }
        public async Task<bool> Signup(string email, string password, string name)
        {
            var data = new
            {
                email,
                password,
                name
            };
            var rslt = await _httpService.SendPostAsync<object>("user/register", data, false);

            return rslt is not null;
        }
        public async Task Signout()
        {
            await _localStorage.RemoveItemAsync("user");
            _isAuthenticated = false;
            CurrentUser = null;
        }

        public void Logout()
        {
            _httpService.SetBearerToken(null);
            _isAuthenticated = false;
        }
        public async Task<User> GetCurrentUserAsync()
        {
            var user = await _localStorage.GetItemAsync<User>("user");
            _httpService.SetBearerToken(user?.Token);
            _isAuthenticated = user is not null;
            return user;
        }
    }
}
