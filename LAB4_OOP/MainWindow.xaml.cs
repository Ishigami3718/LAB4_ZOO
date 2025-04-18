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
        static List<RoomDTO> rooms;
        //public static RoomDTO newRoom;
        public MainWindow()
        {
            InitializeComponent();
            rooms=Room.Deser(rooms);
            if (rooms == null)  rooms = new List<RoomDTO>();
            foreach (RoomDTO room in rooms) Rooms.Items.Add(new Room(room));
        }

        public static void AddRoom(RoomDTO room) => rooms.Add(room);

        public static void RedactRoom(RoomDTO room, int num)
        {
            rooms[num]=room;
        }
        public static int Count { get { return rooms.Count; } }
        private void AddRoom(object sender, RoutedEventArgs e)
        {

            Window1 room = new Window1();
            room.RoomTypeComboBox.ItemsSource = Enum.GetValues(typeof(RoomType.Type));
            room.ShowDialog();
        }
        private void Close(object sender, EventArgs e)
        {
            Room.Ser(rooms);
            this.Close();

        }

        private void RedactRoom(object sender, SelectionChangedEventArgs e)
        {
            Redact.IsEnabled= true;
        }

        private void RedactRoom_Click(object sender, RoutedEventArgs e)
        {
            int indx = Rooms.SelectedIndex;
            Window1 red = new Window1(rooms[indx].Size.ToString(), rooms[indx].CleanPrice.ToString(), rooms[indx].Type, indx);
            red.RoomTypeComboBox.ItemsSource = Enum.GetValues(typeof(RoomType.Type));
            red.Title = "Редагування";
            red.ShowDialog();
                //TODO Дописати метод для редагування через отримання інфи з лістбоксу
        }
    }
}
