//using Microsoft.UI.Xaml.Controls;
//using Microsoft.UI.Xaml.Input;

using Sudoku_Solver.Resources.Localisation;
using String = Sudoku_Solver.Resources.Localisation.String;

namespace Sudoku_Solver
{
    public partial class AboutPage : ContentPage
    {
        
        public AboutPage()
        {
           InitializeComponent();
            Version_label.Text = String.version_Text + " " + VersionTracking.Default.CurrentVersion;
        }
        private async void SolverOnGitLink(object? sender, EventArgs e)
        {
            try
            {
                await Browser.Default.OpenAsync("https://github.com/del0ct/Sudoku_Solver", BrowserLaunchMode.SystemPreferred);
            }
            catch
            {
                await DisplayAlert(String.error, String.noapp, String.ok);
            }// An unexpected error occurred. No browser may be installed on the device.
        }
        
        private async void MeOnGitLink(object? sender, EventArgs e)
        {
            try
            {
                await Browser.Default.OpenAsync("https://github.com/del0ct?tab=repositories", BrowserLaunchMode.SystemPreferred);
            }
            catch
            {
                await DisplayAlert(String.error, String.noapp, String.ok);
            }// An unexpected error occurred. No browser may be installed on the device.
        }
    }
}
