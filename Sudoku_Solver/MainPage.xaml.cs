//using Microsoft.UI.Xaml.Controls;
//using Microsoft.UI.Xaml.Input;

namespace Sudoku_Solver
{
    public partial class MainPage : ContentPage
    {
        private Entry[] tb = new Entry[82];

        public int[] end = new int[82];
        public int[] str = new int[82];

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
                Tb[i].TextChanged += new EventHandler<Microsoft.Maui.Controls.TextChangedEventArgs>(Error_check);
                /*Grid.SetColumn(Tb[i], ((i - 1) % 9) + 2 + ((i - 1) % 9));
                Grid.SetRow(Tb[i], ((i - 1) / 9) + 2 + ((i - 1) / 9));
                Tb[i].FontSize = 50;
                Tb[i].Name = "tb" + i.ToString();
                RegisterName("tb" + i.ToString(), Tb[i]);
                Tb[i].Background = new SolidColorBrush(Color.FromArgb(255, 229, 229, 229));
                Tb[i].MaxLength = 1;
                Tb[i].MaxLines = 1;
                Tb[i].TextAlignment = TextAlignment.Center;
                Tb[i].Padding = new Thickness(0, -13, 0, 0);
                Tb[i].PreviewTextInput += new TextCompositionEventHandler(Selectchanj);
                Tb[i].TextChanged += new TextChangedEventHandler(Err);
                Tb[i].PreviewKeyDown += new KeyEventHandler(TestBTN);*/
            }
        }

        private void Erase_Clicked(object? sender, EventArgs e)
        {
            for(int i = 1;i<=81;i++)
                Tb[i].Text = "";
        }

        private void Error_check(object? sender, EventArgs e) { }
        private void Solve_Clicked(object sender, EventArgs e)
        {

        }
    }
}
