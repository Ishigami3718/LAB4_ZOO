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
        static List<AccountUnitDTO> animalsDTO = new List<AccountUnitDTO>();
        List<AccountUnit> animals = new List<AccountUnit>();
        List<Animal> animalsEntity = new List<Animal>();

        public Window2(List<AccountUnitDTO> animals)
        {
            InitializeComponent();
            animalsDTO = animals;
            for(int i = 0; i < animalsDTO.Count; i++)
            {
                this.animals.Add(new AccountUnit(animalsDTO[i]));
                AccountList.Items.Add(this.animals[i]);
            }
            animalsEntity = animalsDTO.Select(i => new Animal(i.Animal)).ToList();
        }

        private void AddAnimalsInRoom(object sender, RoutedEventArgs e)
        {
            Window3 addAnimal = new Window3();
            addAnimal.ShowDialog();
        }

        static public void AddUnit(AccountUnitDTO dto)
        {
            animalsDTO.Add(dto);
        }

        private void Ok(object sender, RoutedEventArgs e) => this.Close();
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MainWindow.AddUnits(animalsDTO);
        }

        private void AccountList_SelectionChanged(object sender, SelectionChangedEventArgs e)=>Age.IsEnabled = true;

        private void Age_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"{animalsEntity[AccountList.SelectedIndex].GetAge()}");
        }

        private void Status(object sender, RoutedEventArgs e)
        {
            string res;
            if (animalsEntity[AccountList.SelectedIndex].Status) res = "Нагодована";
            else res = "Голодна";
            MessageBox.Show(res);
        }

        private void Feed(object sender, RoutedEventArgs e)
        {
            animalsEntity[AccountList.SelectedIndex].Status = true;
    }
    }
}
