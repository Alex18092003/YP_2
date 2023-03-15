using System;
using System.Collections.Generic;
using System.IO;
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
        List<Subscribers> subscribers = new List<Subscribers>();

        public PageMainMenu()
        {
            InitializeComponent();

            ComboEmployes.ItemsSource = ClassBase.entities.Employees.ToList();
            ComboEmployes.SelectedValuePath = "kod_employee";
            ComboEmployes.DisplayMemberPath = "FIO";
            ComboEmployes.SelectedIndex = 0;

            GridSubscription.ItemsSource = ClassBase.entities.Subscribers.ToList();
            CheckBoxActiv.IsChecked = true;
           List<Districts> districts = ClassBase.entities.Districts.ToList();
            ComboBoxRaion.Items.Add("Все районы");
            foreach (Districts district in districts)
            {
                ComboBoxRaion.Items.Add(district.district);
            }
            ComboBoxRaion.SelectedIndex = 0;
        }

        private void ComboEmployes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Employees employees = ClassBase.entities.Employees.FirstOrDefault(x => x.kod_employee == ComboEmployes.SelectedIndex + 1);
            //ImageEmployee.ImageSource = new BitmapImage(new Uri(employees.photo, UriKind.Relative));
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

        public void Filter()
        {
            List<Subscribers> subscribers = new List<Subscribers>();
            //ListFilter = new List<Subscribers>();
            subscribers = ClassBase.entities.Subscribers.ToList();

            if ((bool)CheckBoxActiv.IsChecked && (bool)CheckBoxNoActiv.IsChecked)
            {
                subscribers = ClassBase.entities.Subscribers.ToList();
            }
            //поиск
            if (!string.IsNullOrWhiteSpace(TextBoxSurname.Text))
            {
                subscribers = subscribers.Where(x => x.surname.ToLower().Contains(TextBoxSurname.Text.ToLower())).ToList();
            }

            if(ComboBoxRaion.SelectedIndex >0)
            {
                Districts districts = ClassBase.entities.Districts.FirstOrDefault(x => x.district == ComboBoxRaion.SelectedValue);
                subscribers = subscribers.Where(x => x.kod_district == districts.kod_district).ToList();
            }

            if(!string.IsNullOrWhiteSpace(TextBoxLichSchet.Text))
            {
                subscribers = subscribers.Where(x => Convert.ToString(x.personal_account).ToLower().Contains(TextBoxLichSchet.Text.ToLower())).ToList();
                //subscribers = subscribers.Where(x=> x.personal_account == Convert.ToInt32(TextBoxLichSchet.Text)).ToList();
                //subscribers = subscribers.Where(x => x.personal_account.ToLower().Contains(TextBoxLichSchet.Text.ToLower())).ToList();
            }

            GridSubscription.ItemsSource = subscribers;
            if(subscribers.Count == 0)
            {
                MessageBox.Show("Данные отсутсвуют", "Сообщение");
            }
        }


        private void TextBoxSurname_TextChanged(object sender, TextChangedEventArgs e)
        {
            Filter();
        }

        private void ComboBoxRaion_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Filter();
        }

        private void TextBoxLichSchet_SelectionChanged(object sender, RoutedEventArgs e)
        {
            Filter();
        }

        private void GridSubscription_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Subscribers subscribers = new Subscribers();
            foreach(Subscribers subscribers1 in GridSubscription.SelectedItems)
            {
                subscribers = subscribers1;
            }

            if(subscribers != null)
            {
                ClassFrame.frame.Navigate(new PageSubscribers(subscribers));
            }
            else
            {
                return;
            }
        }
    }
}
