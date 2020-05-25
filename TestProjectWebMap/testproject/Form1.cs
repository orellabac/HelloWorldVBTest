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

namespace HelloWorld
{

   [Observable]

   public partial class Form1
   {

       private void Button1_Click(dynamic sender, EventArgs e)
       {
         Mobilize.Web.MessageBox.Show(@"Hello world!");
      }

   }

}