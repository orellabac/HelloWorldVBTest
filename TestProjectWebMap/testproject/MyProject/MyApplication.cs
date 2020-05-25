using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Linq;
using System.Xml.Linq;
using System.Threading.Tasks;
using Mobilize.Helpers;
using Mobilize.WebMap.Common.Attributes;
using Mobilize.Web.Extensions;

namespace HelloWorld
{
    namespace My
    {

       [Observable]

       //remove //NOTE: This file is auto-generated; do not modify it directly.  To make changes,
       //remove // or if you encounter build errors in this file, go to the Project Designer
       //remove // (go to Project Properties or double-click the My Project node in
       //remove // Solution Explorer), and make changes on the Application tab.
       //remove //
       internal
          partial class MyApplication : WindowsFormsApplicationBase
       {

           //remove [global::System.Diagnostics.DebuggerStepThroughAttribute()]
           public MyApplication()
           : base(AuthenticationMode.Windows)
           {
               this.IsSingleInstance = false;
               this.EnableVisualStyles = true;
               this.SaveMySettingsOnExit = true;
               this.ShutdownStyle = ShutdownMode.AfterMainFormCloses;
           }

           //remove [global::System.Diagnostics.DebuggerStepThroughAttribute()]
           protected override void OnCreateMainForm()
           {
               this.MainForm = MyHelpers.MyProject.MyForms.Form<Form1>();
               this.MainForm.Show();
           }

          public static void Main(string[] args)
          {
              new MyApplication().Run(args);
          }

       }



    }
}