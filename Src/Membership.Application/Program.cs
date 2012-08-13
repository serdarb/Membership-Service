using System;
using System.ServiceProcess;

namespace Membership.Application
{
    class Program
    {
        static void Main()
        {
            if (Environment.UserInteractive)
            {
                Bootstrapper.Initialize();
                Console.WriteLine("Membership Server is ready!");
                Console.ReadLine();
            }
            else
            {
                ServiceBase.Run(new ServiceBase[] { new MembershipWindowsService() });
            }
        }
    }
}
