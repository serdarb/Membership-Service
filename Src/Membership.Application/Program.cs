using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using Membership.Data;

namespace Membership.Application
{
    class Program
    {
        static void Main(string[] args)
        {
            if (Environment.UserInteractive)
            {

                Bootstrapper.Initialize();

#warning test migration
                DbMigrationInstaller.Configure();

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
