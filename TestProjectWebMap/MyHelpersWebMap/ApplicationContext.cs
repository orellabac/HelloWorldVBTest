using System;

namespace Mobilize.Web
{

   public class ApplicationContext
   {
        public Form MainForm { get; internal set; }

        protected virtual void OnMainFormClosed(object sender, System.EventArgs e)
      {
      }

        internal void Show()
        {
            this.MainForm?.Show();
        }
    }

}