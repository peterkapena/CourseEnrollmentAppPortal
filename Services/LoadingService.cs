namespace CourseEnrollmentApp_Portal.Services
{
    public class LoadingService
    {
        private bool _isLoading = true;
        public bool IsLoading
        {
            get => _isLoading;
            private set
            {
                if (_isLoading == value) return;
                _isLoading = value;
                NotifyStateChanged();
            }
        }
#nullable enable
        public event Action? OnLoadingStateChanged;
#nullable disable

        private void NotifyStateChanged() => OnLoadingStateChanged?.Invoke();

        public void ShowLoading() => IsLoading = true;

        public void HideLoading() => IsLoading = false;
    }
}
