using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YP_2
{
    public partial class Subscribers
    {
        public string FIO
        {
            get
            {
                return surname + " " + name + " " + patronymic;
            }
        }
        public string ListServices
        {
            get
            {
                List<SubscriberServices> services = ClassBase.entities.SubscriberServices.Where(x => x.kod_subscriber == kod_subscribers).ToList();
                string strServices = "";
                for (int i = 0; i < services.Count; i++)
                {
                    if (i == services.Count - 1)
                    {
                        strServices = strServices + services[i].Services.name;
                    }
                    else
                    {
                        strServices = strServices + services[i].Services.name + ", ";
                    }
                }
                return strServices;
            }
            set
            {

            }
        }

    }
}
