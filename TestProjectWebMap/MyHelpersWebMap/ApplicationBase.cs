using System;
using System.ComponentModel;
using System.Reflection;
using Mobilize.WebMap.Common.Attributes;
using Mobilize.Web.Extensions;
using Mobilize.Web;

namespace Mobilize.Helpers
{
    public delegate void ShutdownEventHandler(object sender, EventArgs e);

    public delegate void StartupEventHandler(object sender, StartupEventArgs e);

    public delegate void NetworkAvailableEventHandler(object sender, NetworkAvailableEventArgs e);

    public delegate void StartupNextInstanceEventHandler(object sender, StartupNextInstanceEventArgs e);

    [Observable]


   public class WinFormsAppContext : ApplicationContext
   {

      [Intercepted]
      private WindowsFormsApplicationBase m_App { get; set; }


      public WinFormsAppContext(WindowsFormsApplicationBase App)
      {
          m_App = App;
      }

      protected override void OnMainFormClosed(object sender, EventArgs e)
      {
          if (m_App.ShutdownStyle == ShutdownMode.AfterMainFormCloses)
         {
             base.OnMainFormClosed(sender, e);
             return;
         }
         var openForms = Mobilize.Web.Application.CurrentApplication.OpenForms;
         if (openForms.Count > 0)
         {
             base.MainForm = openForms[0];
         }
         else
         {
             base.OnMainFormClosed(sender, e);
         }
     }

   }
}