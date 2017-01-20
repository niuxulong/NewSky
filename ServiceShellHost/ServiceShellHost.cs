using Microsoft.Owin.Hosting;
using System;
using System.Reflection;
using System.ServiceProcess;

namespace ServiceShellHost
{
    public partial class ServiceShellHost : ServiceBase
    {
        public ServiceShellHost()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
			
        }

        protected override void OnStop()
        {
            base.OnStop();
        }
    }
}
