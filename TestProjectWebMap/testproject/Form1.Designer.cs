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
using Mobilize.WebMap.Common.Attributes;
using Mobilize.Web.Extensions;

namespace HelloWorld
{

   partial class Form1
      : Mobilize.Web.Form
   {

       public Form1()
       {
           InitializeComponent();
       }

       //Form overrides dispose to clean up the component list.
       //Form overrides dispose to clean up the component list.
       [System.Diagnostics.DebuggerNonUserCodeAttribute()]
       protected override void Dispose(bool disposing)
       {
           try
           {
               if (disposing && !Object.ReferenceEquals(components, default(dynamic)))
               {
                   components.Dispose();
               }
           }
           finally
           {
               base.Dispose(disposing);
           }
       }

      [Intercepted]

      //Required by the Windows Form Designer
      private
      System.ComponentModel.IContainer components { get; set; }

      //NOTE: The following procedure is required by the Windows Form Designer
      //It can be modified using the Windows Form Designer.  
      //Do not modify it using the code editor.
      //NOTE: The following procedure is required by the Windows Form Designer
      //It can be modified using the Windows Form Designer.  
      //Do not modify it using the code editor.
      [System.Diagnostics.DebuggerStepThroughAttribute()]
      [Mobilize.WebMap.Common.Attributes.Designer]
      private void InitializeComponent()
      {
          this.Button1 = new Mobilize.Web.Button();
          this.SuspendLayout();
          //
          //Button1
          //
          this.Button1.Location = new System.Drawing.Point(85, 82);
          this.Button1.Name = @"Button1";
          this.Button1.Size = new System.Drawing.Size(75, 23);
          this.Button1.TabIndex = 0;
          this.Button1.Text = @"Hello world!";
          this.Button1.UseVisualStyleBackColor = true;
        //Stub this.Properties().AutoScaleDimensions = new System.Drawing.SizeF(6.0f, 13.0f);
        //Stub this.Properties().AutoScaleMode = Stub._System.Windows.Forms.AutoScaleMode.Font;
         //Stub this.Properties().ClientSize = new System.Drawing.Size(254, 194);
         this.Controls.Add((Mobilize.Web.Control)this.Button1);
         this.Name = @"Form1";
         this.Text = @"Form1";
         //Stub this.ResumeLayout(false);
         Button1.Click += new System.EventHandler(Button1_Click);
     }

      [Intercepted]

      internal Mobilize.Web.Button Button1 { get; set; }

   }

}