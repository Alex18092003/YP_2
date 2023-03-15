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
    /// Логика взаимодействия для PageSubscribers.xaml
    /// </summary>
    public partial class PageSubscribers : Page
    {
        Subscribers s;
        public PageSubscribers(Subscribers subscribers)
        {
            InitializeComponent();

            this.s = subscribers;
            TextNomer.Text = "Номер абонента" + subscribers.subscriber_number;
            FIO.Text = subscribers.FIO;
            TextSeriesNomer.Text = subscribers.series_passport_number;
            TextDateOfIssue.Text = Convert.ToString( subscribers.date_of_issue);
            TextIssuesBy.Text = subscribers.issued_by;
            TextContractNumber.Text = subscribers.contract_number;
            TextDateConclusion.Text = Convert.ToString(subscribers.date_conclusion_contract);
            TextContractType.Text = Convert.ToString(subscribers.kod_contract_type);
            TextTerminationDate.Text = Convert.ToString(subscribers.termination_date);
            TextReason.Text = subscribers.reason_for_termination;
            TextPersonalAccount.Text = Convert.ToString(subscribers.personal_account);

            //TextServices.Text = Convert.ToString(subscribers.personal_account);
            //TextServicesConnectionData.Text = Convert.ToString(subscribers.personal_account);
            TextEquipment.Text = Convert.ToString(subscribers.equipment_number);
        }

        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ClassFrame.frame.Navigate(new PageMainMenu());
            }
            catch
            {
                MessageBox.Show("Что-то пошло не так", "Ошибка");
            }

        }
    }
}
