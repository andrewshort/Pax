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
using PaxService.Model.Enum;
using PaxService.Model.Interfaces;
using PaxService.Model;
using PaxService.Parsers;
using PaxService.Parsers.Interfaces;
using PaxService.Handlers.Interfaces;
using PaxService.Handlers;
using Pax.Data.Interfaces;
using Pax.Data;

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
            container.Bind<IMessageWriter>().To<MessageWriter>();
            container.Bind<ICommunicationParser>().To<CommunicationParser>();
            container.Bind<ILogger>().To<Logger>();

            container.Bind<IEventTypeParser>().To<EventTypeParser>();

            container.Bind<IAvsysObject>().To<AvsysObject>();
            container.Bind<IAvrmcObject>().To<AvrmcObject>();

            container.Bind<IAvrmcParser>().To<AvrmcParser>();
            container.Bind<IAvsysParser>().To<AvsysParser>();

            container.Bind<IAvrmcHandler>().To<AvrmcHandler>();
            container.Bind<IAvsysHandler>().To<AvsysHandler>();
            container.Bind<IEchkHandler>().To<EChkHandler>();

            container.Bind<IDeviceRepository>().To<DeviceRepository>();
            container.Bind<ICommandRepository>().To<CommandRepository>();

            container.Bind<ICommandService>().To<CommandService>().InSingletonScope();
        }
    }
}
