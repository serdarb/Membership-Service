using System.ServiceProcess;

namespace Membership.Application
{
    using NLog;

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

        }
    }
}
