using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
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
using System.Xml.Serialization;

namespace LAB4_OOP
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        //List<RoomDTO> rooms;
        RoomDTO room;
        int count;
        bool isRedact=false;

        public Window1()
        {
            InitializeComponent();
            count = MainWindow.Count;
        }

        public Window1(string size, string price, RoomType.Type type, int num)
        {
            InitializeComponent();
            Size.Text = size;
            Price.Text = price;
            RoomTypeComboBox.SelectedItem = type;
            isRedact = true;
            count=num;
        }

        public void Validate(object sender, RoutedEventArgs e)
        {
            Regex digit = new Regex("^\\d+$");
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
            if (isRedact)
            {
                count++;
                room = new RoomDTO
                {
                    Type = (RoomType.Type)RoomTypeComboBox.SelectedItem,
                    Number = count,
                    Size = int.Parse(Size.Text),
                    CleanPrice = int.Parse(Price.Text),
                };
            }
            else
            {
                count++;
                room = new RoomDTO
                {
                    Type = (RoomType.Type)RoomTypeComboBox.SelectedItem,
                    Number = count,
                    Size = int.Parse(Size.Text),
                    CleanPrice = int.Parse(Price.Text),
                    AnimalsInfo = new List<AccountUnit>()
                };
            }
            this.Close();
        }

        /*public void Close(object sender, CancelEventArgs e)
        {
           MessageBox mb = new MessageBox("")
        }*/
        private void Close(object sender, CancelEventArgs e)
        {
            // Room.Ser(rooms);
            if (Size.Text == null || Price.Text == null || RoomTypeComboBox.SelectedItem == null || room==null)
            {
                MessageBoxResult mb = MessageBox.Show("Ви не задали дані, бажаєте закрити?", "Підтвердження", MessageBoxButton.YesNo);
                if (mb == MessageBoxResult.Yes) { }
                if (mb == MessageBoxResult.No) { e.Cancel = true; }
            }
            else if (isRedact)
            {
                count--;
                MainWindow.RedactRoom(room,count);
            }
            else
            {
                MainWindow.AddRoom(room);
            }
        }

    }
}
