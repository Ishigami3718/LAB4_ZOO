using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace LAB4_OOP
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        List<Room> rooms;
        public Window1()
        {
            InitializeComponent();
        }

        public void Validate(object sender, RoutedEventArgs e)
        {
            Regex digit = new Regex("\\d+");
            TextBox text = (TextBox)sender;
            if (!digit.IsMatch(text.Text))
            {
                text.Focus();
                e.Handled = true;
                MessageBox.Show("Неправильні дані");
            }
        }

        public void AddRoom(object sender, RoutedEventArgs e)
        {
            RoomDTO room = new RoomDTO
            {
                Type = (RoomType)RoomTypeComboBox.SelectedItem,
                Number = 0,
                Size = int.Parse(Size.Text),
                CleanPrice = int.Parse(Price.Text),
                AnimalsInfo = new List<AccountUnit>()
            };
            rooms.Add(new Room(room));
        }

    }
}
