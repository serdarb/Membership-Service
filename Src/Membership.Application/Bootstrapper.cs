namespace Membership.Application
{
    using System;
    using System.Configuration;
    using System.Linq;
    using System.ServiceModel;

    using Castle.Facilities.WcfIntegration;
    using Castle.MicroKernel.Registration;
    using Castle.Windsor;

    /// <summary>
    /// The bootstrapper.
    /// </summary>
    internal class Bootstrapper
    {
        public static IWindsorContainer Container { get; private set; }
        
        public static void Initialize()
        {
            Container = new WindsorContainer();
            Container.AddFacility<WcfFacility>();

            var netNamedPipeBinding = new NetNamedPipeBinding
                                 {
                                     MaxBufferSize = 67108864,
                                     MaxReceivedMessageSize = 67108864,
                                     TransferMode = TransferMode.Streamed,
                                     ReceiveTimeout = new TimeSpan(0, 30, 0),
                                     SendTimeout = new TimeSpan(0, 30, 0)
                                 };

            var netTcpBinding = new NetTcpBinding
                                    {
                                        PortSharingEnabled = true,
                                        Security = new NetTcpSecurity {Mode = SecurityMode.None},
                                        MaxBufferSize = 67108864,
                                        MaxReceivedMessageSize = 67108864,
                                        TransferMode = TransferMode.Streamed,
                                        ReceiveTimeout = new TimeSpan(0, 30, 0),
                                        SendTimeout = new TimeSpan(0, 30, 0)
                                    };
            
            Container.Register(Types.FromAssemblyNamed("Membership.Service")
                                   .Pick().If(type => type.GetInterfaces().Any(i => i.IsDefined(typeof(ServiceContractAttribute), true)))
                                   .Configure(configurer => configurer.Named(configurer.Implementation.Name)
                                                                .LifestyleSingleton()
                                                                .AsWcfService(
                                                                    new DefaultServiceModel()
                                                                        .AddEndpoints(
                                                                            WcfEndpoint.BoundTo(netTcpBinding).At(string.Format("net.tcp://localhost:{1}/{0}", configurer.Implementation.Name, ConfigurationManager.AppSettings["Port"])),
                                                                            WcfEndpoint.BoundTo(netNamedPipeBinding).At(string.Format("net.pipe://localhost/{0}", configurer.Implementation.Name)))
                                                                .PublishMetadata())).WithService.Select(
                                                                    (type, baseTypes) =>
                                                                    type.GetInterfaces().Where(
                                                                        i => i.IsDefined(typeof(ServiceContractAttribute), true))));
        }
    }
}