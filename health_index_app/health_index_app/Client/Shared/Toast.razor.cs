using health_index_app.Client.Services;



namespace health_index_app.Client.Shared
{
    public partial class Toast
    {
        private string? _heading;
        private string? _message;
        private bool _isVisible;
        private string? _backgroundCssClass;
        private string? _iconCssClass;



        protected override void OnInitialized()
        {
            ToastService.OnShow += ShowToast;
            ToastService.OnHide += HideToast;
        }



        private void ShowToast(string message, ToastLevel level, int countdown)
        {
            BuildToastSettings(level, message);
            _isVisible = true;
            StateHasChanged();
        }



        private void HideToast()
        {
            _isVisible = false;
            StateHasChanged();
        }



        private void BuildToastSettings(ToastLevel level, string message)
        {
            switch (level)
            {
                case ToastLevel.Info:
                    _backgroundCssClass = $"bg-info";
                    _iconCssClass = "info";
                    _heading = "Info";
                    break;
                case ToastLevel.Success:
                    _backgroundCssClass = $"bg-success";
                    _iconCssClass = "check";
                    _heading = "Success";
                    break;
                case ToastLevel.Warning:
                    _backgroundCssClass = $"bg-warning";
                    _iconCssClass = "exclamation";
                    _heading = "Warning";
                    break;
                case ToastLevel.Error:
                    _backgroundCssClass = "bg-danger";
                    _iconCssClass = "times";
                    _heading = "Error";
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(level), level, null);
            }



            _message = message;
        }



        void IDisposable.Dispose()
        {
            ToastService.OnShow -= ShowToast;
            ToastService.OnHide -= HideToast;
        }
    }
}