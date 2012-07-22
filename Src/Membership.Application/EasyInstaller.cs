using System.ComponentModel;
using System.Configuration.Install;
using System.ServiceProcess;


namespace Membership.Application
{
    [RunInstaller(true)]
    public partial class EasyInstaller : Installer
    {
        private readonly ServiceProcessInstaller _serviceProcess;
        private readonly ServiceInstaller _serviceInstaller;

        public EasyInstaller()
        {
            InitializeComponent();

            _serviceProcess = new ServiceProcessInstaller { Account = ServiceAccount.NetworkService };
            _serviceInstaller = new ServiceInstaller
            {
                ServiceName = "MembershipService",
                DisplayName = "Membership Service",
                Description = "Membership Service",
                StartType = ServiceStartMode.Automatic
            };
            Installers.Add(_serviceProcess);
            Installers.Add(_serviceInstaller);
        }
    }
}
