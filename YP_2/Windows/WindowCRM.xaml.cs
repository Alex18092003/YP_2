using System;
using System.Collections.Generic;
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

namespace YP_2.Windows
{
    /// <summary>
    /// Логика взаимодействия для WindowCRM.xaml
    /// </summary>
    public partial class WindowCRM : Window
    {
        public WindowCRM()
        {
            InitializeComponent();

      
       
        }

        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        //Subscribers s;
        private void Identific()
        {
            //List<Subscribers> subscribers = new List<Subscribers>();
            if(Name.Text.Length != 0 && Password.Text.Length != 0)
            {
                Subscribers subscribers1 = ClassBase.entities.Subscribers.FirstOrDefault(x => x.surname == Name.Text && x.phone == Password.Text);
                if(subscribers1 != null)
                {
                    FIO.Text = subscribers1.FIO;
                    ST.Visibility = Visibility.Visible;
                    DateTime dateTime = DateTime.Now;
                    TextNumber.Text = Convert.ToString( subscribers1.personal_account) + "/" + dateTime.ToString("dd")+ "/" + dateTime.ToString("MM") + "/" + dateTime.ToString("yyyy");
                    DateTime thisDay = DateTime.Now;
                    TextData.Text = thisDay.ToString();
                    TextPhone.Text = subscribers1.subscriber_number;
                    TextLC.Text = Convert.ToString(subscribers1.personal_account);
                    List<Services> services = ClassBase.entities.Services.ToList();
                    foreach (Services services1 in services)
                    {
                        ComboServices.Items.Add(services1.name);
                    }
                    List<ServicesView> servicesViews = ClassBase.entities.ServicesView.ToList();
                    foreach(ServicesView services1v in servicesViews)
                    {
                        ComboVidServ.Items.Add(services1v.name);
                    }
                    List<ServicesTypes> servicesTypes = ClassBase.entities.ServicesTypes.ToList();
                    foreach (ServicesTypes servicesTypes1 in servicesTypes)
                    {
                        ComboTipServ.Items.Add(servicesTypes1.name);
                    }
                    Statuses statuses = ClassBase.entities.Statuses.FirstOrDefault(x => x.kod_status == 1);
                    ComboStatus.Text = Convert.ToString(statuses.name);
                    //List<Statuses> statuses = ClassBase.entities.Statuses.ToList();
                    //foreach (Statuses s in statuses)
                    //{
                    //    ComboStatus.Items.Add(s.name);
                    //}
                    //ComboStatus.SelectedIndex = 0;
                    List<EquiomentType> equiomentTypes = ClassBase.entities.EquiomentType.ToList();
                    foreach (EquiomentType equiomentType in equiomentTypes)
                    {
                        ComboTipObor.Items.Add(equiomentType.name);
                    }
                    List<ProblemTypes> problemTypes = ClassBase.entities.ProblemTypes.ToList();
                    foreach (ProblemTypes problem in problemTypes)
                    {
                        ComboTipProblem.Items.Add(problem.name);
                    }
                    
                }
                else
                {
                    FIO.Text = "Нет такого абонента";
                }
               
                   
            }
        }

        private void Password_TextChanged(object sender, TextChangedEventArgs e)
        {
            Identific();
        }

        //Ввод первой заглавной 
        private void Name_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                Identific();
                if (Name.Text.Length == 1)
                {
                    Name.Text = Name.Text.ToUpper();
                    Name.Select(Name.Text.Length, 0);
                }
            }
            catch
            {
                MessageBox.Show("Что-то пошло не так", "Ошибка");
            }
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {

        }
        //запрет ввода чисел
        private void Name_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            try
            {
                Regex r = new Regex("^[0-9]+");
                e.Handled = r.IsMatch(e.Text);
            }
            catch
            {
                MessageBox.Show("Что-то пошло не так", "Ошибка");
            }
        }

        private void ButtonTest_Click(object sender, RoutedEventArgs e)
        {
            Random rnd = new Random();
            int ii = rnd.Next(2);
            if(ii == 1)
            {
                Statuses statuses = ClassBase.entities.Statuses.FirstOrDefault(x => x.kod_status == 3);
                ComboStatus.Text = Convert.ToString(statuses.name);
                DateTime thisDay = DateTime.Now;
                TextDataClose.Text = thisDay.ToString();
            }
            else
            {

                Statuses statuses = ClassBase.entities.Statuses.FirstOrDefault(x => x.kod_status == 2);
                ComboStatus.Text = Convert.ToString(statuses.name);
            }
        }
    }
}
