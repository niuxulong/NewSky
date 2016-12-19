using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiHost
{
    [RunInstaller(true)]
    public partial class WebApiHostServiceTest : System.Configuration.Install.Installer
    {
        public WebApiHostServiceTest()
        {
            InitializeComponent();
        }
    }
}
