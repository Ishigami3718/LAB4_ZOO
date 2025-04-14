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
        List<RoomDTO> rooms;
        public Window1()
        {
            InitializeComponent();
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
            int count;
            try
            {
                rooms=Room.Deser(rooms);
                count = rooms.Count+1;
            }
            catch
            {
                count = 1;
                rooms = new List<RoomDTO>();
            }
            RoomDTO room = new RoomDTO
            {
                Type = (RoomType.Type)RoomTypeComboBox.SelectedItem,
                Number = count,
                Size = int.Parse(Size.Text),
                CleanPrice = int.Parse(Price.Text),
                AnimalsInfo = new List<AccountUnit>()
            };
            rooms.Add(room);
            this.Close();
        }

        /*public void Close(object sender, CancelEventArgs e)
        {
           MessageBox mb = new MessageBox("")
        }*/
        private void Close(object sender, EventArgs e)
        {
            Room.Ser(rooms);
        }
    }
}
