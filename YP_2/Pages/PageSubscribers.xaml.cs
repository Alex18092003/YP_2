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
            TextNomer.Text = "Номер абонента: " + subscribers.subscriber_number;
            FIO.Text = "ФИО: " + subscribers.FIO;
            TextSeriesNomer.Text = "Серия и номер паспорта: " + subscribers.series_passport_number;
            TextDateOfIssue.Text = "Дата выдачи: " + Convert.ToDateTime( subscribers.date_of_issue).ToString("d");
            TextIssuesBy.Text = "Кем выдан: " + subscribers.issued_by;
            TextContractNumber.Text = "Номер договора: " + subscribers.contract_number;
            TextDateConclusion.Text = "Дата заключения договора: " + Convert.ToDateTime(subscribers.date_conclusion_contract).ToString("d");
            TextContractType.Text = "Тип договора: " + Convert.ToString(subscribers.ContractTypes.contract_type);
            if(subscribers.termination_date != null)
            {
                TextTerminationDate.Text = "Дата расторжения: " + Convert.ToDateTime(subscribers.termination_date).ToString("d");
            }
           if(subscribers.reason_for_termination != null)
            {
                TextReason.Text = "Причина расторжения: " + subscribers.reason_for_termination;
            }
            
            TextPersonalAccount.Text = "Лицевой счет: " + Convert.ToString(subscribers.personal_account);

            TextAddress.Text = "Полный адрес: " + Convert.ToString(subscribers.place_of_residence.Substring(8));
            TextDis.Text = "Район: " + Convert.ToString(subscribers.Districts.district);

            TextServices.Text = Convert.ToString(subscribers.ListServices2);
            TextEquipment.Text = Convert.ToString(subscribers.Equipment.name);

            DateTime dateTime = DateTime.Now.AddMonths(-12); 
            List<Applications> applications = ClassBase.entities.Applications.Where(x => x.kod_subscribers == subscribers.kod_subscribers && x.date_of_creation >= dateTime).ToList();
            int ii = 1;
            for(int i = 0; i< applications.Count; i++)
            {
                if (i == applications.Count - 1) // Если последний элемент, то пробелы в конце не ставим
                {
                    TextCRM.Text = TextCRM.Text + "Номер " + $"{ii++}" + "\n";
                    TextCRM.Text = TextCRM.Text + "Номер заявки " + applications[i].number_applications + "\n";
                    TextCRM.Text = TextCRM.Text + "Дата создания: " + applications[i].date_of_creation.ToString("d") + "\n";
                    
                    TextCRM.Text = TextCRM.Text + "Услуга: " + applications[i].Services.name + "\n";
                    TextCRM.Text = TextCRM.Text + "Вид услуги: " + applications[i].ServicesView.name + "\n";
                    TextCRM.Text = TextCRM.Text + "Тип услуги: " + applications[i].ServicesTypes.name + "\n";
                    TextCRM.Text = TextCRM.Text + "Тип проблемы: " + applications[i].ProblemTypes.name + "\n";
                    if (applications[i].kod_description != null)
                    {
                        TextCRM.Text = TextCRM.Text + "Описание проблемы: " + applications[i].DescriptionsProblems.name + "\n";
                    }
                    if (applications[i].closing_date != null)
                    {
                        TextCRM.Text = TextCRM.Text + "Дата закрытия: " + Convert.ToDateTime(applications[i].closing_date).ToString("d") + "\n";
                    }
                    TextCRM.Text = TextCRM.Text + "Статус: " + applications[i].Statuses.name;
                }
                else
                {
                    TextCRM.Text = TextCRM.Text + "Номер " + $"{ii++}" + "\n";
                    TextCRM.Text = TextCRM.Text + "Номер заявки " + applications[i].number_applications + "\n";
                    TextCRM.Text = TextCRM.Text + "Дата создания: " + applications[i].date_of_creation + "\n";
                    
                    TextCRM.Text = TextCRM.Text + "Услуга: " + applications[i].Services.name + "\n";
                    TextCRM.Text = TextCRM.Text + "Вид услуги: " + applications[i].ServicesView.name + "\n";
                    TextCRM.Text = TextCRM.Text + "Тип услуги: " + applications[i].ServicesTypes.name + "\n";
                    TextCRM.Text = TextCRM.Text + "Тип проблемы: " + applications[i].ProblemTypes.name + "\n";
                    if (applications[i].kod_description != null)
                    {
                        TextCRM.Text = TextCRM.Text + "Описание проблемы: " + applications[i].DescriptionsProblems.name;
                    }
                    if (applications[i].closing_date != null)
                    {
                        TextCRM.Text = TextCRM.Text + "Дата закрытия: " + applications[i].closing_date + "\n";
                    }
                    TextCRM.Text = TextCRM.Text + "Статус: " + applications[i].Statuses.name + "\n\n";
                }
            }
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
