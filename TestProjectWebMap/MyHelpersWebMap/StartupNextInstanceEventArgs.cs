using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Mobilize.WebMap.Common.Attributes;

namespace Mobilize.Helpers
{

   [Observable]
   public class StartupNextInstanceEventArgs : EventArgs
   {
       /// <summary>
       /// 
       /// </summary>
       /// <param name="args"></param>
       /// <param name="bringToForegroundFlag"> A System.Boolean that indicates whether the first application instance should
       //     be brought to the foreground upon exiting the exception handler.</param>
       public StartupNextInstanceEventArgs(IEnumerable<string> args, bool bringToForegroundFlag)
       {
           this.BringToForeground = bringToForegroundFlag;
           this.CommandLine = args.ToList();
       }

      /// <summary>
      /// Indicates whether the first application instance should be brought to the foreground
      //     upon exiting the exception handler.
      /// </summary>
      [Intercepted]
      public bool BringToForeground { get; set; }

      /// <summary>
      /// Gets the command-line arguments of the subsequent application instance.
      /// </summary>
      [Intercepted]
      public IList<string> CommandLine { get; }

   }
}