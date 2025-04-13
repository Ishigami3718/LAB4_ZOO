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
using System.Windows.Shapes;

namespace LAB4_OOP
{
    /// <summary>
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        List<Room> rooms=new List<Room>();
        List<RoomDTO> DTOrooms;
        public Window2()
        {
            InitializeComponent();
            ShowInList();
        }

        private void ShowInList()
        {
            DTOrooms = Room.Deser(DTOrooms);
            foreach (RoomDTO room in DTOrooms)
            {
                //if(room.Type==RoomType.Type.Cage)
                rooms.Add(new Room(room));
            }
            foreach (Room room in rooms)
            {
                CagesList.Items.Add(room);
            }
        }

    }
}
