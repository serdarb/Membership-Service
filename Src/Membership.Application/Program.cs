using System;
using System.Collections.Generic;
using System.ServiceProcess;
using System.Text;

namespace Membership.Application
{
    class Program
    {
        static void Main(string[] args)
        {
            if (Environment.UserInteractive)
            {
                Bootstrapper.Initialize();
                Console.WriteLine("Membership.Server is ready!");

                Console.ReadLine();
            }
            else
            {
                ServiceBase.Run(new ServiceBase[] { new MembershipWindowsService() });
            }
        }
    }
}
