//using Microsoft.UI.Xaml.Controls;
//using Microsoft.UI.Xaml.Input;

namespace Sudoku_Solver
{
    public partial class AboutPage : ContentPage
    {
        
        public AboutPage()
        {
           InitializeComponent();

        }
        private async void SolverOnGitLink(object? sender, EventArgs e)
        {
            try
            {
                await Browser.Default.OpenAsync("https://www.microsoft.com", BrowserLaunchMode.SystemPreferred);
            }
            catch
            {
                await DisplayAlert("Error", "No accepted app", "Ok");
            }// An unexpected error occurred. No browser may be installed on the device.
        }
        
        private async void MeOnGitLink(object? sender, EventArgs e)
        {
            try
            {
                await Browser.Default.OpenAsync("https://www.microsoft.com", BrowserLaunchMode.SystemPreferred);
            }
            catch
            {
                await DisplayAlert("Error", "No accepted app", "Ok");
            }// An unexpected error occurred. No browser may be installed on the device.
        }
    }
}
