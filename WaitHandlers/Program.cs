using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WaitHandlers
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomerService cs = new CustomerService();

                new Thread(() => { cs.NewSupportPersonArrived(); }).Start();
                new Thread(() => { cs.GiveSupportToCustomer(); }).Start();
        }
    }
}
