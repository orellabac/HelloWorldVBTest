using Mobilize.WebMap.Common.Attributes;

namespace Mobilize.Helpers
{

   [Observable]



   public partial class MyProject
   {

      [Intercepted]

      public MyForms MyForms { get; set; } = new MyForms();

      [Intercepted]

      public MyComputer Computer { get; set; } = new MyComputer();

      [Intercepted]

      public MyWebServices WebServices { get; set; } = new MyWebServices();

   }

   [Observable]

   public static class MyHelpers
   {

      [Intercepted]
      public static MyProject MyProject { get; set; } = new MyProject();

   }

}