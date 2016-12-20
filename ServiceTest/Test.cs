using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceTest
{
	[Export(typeof(ITest))]
	public class Test : ITest
	{
		public string Show()
		{
			return "OOOOO";
		}
	}
}
