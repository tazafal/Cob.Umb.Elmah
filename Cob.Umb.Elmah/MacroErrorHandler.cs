using Elmah;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core;
using Umbraco.Core.Events;
using Umbraco.Web;

namespace Cob.Umb.Elmah
{
    public class MacroErrorHandler : IApplicationEventHandler
    {
        public void OnApplicationStarted(UmbracoApplication httpApplication, ApplicationContext applicationContext)
        {
            umbraco.macro.Error += macro_Error;
        }

        void macro_Error(object sender, MacroErrorEventArgs e)
        {
            // From http://stackoverflow.com/a/5936867/1110395:
            ErrorSignal.FromCurrentContext().Raise(e.Exception);
        }

        public void OnApplicationInitialized(UmbracoApplication httpApplication, ApplicationContext applicationContext) { }
        public void OnApplicationStarting(UmbracoApplication httpApplication, ApplicationContext applicationContext) { }
    }
}
