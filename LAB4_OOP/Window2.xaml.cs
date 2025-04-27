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
        List<AccountUnitDTO> animalsDTO = new List<AccountUnitDTO>();
        List<AccountUnit> animals = new List<AccountUnit>();
        public Window2(List<AccountUnitDTO> animals)
        {
            InitializeComponent();
            this.animalsDTO = animals;
            for(int i = 0; i < animalsDTO.Count; i++)
            {
                this.animals[i] = new AccountUnit(animalsDTO[i]);
                AccountList.Items.Add(animals[i]);
            }
        }

        private void AddAnimal(object sender, RoutedEventArgs e)
        {

        }

    }
}
