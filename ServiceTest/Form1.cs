using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Windows.Forms;
using NewSky.Platform.Api;
using NewSky.Platform.Api.WebApi.Interfaces;

namespace ServiceTest
{
	public partial class Form1 : Form
	{
		[ImportMany]
		private IEnumerable<IServiceModule> modules;

		public Form1()
		{
			InitializeComponent();
			IoC.ComposeParts(this);
		}

		private void btnStart_Click(object sender, EventArgs e)
		{
			foreach (var module in modules)
			{
				module.OnStart();
			}

			ServiceInfo.Text = "Service is Running.";
		}

		private void btnStop_Click(object sender, EventArgs e)
		{
			foreach (var module in modules)
			{
				module.OnStop();
			}

			ServiceInfo.Text = "Service is Stopped.";
		}
	}
}
