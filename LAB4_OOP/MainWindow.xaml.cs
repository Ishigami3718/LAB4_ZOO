using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LAB4_OOP
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void AddRoom(object sender, RoutedEventArgs e)
        {

            Window1 room = new Window1();
            room.RoomTypeComboBox.ItemsSource = Enum.GetValues(typeof(RoomType.Type));
            room.ShowDialog();
        }

        private void Cages(object sender, RoutedEventArgs e)
        {

            Window2 cage = new Window2();
            cage.ShowDialog();
        }
    }
}
