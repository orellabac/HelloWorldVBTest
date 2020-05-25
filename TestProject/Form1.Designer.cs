using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;
using System.Linq;
using System.Xml.Linq;
using System.Threading.Tasks;

namespace HelloWorld
{

   // [global::Microsoft.VisualBasic.CompilerServices.DesignerGeneratedAttribute()]
    partial class Form1
       : System.Windows.Forms.Form
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

        //Required by the Windows Form Designer
        private System.ComponentModel.IContainer components;

        //NOTE: The following procedure is required by the Windows Form Designer
        //It can be modified using the Windows Form Designer.  
        //Do not modify it using the code editor.
        //NOTE: The following procedure is required by the Windows Form Designer
        //It can be modified using the Windows Form Designer.  
        //Do not modify it using the code editor.
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        private void InitializeComponent()
        {
            this.Button1 = new System.Windows.Forms.Button();
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
            //
            //Form1
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6.0f, 13.0f);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(254, 194);
            this.Controls.Add((System.Windows.Forms.Control)this.Button1);
            this.Name = @"Form1";
            this.Text = @"Form1";
            this.ResumeLayout(false);
            Button1.Click += new System.EventHandler(Button1_Click);
        }

        internal Button Button1;
    }

}