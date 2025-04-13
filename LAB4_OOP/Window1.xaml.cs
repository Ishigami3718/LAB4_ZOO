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
            int count;
            try
            {
                XmlSerializer ser = new XmlSerializer(typeof(List<Room>));
                using(TextReader tr = new StreamReader(@"D:\Visual Studio\LAB3_OOP\LAB3_OOP\Rooms.txt"))
                {
                    rooms = (List<Room>)ser.Deserialize(tr);
                }
                count = rooms.Count+1;
            }
            catch
            {
                count = 1;
                rooms = new List<Room>();
            }
            RoomDTO room = new RoomDTO
            {
                Type = RoomTypeComboBox.SelectedItem as RoomType,
                Number = count,
                Size = int.Parse(Size.Text),
                CleanPrice = int.Parse(Price.Text),
                AnimalsInfo = new List<AccountUnit>()
            };
            rooms.Add(new Room(room));
            this.Close();
        }

        /*public void Close(object sender, CancelEventArgs e)
        {
           MessageBox mb = new MessageBox("")
        }*/
        private void Close(object sender, EventArgs e)
        {
            try
            {
                XmlSerializer ser = new XmlSerializer(typeof(List<Room>));
                using (TextWriter sr = new StreamWriter(@"D:\Visual Studio\LAB3_OOP\LAB3_OOP\Rooms.txt"))
                {
                    ser.Serialize(sr,rooms);
                }
            }
            catch
            {
            }
        }
    }
}
