using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewSky.Platform.Interfaces;

namespace NewSky.WebApi
{
	[InheritedExport(typeof(IProductControllerConfiguration))]
	public class NewSkyControllerConfiguration : IProductControllerConfiguration
	{
		private readonly string baseUri;

		[ImportingConstructor]
		public NewSkyControllerConfiguration()
		{
			this.baseUri = "http://127.0.0.1:8945/";
		}

		public string BaseUri
		{
			get { return this.baseUri; }
		}
	}
}
