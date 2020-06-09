using System;
using Castle.Windsor;
using MassTransit;
using Topshelf.Logging;

namespace SMSServiceHost
{
    public class SvcHost
    {
        private IWindsorContainer _container;
        private IBusControl _busControl;

        public void Start()
        {
            _container = WindsorInstaller.CreateContainer();
            _busControl = _container.Resolve<IBusControl>();
            _busControl.StartAsync();
        }

        public void Stop()
        {
            _busControl.StopAsync();
        }
    }
}