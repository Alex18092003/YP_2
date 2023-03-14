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

namespace YP_2
{
    /// <summary>
    /// Логика взаимодействия для PageMainMenu.xaml
    /// </summary>
    public partial class PageMainMenu : Page
    {
        public PageMainMenu()
        {
            InitializeComponent();

            ComboEmployes.ItemsSource = ClassBase.entities.Employees.ToList();
            ComboEmployes.SelectedValuePath = "kod_employee";
            ComboEmployes.DisplayMemberPath = "FIO";
            ComboEmployes.SelectedIndex = 0;

            GridSubscription.ItemsSource = ClassBase.entities.Subscribers.ToList();
            CheckBoxActiv.IsChecked = true;
            List
        }

        private void ComboEmployes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Employees employees = ClassBase.entities.Employees.FirstOrDefault(x => x.kod_employee == ComboEmployes.SelectedIndex + 1);
            //ImageEmployee.ImageSource = new BitmapImage(new Uri( employees.photo, UriKind.Relative));
            if (employees != null)
            {
                
                List<InformationForEmployees> informationForEmployees = ClassBase.entities.InformationForEmployees.Where(x => x.kod_employees == employees.id_role).ToList();
                ListEvents.ItemsSource = informationForEmployees.OrderBy(x => x.event_data);
            
            }
            if(employees.id_role == 1)
            {
                ImgObor.Visibility = Visibility.Collapsed;
                ImgActiv.Visibility = Visibility.Collapsed;
                ImgPodder.Visibility = Visibility.Collapsed;
            }
            else if (employees.id_role == 2)
            {
                ImgBilling.Visibility = Visibility.Collapsed;
                ImgObor.Visibility = Visibility.Collapsed;
                ImgActiv.Visibility = Visibility.Collapsed;
                ImgPodder.Visibility = Visibility.Collapsed;
            }
            else if (employees.id_role == 3)
            {
                ImgActiv.Visibility = Visibility.Collapsed;
                ImgBilling.Visibility = Visibility.Collapsed;
            }
            else if (employees.id_role == 4)
            {
                ImgActiv.Visibility = Visibility.Collapsed;
                ImgBilling.Visibility = Visibility.Collapsed;
            }
            else if (employees.id_role == 5)
            {
                ImgObor.Visibility = Visibility.Collapsed;
                ImgPodder.Visibility = Visibility.Collapsed;
                ImgCRM.Visibility = Visibility.Collapsed;
            }
            else if (employees.id_role == 6)
            {
                
            }
            else if (employees.id_role == 7)
            {

            }
            else if (employees.id_role == 10)
            {
                ImgBilling.Visibility = Visibility.Collapsed;
                ImgPodder.Visibility = Visibility.Collapsed;
            }
        }

        private void ButtonBackward_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void ButtonForward_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
