using System.Windows;

namespace RelayDriver
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly RelayViewModel _relayViewModel;

        public MainWindow()
        {
            InitializeComponent();
            _relayViewModel = new RelayViewModel();
            DataContext = _relayViewModel;
        }
    }
}
