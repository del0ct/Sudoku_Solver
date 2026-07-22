using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using Microsoft.Maui.Graphics.Text;

using locoliz = Sudoku_Solver.Resources.Localisation.String;

namespace Sudoku_Solver
{
    public partial class MainPage : ContentPage
    {
        private Entry[] tb = new Entry[82];
        bool Error_Data;
        readonly SolidColorBrush errorBrush = new(new Color(255, 0, 0));

        public Entry[] Tb { get => tb; set => tb = value; }
        public MainPage()
        {
           InitializeComponent();

            for (int i = 1; i <= 81; i++)
            {
                Tb[i] = new Entry();
                Layoot.Add(Tb[i], ((i - 1) % 9) + 2 + ((i - 1) % 9), ((i - 1) / 9) + 2 + ((i - 1) / 9));
                Tb[i].MaxLength = 1;
                Tb[i].WidthRequest = 50;
                Tb[i].HeightRequest = 50;
                Tb[i].HorizontalTextAlignment = TextAlignment.Center;
                Tb[i].FontSize = 20;
                Tb[i].StyleId = i.ToString();
                Tb[i].TextChanged += new EventHandler<TextChangedEventArgs>(Error_check);
            }
        } 
        private void Erase_Clicked(object? sender, EventArgs e)
        {
            for(int i = 1;i<=81;i++)
                Tb[i].Text = "";
        }
        private void Error_check(object? sender, EventArgs e)
        {
            (sender as Entry).Background = (sender as Entry).Text is not "1" and not "2" and not "3" and not "4" and not "5" and not "6" and not "7" and not "8" and not "9" and not ""
                ? errorBrush
                : new SolidColorBrush(new Color(0,0,0,0));
            if ((sender as Entry).Text.Length > 0)
                if (Int32.Parse((sender as Entry).StyleId) + 1 == 82)
                    Tb[1].Focus();
                else Tb[Int32.Parse((sender as Entry).StyleId) + 1].Focus();
            else
                if (Int32.Parse((sender as Entry).StyleId) - 1 == 0)
                    Tb[81].Focus();
                else Tb[Int32.Parse((sender as Entry).StyleId) - 1].Focus();
        }
        private async void Solve_Clicked(object sender, EventArgs e)
        {
            int[] str = new int[82];
            List<int> errcels = [];

            for (int i = 1; i <= 81; i++) {
                if (Tb[i].Background == errorBrush)
                {
                    errcels.Add(i);
                    Error_Data = true;
                }
                else if (Tb[i].Text != "" && Tb[i].Text != null) { str[i] = int.Parse(Tb[i].Text); }
                else { str[i] = 0; }
            }
            if (Error_Data)
            {
                await DisplayAlert(locoliz.error, locoliz.cellerr + " " + String.Join(", ", errcels), locoliz.ok);
            }
            else
            {
                str = ExternalFunction.Solve(str);
            }
            for(int i = 1; i <= 81; i++)
                if (str[i] != 0)
                    Tb[i].Text = str[i].ToString();
        }
    }
}