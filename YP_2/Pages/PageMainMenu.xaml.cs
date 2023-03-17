using System;
using System.Collections.Generic;
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

            List<Subscribers> subscribers = ClassBase.entities.Subscribers.ToList();
            ComboBoxYlitsa.Items.Add("Все улицы");
            foreach (Subscribers subscribers1 in subscribers)
            {
                ComboBoxYlitsa.Items.Add(subscribers1.addres_of_residence.Substring(19));
            }
            ComboBoxYlitsa.SelectedIndex = 0;
        }

        int ii = 0;
        private void ComboEmployes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Employees employees = ClassBase.entities.Employees.FirstOrDefault(x => x.kod_employee == ComboEmployes.SelectedIndex + 1);

            if (employees != null)
            {
                if (employees.photo != null)
                {

                    ImageEmployee.ImageSource = new BitmapImage(new Uri("" + employees.photo, UriKind.Relative));
                }
                else
                {
                    ImageEmployee.ImageSource = new BitmapImage(new Uri("..\\..\\resources\\Фото для заглушки при отсутствии фото сотрудника.jpg", UriKind.Relative));
                }
                List<InformationForEmployees> informationForEmployees = ClassBase.entities.InformationForEmployees.Where(x => x.kod_employees == employees.id_role).ToList();
                ListEvents.ItemsSource = informationForEmployees.OrderBy(x => x.event_data);
                ii = informationForEmployees.Count;
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

        /// <summary>
        /// Метод для поиска и фильтрации
        /// </summary>
        public void Filter()
        {
            List<Subscribers> subscribers = new List<Subscribers>();

            subscribers = ClassBase.entities.Subscribers.ToList();

            //активные неактивные
            if (CheckBoxActiv.IsChecked == true && CheckBoxNoActiv.IsChecked == true)
            {
                subscribers = ClassBase.entities.Subscribers.ToList();
            }
            else if(CheckBoxActiv.IsChecked == true && CheckBoxNoActiv.IsChecked == false)
            {
                subscribers = ClassBase.entities.Subscribers.Where(x => x.reason_for_termination == null).ToList();
            }
            else if (CheckBoxActiv.IsChecked == false && CheckBoxNoActiv.IsChecked == true)
            {
                subscribers = ClassBase.entities.Subscribers.Where(x => x.reason_for_termination != null).ToList();
            }
            else
            {
                subscribers = new List<Subscribers>();
            }

            //поиск
            if (!string.IsNullOrWhiteSpace(TextBoxSurname.Text))
            {
                subscribers = subscribers.Where(x => x.surname.ToLower().Contains(TextBoxSurname.Text.ToLower())).ToList();
            }

            //фильтрация по району
            if(ComboBoxRaion.SelectedIndex >0)
            {
                Districts districts = ClassBase.entities.Districts.FirstOrDefault(x => x.district == ComboBoxRaion.SelectedValue);
                subscribers = subscribers.Where(x => x.kod_district == districts.kod_district).ToList();
            }

            if(!string.IsNullOrWhiteSpace(TextBoxLichSchet.Text))
            {
                subscribers = subscribers.Where(x => Convert.ToString(x.personal_account).ToLower().Contains(TextBoxLichSchet.Text.ToLower())).ToList();
               
            }

            //фильтрация по улице 
            if (ComboBoxYlitsa.SelectedIndex > 0)
            {
               
                subscribers = subscribers.Where(x => x.addres_of_residence.Substring(19) == ComboBoxYlitsa.SelectedItem.ToString()).ToList();
               
            }

            GridSubscription.ItemsSource = subscribers;
            if(subscribers.Count == 0)
            {
                MessageBox.Show("Данные отсутсвуют", "Сообщение");
            }
        }

        // ввод первой заглавной буквы
        private void TextBoxSurname_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                Filter();
                if (TextBoxSurname.Text.Length == 1)
                {
                    TextBoxSurname.Text = TextBoxSurname.Text.ToUpper();
                    TextBoxSurname.Select(TextBoxSurname.Text.Length, 0);
                }
               
            }
            catch
            {
                MessageBox.Show("Что-то пошло не так", "Ошибка");
            }
            
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

        private void ButtonBac_Click(object sender, RoutedEventArgs e)
        {
 
        }

        private void ImgAbon_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ImgAbon.IsEnabled = false;
            ImgObor.IsEnabled = true;
            ImgActiv.IsEnabled = true;
            ImgBilling.IsEnabled = true;
            ImgPodder.IsEnabled = true;
            ImgCRM.IsEnabled = true;
            TextName.Text = "Абоненты ТНС";
        }

        private void ImgObor_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ImgAbon.IsEnabled = true;
            ImgObor.IsEnabled = false;
            ImgActiv.IsEnabled = true;
            ImgBilling.IsEnabled = true;
            ImgPodder.IsEnabled = true;
            ImgCRM.IsEnabled = true;
            TextName.Text = "Управление оборудованием";
        }

        private void ImgActiv_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ImgAbon.IsEnabled = true;
            ImgObor.IsEnabled = true;
            ImgActiv.IsEnabled = false;
            ImgBilling.IsEnabled = true;
            ImgPodder.IsEnabled = true;
            ImgCRM.IsEnabled = true;
            TextName.Text = "Активы";
        }

        private void ImgBilling_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ImgAbon.IsEnabled = true;
            ImgObor.IsEnabled = true;
            ImgActiv.IsEnabled = true;
            ImgBilling.IsEnabled = false;
            ImgPodder.IsEnabled = true;
            ImgCRM.IsEnabled = true;
            TextName.Text = "Биллинг";
        }

        private void ImgPodder_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ImgAbon.IsEnabled = true;
            ImgObor.IsEnabled = true;
            ImgActiv.IsEnabled = true;
            ImgBilling.IsEnabled = true;
            ImgPodder.IsEnabled = false;
            ImgCRM.IsEnabled = true;
            TextName.Text = "Поддержка пользователей";
        }

        private void ImgCRM_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ImgAbon.IsEnabled = true;
            ImgObor.IsEnabled = true;
            ImgActiv.IsEnabled = true;
            ImgBilling.IsEnabled = true;
            ImgPodder.IsEnabled = true;
            ImgCRM.IsEnabled = false;
            TextName.Text = "CRM";
            Windows.WindowCRM v = new Windows.WindowCRM();
            v.ShowDialog();
            ClassFrame.frame.Navigate(new PageMainMenu());
        }

        // запрет ввода чисел
        private void TextBoxSurname_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {

            try
            {
                Regex r1 = new Regex("^[0-9]+");
                e.Handled = r1.IsMatch(e.Text);
            }
            catch
            {
                MessageBox.Show("Что-то пошло не так", "Ошибка");
            }
        }

        //запрет ввода символов
        private void TextBoxLichSchet_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            try
            {
                if (!Char.IsDigit(e.Text, 0)) e.Handled = true;
            }
            catch
            {
                MessageBox.Show("Что-то пошло не так", "Ошибка");
            }
        }

        private void ComboBoxYlitsa_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Filter(); 
        }

        private void CheckBoxActiv_Checked(object sender, RoutedEventArgs e)
        {
            Filter();
        }

        private void CheckBoxNoActiv_Checked(object sender, RoutedEventArgs e)
        {
            Filter();
        }
    }
}
