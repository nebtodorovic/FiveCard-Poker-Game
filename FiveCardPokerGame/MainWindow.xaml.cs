using FiveCardPokerGame.Data;
using FiveCardPokerGame.ViewModels;
using FiveCardPokerGame.Views;
using System.Windows;

namespace FiveCardPokerGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Sets the datacontect to MainViewModel
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
        }
        
    }
}
