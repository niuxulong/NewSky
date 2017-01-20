using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using NewSky.Platform.Api.WebApi.Interfaces;

namespace ServiceTest
{
	public partial class Form1 : Form
	{
		[ImportMany]
		private IEnumerable<IServiceModule> modules;

		private CompositionContainer IoC;

		public Form1()
		{
			InitializeComponent();
			try
			{
				var appCatalog = new DirectoryCatalog(Directory.GetCurrentDirectory(), "NewSky*.dll");
				IoC = new CompositionContainer(appCatalog);
				IoC.ComposeParts(this);
			}
			catch (Exception ex)
			{
				if (IoC != null)
				{
					IoC.Dispose();
				}
			}
		}

		private void btnStart_Click(object sender, EventArgs e)
		{
			modules.FirstOrDefault().OnStart();
			ServiceInfo.Text = "Service is Running.";
		}

		private void btnStop_Click(object sender, EventArgs e)
		{
			modules.FirstOrDefault().OnStop();
			ServiceInfo.Text = "Service is Stopped.";
		}
	}
}
