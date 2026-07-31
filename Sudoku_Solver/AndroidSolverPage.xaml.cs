#if ANDROID
using AndroidX.Core.Widget;
using Java.Lang;
#endif
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using System.Collections;

namespace Sudoku_Solver
{
    public partial class AndroidSolverPage : ContentPage
    {
        private Button[] tb = new Button[82];
        public int ChecktNum = 1;

        public Button[] Tb { get => tb; set => tb = value; }
        public AndroidSolverPage()
        {
            InitializeComponent();

            for (int i = 1; i <= 81; i++)
            {
                Tb[i] = new Button();
                Layoot.Add(Tb[i], ((i - 1) % 9) + 2 + ((i - 1) % 9), ((i - 1) / 9) + 3 + ((i - 1) / 9));
                Tb[i].Padding = new Thickness(0, 0, 0, 0);
                Tb[i].FontSize = 20;
                Tb[i].Clicked += OnCellClicked;
            }
        }
        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);
            int w = (int)double.Round(AppShell.Current.Window.Width) / 10;
            LabelSudoku.FontSize = w;
        }
        private void Erase_Clicked(object? sender, EventArgs e)
        {
            for (int i = 1; i <= 81; i++)
                Tb[i].Text = "";
            //await Toast.Make("TEST ERROR", ToastDuration.Short).Show();
        }
        private void OnCellClicked(object? sender, EventArgs e) 
        {
            (sender as Button).Text = ChecktNum is 0 ? "" : ChecktNum.ToString();
        }
        private void Solve_Clicked(object sender, EventArgs e)
        {
            int[] str = new int[82];

            for (int i = 1; i <= 81; i++)
            {
                if (Tb[i].Text != "" && Tb[i].Text != null) 
                    str[i] = int.Parse(Tb[i].Text);
                else str[i] = 0;
            }
            str = ExternalFunction.Solve(str);
            for (int i = 1; i <= 81; i++)
                if (str[i] != 0)
                    Tb[i].Text = str[i].ToString();
        }

        private void NumCheckedChanged(object sender, EventArgs e)
        {   
            num1.Background = Colors.Gray;
            num2.Background = Colors.Gray;
            num3.Background = Colors.Gray;
            num4.Background = Colors.Gray;
            num5.Background = Colors.Gray;
            num6.Background = Colors.Gray;
            num7.Background = Colors.Gray;
            num8.Background = Colors.Gray;
            num9.Background = Colors.Gray;
            num0.Background = Colors.Gray;
            if (!int.TryParse((sender as Button).Text, out ChecktNum)) ChecktNum = 0;
            (sender as Button).Background = Colors.BlueViolet;
        }
    }
}
