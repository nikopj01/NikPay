using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBus.Events
{
    public class AddPaymentEvent : IntegrationBaseEvent
    {
        public DateTime Datetime { get; set; }
        public decimal Amount { get; set; }
        public string FromEmail { get; set; }
        public string FromFirstName { get; set; }
        public string FromLastName { get; set; }
        public string FromVendor { get; set; }
        public string ToEmail { get; set; }
    }
}
