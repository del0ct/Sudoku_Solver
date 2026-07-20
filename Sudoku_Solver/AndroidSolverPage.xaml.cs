using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;

namespace Sudoku_Solver
{
    public partial class AndroidSolverPage : ContentPage
    {
        private Button[] tb = new Button[82];

        ExternalFunction ef = new ExternalFunction();
        public string ChecktNum;

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

        private void Erase_Clicked(object? sender, EventArgs e)
        {
            for (int i = 1; i <= 81; i++)
                Tb[i].Text = "";
            //await Toast.Make("TEST ERROR", ToastDuration.Short).Show();
        }
        private void OnCellClicked(object? sender, EventArgs e) 
        {
            (sender as Button).Text = ChecktNum is "Eraser" ? "" : ChecktNum;
        }
        private void Solve_Clicked(object sender, EventArgs e)
        {
            int[] str = new int[82];

            for (int i = 1; i <= 81; i++)
            {
                if (Tb[i].Text != "" && Tb[i].Text != null) { str[i] = int.Parse(Tb[i].Text); }
                else { str[i] = 0; }
            }
            str = ef.Solve(str);
            for (int i = 1; i <= 81; i++)
                Tb[i].Text = str[i].ToString();
        }

        private void NumCheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            
            ChecktNum = (sender as RadioButton).Content.ToString();
        }
    }
}
