namespace Sudoku_Solver
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

        }
#if ANDROID
        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new AppShellAndroid());
        }
#endif
#if WINDOWS
        protected override Window CreateWindow(IActivationState? activationState)
        {
            const int newwidth = 700;
            const int newheight = 800;

            var wins = new Window(new AppShell());
            wins.Height = wins.MinimumHeight = wins.MaximumHeight = newheight;
            wins.Width = wins.MinimumWidth = wins.MaximumWidth = newwidth;
            return wins;
        }
#endif
    }
}