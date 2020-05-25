using System.Collections.Generic;
using System.ComponentModel;
using Mobilize.WebMap.Common.Attributes;

namespace Mobilize.Helpers
{

   [Observable]
   public class StartupEventArgs : CancelEventArgs
   {

      [Intercepted]
      private IList<string> args { get; set; }


      public StartupEventArgs(IList<string> args) { this.args = args; }

      [Intercepted]


      public IList<string> CommandLine => this.args;

   }
}