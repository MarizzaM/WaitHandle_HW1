using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WaitHandlers
{
    class CustomerService
    {
        private ManualResetEvent gate = new ManualResetEvent(false);

        private int m_support_people = 0;
        private static Random r = new Random();
        // which event handler to use?

        public void NewSupportPersonArrived()
        {
            // support will be given only 
            
            while (m_support_people < 3)
            {
                Console.WriteLine("Another support person arrived");
                Thread.Sleep(r.Next(100, 1000));
                m_support_people++;
            }
            gate.Set();
        }
        public void GiveSupportToCustomer()
        {
            // do not accept customers if you have 3 or less support people
            Console.WriteLine("customer arrived");

            gate.WaitOne();

            m_support_people--;
            Console.WriteLine("Giving support");
            Thread.Sleep(r.Next(5000, 10000));
            m_support_people++;
        }
    }
}
