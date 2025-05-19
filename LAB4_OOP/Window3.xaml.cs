using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
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
    /// Interaction logic for Window3.xaml
    /// </summary>
    public partial class Window3 : Window
    {
        AccountUnitDTO unit;
        bool isRedact=false;
        int indxForRedact;
        public Window3()
        {
            InitializeComponent();
        }
        public Window3(AccountUnitDTO dto,int indx)
        {
            InitializeComponent();
            Name.Text = dto.Animal.Name;
            FirstName.Text = dto.Animal.FirstName;
            Country.Text = dto.Animal.Country;
            Birth.SelectedDate = dto.Animal.BirthDate;
            RecDate.SelectedDate = dto.RecDate;
            Price.Text = dto.Price.ToString();
            isRedact = true;
            indxForRedact= indx;
        }

        public void AddAnimal(object sender, RoutedEventArgs e)
        {
             
                try
                {
                    unit = new AccountUnitDTO()
                    {
                        Animal = new AnimalDTO()
                        {
                            Name = Name.Text,
                            FirstName = FirstName.Text,
                            Country = Country.Text,
                            BirthDate = Birth.SelectedDate.Value
                        },
                        RecDate = RecDate.SelectedDate.Value,
                        Price = int.Parse(Price.Text)
                    };
                    if (Validator.TryValidateObject(unit, new ValidationContext(unit), new List<System.ComponentModel.DataAnnotations.ValidationResult>(), true))
                        this.Close();
                    else MessageBox.Show("Неправильні дані");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Неправильні дані");
                }
        }

        private void Close(object sender, CancelEventArgs e)
        {
            if (Name.Text == null || FirstName.Text == null || Country.Text == null || unit == null || 
                Birth.SelectedDate == null || RecDate.SelectedDate == null || Price.Text == null ||
                !Validator.TryValidateObject(unit, new ValidationContext(unit), new List<System.ComponentModel.DataAnnotations.ValidationResult>(), true)
                || Birth.SelectedDate>DateTime.Now || RecDate.SelectedDate> DateTime.Now)
            {
                MessageBoxResult mb = MessageBox.Show("Ви не задали дані, або введені дані не коректні, бажаєте закрити?", "Підтвердження", MessageBoxButton.YesNo);
                if (mb == MessageBoxResult.Yes) { }
                if (mb == MessageBoxResult.No) e.Cancel = true;
            }
            else if (isRedact)
            {
                Window2.RedactAcc(unit, indxForRedact);
            }
            else
            {
                Window2.AddUnit(unit);
            }
        }
    }
}
