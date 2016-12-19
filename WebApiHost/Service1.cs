using Microsoft.Owin.Hosting;
using System;
using System.Reflection;
using System.ServiceProcess;

namespace WebApiHost
{
    public partial class Service1 : ServiceBase
    {
        private IDisposable _apiServer = null;
        public Service1()
        {
            Assembly.Load("NewSky.WebApi");
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            string baseUrl = "http://127.0.0.1:8001/";
            _apiServer = WebApp.Start<Startup>(url: baseUrl);
        }

        protected override void OnStop()
        {
            if (_apiServer != null)
            {
                _apiServer.Dispose();
            }
            base.OnStop();
        }
    }
}
