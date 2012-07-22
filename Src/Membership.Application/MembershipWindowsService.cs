using System.ServiceProcess;

namespace Membership.Application
{
    partial class MembershipWindowsService : ServiceBase
    {
        public MembershipWindowsService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            Bootstrapper.Initialize();
        }

        protected override void OnStop()
        {
            //Logger.Log("MembershipWindowsService stopped!");
        }
    }
}
