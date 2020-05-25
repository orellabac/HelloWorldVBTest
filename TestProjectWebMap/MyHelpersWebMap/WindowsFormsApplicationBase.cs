using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security;
using System.Security.Principal;
using System.Threading;
using System.Timers;
using Mobilize.WebMap.Common.Attributes;
using Mobilize.Web.Extensions;
using Mobilize.Web;

namespace Mobilize.Helpers
{

   [Observable]
   public class WindowsFormsApplicationBase
   {

       public WindowsFormsApplicationBase() { }

       public WindowsFormsApplicationBase(AuthenticationMode authenticationMode)
       {
           this.MinimumSplashScreenDisplayTime = 2000;
           m_Ok2CloseSplashScreen = true;
           if (authenticationMode == AuthenticationMode.Windows)
         {
             try
             {
                 Thread.CurrentPrincipal = new WindowsPrincipal(WindowsIdentity.GetCurrent());
             }
             catch (SecurityException)
             {
             }
         }
         this.ApplicationContext = new WinFormsAppContext(this);
     }

     [Obsolete("Compilation Stub")]
      [Intercepted]
     protected static bool UseCompatibleTextRendering { get; set; }

      /// <summary>
      /// Gets or sets a value indicating whether the application saves the user settings on exit.
      /// </summary>
      [Intercepted]
      public bool SaveMySettingsOnExit { get; set; }

      /// <summary>
      /// Gets the System.Windows.Forms.ApplicationContext object for the current thread
      ///     of a Windows Forms application.
      /// </summary>
      [Intercepted]
      public ApplicationContext ApplicationContext { get; set; }

      /// <summary>
      /// Gets or set a the value for that deetermines the minimum length of time, in milliseconds, for which the splash
      ///     screen is displayed.
      /// </summary>
      [Intercepted]
      public int MinimumSplashScreenDisplayTime { get; set; }

      /// <summary>
      /// Gets or sets the splash screen for this application.
      /// </summary>
      [Intercepted]
      public Mobilize.Web.Form SplashScreen { get; set; }

      /// <summary>
      /// Gets the collection of open forms
      /// </summary>
      public delegate void NetworkAvailableEventHandler(object sender, NetworkAvailableEventArgs e);


      public IList<Mobilize.Web.Form> OpenForms
      {
          get
          {
                return Mobilize.Web.Application.CurrentApplication.OpenForms;
          }
      }

      /// <summary>
      /// Gets or sets the main form for this application.
      /// </summary>
      [Intercepted]
      public Mobilize.Web.Form MainForm { get; set; }

      /// <summary>
      /// Gets or sets a value whether this application is a single-instance application.
      /// </summary>
      [Intercepted]
      public bool IsSingleInstance { get; set; }

      /// <summary>
      /// Gets or sets whether this application will use the Windows XP styles for windows,
      ///     controls, and so on.
      /// </summary>
      [Intercepted]
      public bool EnableVisualStyles { get; set; }


      /// <summary>
      /// Determines what happens when the application's main form closes.
      /// </summary>
      [Intercepted]
      public ShutdownMode ShutdownStyle { get; set; }


      /// <summary>
      /// Occurs when the application encounters an unhandled exception.
      /// </summary>
      public event UnhandledExceptionEventHandler UnhandledException;
      //
      // Summary:
      //     Occurs when the application shuts down.
      public event ShutdownEventHandler Shutdown;
      //
      // Summary:
      //     Occurs when attempting to start a single-instance application and the application
      //     is already active.
      public event StartupNextInstanceEventHandler StartupNextInstance;
      //
      // Summary:
      //     Occurs when the application starts.
      public event StartupEventHandler Startup;
      //
      // Summary:
      //     Occurs when the network availability changes.
      public event NetworkAvailableEventHandler NetworkAvailabilityChanged;

      /// <summary>
      /// Processes all Windows messages currently in the message queue.
      /// </summary>
      public void DoEvents() { }

      private void DoApplicationModel()
      {
          StartupEventArgs eventArgs = new StartupEventArgs(this.CommandLineArgs);
          if (!Debugger.IsAttached)
          {
              try
              {
                  if (OnInitialize(this.CommandLineArgs) && OnStartup(eventArgs))
                  {
                      OnRun();
                      OnShutdown();
                  }
              }
              catch (Exception exception)
              {
                  if (!OnUnhandledException(new UnhandledExceptionEventArgs(exception, true)))
                  {
                      throw;
                  }
              }
          }
          else if (OnInitialize(this.CommandLineArgs) && OnStartup(eventArgs))
          {
              OnRun();
              OnShutdown();
          }
      }


      /// <summary>
      /// Sets up and starts the app mondel
      /// </summary>
      /// <param name="commandLine"></param>
      public void Run(string[] commandLine)
      {
          this.CommandLineArgs = commandLine.ToList();
          //if (!IsSingleInstance)
          {
              DoApplicationModel();
              return;
          }
          throw new Exception("CantStartSingleInstanceException");
      }


      /// <summary>
      /// Hides the application's splash screen
      /// </summary>
      public void HideSplashScreen()
      {
          this.SplashScreen?.Hide();
      }

      /// <summary>
      /// Triggers code that configures
      //     the splash screen and main form.
      /// </summary>
      /// <param name="action"></param>
      protected virtual void OnCreateMainForm()
      {

      }

      /// <summary>
      /// code that initializes
      ///     the splash screen.
      /// </summary>
      /// <param name="action"></param>
      protected virtual void OnCreateSplashScreen()
      {

      }


      /// <summary>
      /// Sets the visual styles, text display styles, and current principal for the main
      /// application thread (if the application uses Windows authentication), and initializes
      /// the splash screen, if defined.
      /// </summary>
      /// <param name="commandLineArgs"></param>
      /// <returns></returns>
      public bool OnInitialize(IEnumerable<string> commandLineArgs)
      {
          if (!commandLineArgs.Contains("/nosplash") && !commandLineArgs.Contains("-nosplash"))
          {
              ShowSplashScreen();
          }
          //m_FinishedOnInitilaize = true;
          return true;
      }

      /// <summary>
      ///  Provides the starting point for when the main application is ready to start running,
      ///  after the initialization is done.
      /// </summary>
      public void OnRun()
      {
          if (MainForm == null)
         {
             OnCreateMainForm();
             if (MainForm == null)
            {
                throw new Exception("NoStartupForm");
            }
            MainForm.Load += MainFormLoadingDone;
        }
        try
        {
                this.ApplicationContext.Show();
        }
        finally
        {
            //if (m_NetworkObject != null)
            //{
            //    m_NetworkObject.DisconnectListener();
            // }
        }
    }

      [Intercepted]


      private bool m_Ok2CloseSplashScreen { get; set; }

      [Intercepted]
      private System.Timers.Timer m_SplashTimer { get; set; }

      [Intercepted]
      private bool m_DidSplashScreen { get; set; }

      [Intercepted]
      private List<string> CommandLineArgs { get; set; }

      private void MainFormLoadingDone(object sender, EventArgs e)
      {
          MainForm.Load -= MainFormLoadingDone;
          while (!m_Ok2CloseSplashScreen)
          {
              DoEvents();
          }
          HideSplashScreen();
      }



      /// <summary>
      /// allows for code to run when the application
      ///     shuts down.
      /// </summary>
      protected virtual void OnShutdown()
      {
          this.Shutdown?.Invoke(this, EventArgs.Empty);
      }


      /// <summary>
      /// allows for code to run when the application
      ///     starts.
      /// </summary>
      /// <param name="eventArgs"></param>
      /// <returns></returns>
      protected virtual bool OnStartup(StartupEventArgs eventArgs)
      {
          eventArgs.Cancel = false;
          //if (m_TurnOnNetworkListener & (m_NetworkObject == null))
          //{
          //    m_NetworkObject = new Network();
          //    m_NetworkObject.NetworkAvailabilityChanged += NetworkAvailableEventAdaptor;
          // }
          this.Startup?.Invoke(this, eventArgs);
          return !eventArgs.Cancel;
      }

      /// <summary>
      /// allows for code to run when a subsequent
      ///     instance of a single-instance application starts.
      /// </summary>
      /// <param name="eventArgs"></param>
      protected virtual void OnStartupNextInstance(StartupNextInstanceEventArgs eventArgs)
      {

      }

      /// <summary>
      /// allows for code to run when an unhandled
      ///     exception occurs in the application.
      /// </summary>
      /// <param name="e"></param>
      /// <returns></returns>
      protected virtual bool OnUnhandledException(UnhandledExceptionEventArgs e)
      {
          return false;
      }


      private void MinimumSplashExposureTimeIsUp(object sender, ElapsedEventArgs e)
      {
          if (m_SplashTimer != null)
         {
             m_SplashTimer.Dispose();
             m_SplashTimer = null;
         }
         m_Ok2CloseSplashScreen = true;
     }

     /// <summary>
     /// Determines if the application has a splash screen defined, and if it does, displays
     //     it.
     /// </summary>
     protected void ShowSplashScreen()
     {
         if (m_DidSplashScreen)
         {
             return;
         }
         m_DidSplashScreen = true;
         if (this.SplashScreen == null)
         {
             OnCreateSplashScreen();
         }
         if (this.SplashScreen != null)
         {
             if (this.MinimumSplashScreenDisplayTime > 0)
             {
                 m_Ok2CloseSplashScreen = false;
                 m_SplashTimer = new System.Timers.Timer(MinimumSplashScreenDisplayTime);
                 m_SplashTimer.Elapsed += MinimumSplashExposureTimeIsUp;
                 m_SplashTimer.AutoReset = false;
             }
             else
             {
                 m_Ok2CloseSplashScreen = true;
             }
             new Thread(DisplaySplash).Start();
         }
     }

     private void DisplaySplash()
     {
         if (m_SplashTimer != null)
         {
             m_SplashTimer.Enabled = true;
         }SplashScreen.Show();
     }

   }
}