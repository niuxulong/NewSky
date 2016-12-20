using System;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using NewSky.Platform.Interfaces;

namespace ServiceTest
{
	public partial class Form1 : Form
	{
		[Import]
		private IServiceModule newSkyServiceModule;

		private CompositionContainer container;

		public Form1()
		{
			InitializeComponent();
			try
			{
				var appCatalog = new DirectoryCatalog(Directory.GetCurrentDirectory(), "NewSky*.dll");
				container = new CompositionContainer(appCatalog);
				container.ComposeParts(this);
			}
			catch (Exception ex)
			{
				if (container != null)
				{
					container.Dispose();
				}
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			newSkyServiceModule.OnStart();
		}
	}
}
