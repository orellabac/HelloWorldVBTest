using System;
using Mobilize.WebMap.Common.Attributes;

namespace Mobilize.Helpers
{

   [Observable]
   public class NetworkAvailableEventArgs : EventArgs
   {
       /// <summary>
       /// 
       /// </summary>
       /// <param name="networkAvailable">A System.Boolean that indicates whether a network is available to the application</param>
       public NetworkAvailableEventArgs(bool networkAvailable)
       {
           this.IsNetworkAvailable = networkAvailable;
       }

      /// <summary>
      /// Gets a value indicating whether a network is available to the application.
      /// </summary>
      [Intercepted]
      public bool IsNetworkAvailable { get; private set; }

   }
}