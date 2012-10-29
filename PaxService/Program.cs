using Common;
using Ninject;
using PaxService.Listener;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Common.Interfaces;
using PaxService.Packet;

namespace PaxService
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            BuildContainer();

#if(!DEBUG)
            {
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[] 
			{ 
				ContainerManager.Resolve<Service1>() 
			};
            ServiceBase.Run(ServicesToRun);
            }

#else
            {
                Service1 s = ContainerManager.Resolve<Service1>();
                s.Run();
                System.Threading.Thread.Sleep(Timeout.Infinite);
            }
#endif
        }

        private static void BuildContainer()
        {
            var container = new StandardKernel();
            ContainerManager.Container = container;

            AddBindings(container);
        }

        private static void AddBindings(StandardKernel container)
        {
            container.Bind<Service1>().ToSelf();
            container.Bind<IListenerService>().To<ListenerService>();
            container.Bind<IConfigManager>().To<ConfigManager>();
            container.Bind<ITcpListenerAdapter>().To<TcpListenerAdapter>();
            container.Bind<ICheckSum>().To<CheckSum>();
            container.Bind<IEncodingAdapter>().To<EncodingAdapter>();
            container.Bind<IMessageProcessor>().To<MessageProcessor>();
            container.Bind<IMessageBuilder>().To<MessageBuilder>();
            container.Bind<ICommunicationParser>().To<CommunicationParser>();
            container.Bind<ILogger>().To<Logger>();
        }
    }
}
