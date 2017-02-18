using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceBusManager;

namespace ServiceBusManagerTest
{
    class Program
    {
        static void Main(string[] args)
        {
            SbManage manage = new SbManage();
            bool success = manage.CreateSubscription();
            Console.WriteLine(success.ToString());
            Console.ReadLine();
        }
    }
}
