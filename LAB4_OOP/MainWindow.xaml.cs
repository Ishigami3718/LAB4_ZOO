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
        static List<AccountUnitDTO> accountUnit;
        //public static RoomDTO newRoom;
        public MainWindow()
        {
            InitializeComponent();
            rooms=Serializer.Deser(rooms);
            if (rooms == null)  rooms = new List<RoomDTO>();
            foreach (RoomDTO room in rooms) Rooms.Items.Add(new Room(room));
            RoomTypes.ItemsSource = Enum.GetValues(typeof(RoomType.Type));
        }

        private List<RoomDTO> GetRoomsOfType(RoomType.Type type)
        {
            return rooms.Where(i=>i.Type==type).ToList();
        }

        private void GetRoom(object sender, RoutedEventArgs e)
        {
            Rooms.Items.Clear();
            foreach(RoomDTO room in GetRoomsOfType((RoomType.Type)RoomTypes.SelectedItem)) Rooms.Items.Add(new Room(room));
            AllRooms.IsEnabled = true;
        }

        private void GetAllRooms(object sender, RoutedEventArgs e)
        {
            Rooms.Items.Clear();
            foreach (RoomDTO room in rooms) Rooms.Items.Add(new Room(room));
            AllRooms.IsEnabled = false;
        }

        public static void AddRoom(RoomDTO room) => rooms.Add(room);

        public static void RedactRoom(RoomDTO room, int num) => rooms[num] = room;
        public static int Count { get { return rooms.Count; } }
        private void AddRoom(object sender, RoutedEventArgs e)
        {

            Window1 room = new Window1();
            room.RoomTypeComboBox.ItemsSource = Enum.GetValues(typeof(RoomType.Type));
            room.ShowDialog();
        }
        private void Close(object sender, EventArgs e)
        {
            Serializer.Ser(rooms);
            this.Close();

        }

        private void RedactRoom(object sender, SelectionChangedEventArgs e) 
        {
            Redact.IsEnabled = true;
            Account.IsEnabled = true;
        }

        private void GetRoomOfType(object sender, SelectionChangedEventArgs e) => GetRooms.IsEnabled = true;

        private void RedactRoom_Click(object sender, RoutedEventArgs e)
        {
            int indx = ((Room)Rooms.SelectedItem).ToDTO().Number - 1;
            Window1 red = new Window1(rooms[indx].Size.ToString(), rooms[indx].CleanPrice.ToString(), rooms[indx].Type, indx);
            red.RoomTypeComboBox.ItemsSource = Enum.GetValues(typeof(RoomType.Type));
            red.Title = "Редагування";
            red.ShowDialog();
        }

        private void OpenAccounts(object sender, RoutedEventArgs e)
        {
            Window2 animals = new Window2(((Room)Rooms.SelectedItem).ToDTO().AnimalsInfo);
            int indx = ((Room)Rooms.SelectedItem).ToDTO().Number - 1;
            animals.ShowDialog();
            rooms[indx].AnimalsInfo = accountUnit;
        }

        static public void AddUnits(List<AccountUnitDTO> accountUnitDTO)
        {
            accountUnit = accountUnitDTO;
        }

        private void Sort_SelectionChanged(object sender, SelectionChangedEventArgs e)=>SortB.IsEnabled = true;

        private void SortList(object sender, RoutedEventArgs e)
        {
            Rooms.Items.Clear();
            switch (Sort.SelectedValue.ToString())
            {
                case "System.Windows.Controls.ComboBoxItem: Ціна":
                    foreach(var i in rooms.OrderBy(i=>i.CleanPrice)) Rooms.Items.Add(new Room(i));
                    break;
                case "System.Windows.Controls.ComboBoxItem: Розмір": 
                    foreach (var i in rooms.OrderBy(i => i.Size)) Rooms.Items.Add(new Room(i)); ; 
                    break;
                case "System.Windows.Controls.ComboBoxItem: Номер":
                    foreach (var i in rooms.OrderBy(i => i.Number)) Rooms.Items.Add(new Room(i)); ;
                    break;
            }
        }
    }
}
