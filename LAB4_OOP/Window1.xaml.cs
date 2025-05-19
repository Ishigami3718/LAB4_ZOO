using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
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

        public Window1(RoomDTO dto)
        {
            InitializeComponent();
            Size.Text = dto.Size.ToString();
            Price.Text = dto.CleanPrice.ToString();
            RoomTypeComboBox.ItemsSource = Enum.GetValues(typeof(RoomType.Type));
             RoomTypeComboBox.SelectedItem = dto.Type;
            //RoomTypeComboBox.SelectedItem = Enum.Parse(typeof(RoomType.Type), dto.Type.ToString());
            // RoomTypeComboBox.I
            isRedact = true;
            count=dto.Number;
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
                    AnimalsInfo = new List<AccountUnitDTO>()
                };
            }
            if (Validator.TryValidateObject(room, new ValidationContext(room), new List<System.ComponentModel.DataAnnotations.ValidationResult>(),true))
                this.Close();
            else MessageBox.Show("Неправильні дані");

        }

        private void Close(object sender, CancelEventArgs e)
        {
            if (Size.Text == null || Price.Text == null || RoomTypeComboBox.SelectedItem == null || room==null ||
                !Validator.TryValidateObject(room, new ValidationContext(room), new List<System.ComponentModel.DataAnnotations.ValidationResult>(), true))
            {
                MessageBoxResult mb = MessageBox.Show("Ви не задали дані, або введені дані не коректні, бажаєте закрити?", "Підтвердження", MessageBoxButton.YesNo);
                if (mb == MessageBoxResult.Yes) { }
                if (mb == MessageBoxResult.No)  e.Cancel = true; 
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
