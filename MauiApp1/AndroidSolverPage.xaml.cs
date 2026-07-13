//using Microsoft.UI.Xaml.Controls;
//using Microsoft.UI.Xaml.Input;

//using Android.Widget;

namespace MauiApp1
{
    public partial class AndroidSolverPage : ContentPage
    {
        private Button[] tb = new Button[82];

        public int[] end = new int[82];
        public int[] str = new int[82];
        public string ChecktNum;

        public Button[] Tb { get => tb; set => tb = value; }
        public AndroidSolverPage()
        {
           InitializeComponent();

            for (int i = 1; i <= 81; i++)
            {
                Tb[i] = new Button();
                Layoot.Add(Tb[i], ((i - 1) % 9) + 2 + ((i - 1) % 9), ((i - 1) / 9) + 3 + ((i - 1) / 9));
                Tb[i].Text = i.ToString();
                Tb[i].Padding = new Thickness(0, 0, 0, 0);
                Tb[i].FontSize = 20;
                Tb[i].Clicked += OnCellClicked; 
            }
        }

        private void Erase_Clicked(object? sender, EventArgs e)
        {
            for(int i = 1;i<=81;i++)
                Tb[i].Text = "";
        }
        private void OnCellClicked(object? sender, EventArgs e) 
        {
            (sender as Button).Text = ChecktNum;
        }
        private void Error_check(object? sender, EventArgs e) { }
        private void Solve_Clicked(object sender, EventArgs e)
        {

        }

        private void NumCheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            
            ChecktNum = (sender as RadioButton).Content.ToString();
        }
    }
}
