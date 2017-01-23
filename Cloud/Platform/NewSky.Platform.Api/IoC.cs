using System;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.IO;

namespace NewSky.Platform.Api
{
	public class IoC
	{
		private static CompositionContainer container;

		public static void ComposeParts(object part)
		{
			try
			{
				var appCatalog = new DirectoryCatalog(Directory.GetCurrentDirectory(), "NewSky*.dll");
				container = new CompositionContainer(appCatalog);
				container.ComposeParts(part);
			}
			catch (Exception ex)
			{
				if (container != null)
				{
					container.Dispose();
				}
			}
		}
	}
}
