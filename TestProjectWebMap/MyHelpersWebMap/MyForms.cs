using System;
using System.Collections.Generic;
using System.Reflection;
using Mobilize.WebMap.Common.Attributes;

namespace Mobilize.Helpers
{

   [Observable]

   public class MyForms
   {

      [Intercepted]
      Dictionary<Type, Mobilize.Web.Form> myForms { get; set; } = new Dictionary<Type, Mobilize.Web.Form>();

      [Intercepted]
      Dictionary<Type, Mobilize.Web.Form> m_FormBeingCreated { get; set; } = new Dictionary<Type, Mobilize.Web.Form>();

      public T Form<T>() where T : Mobilize.Web.Form, new()
      {
          var type = typeof(T);
          myForms.TryGetValue(type, out Mobilize.Web.Form instance);
         if (instance?.IsDisposed ?? true)
         {
             if (m_FormBeingCreated.ContainsKey(typeof(T)))
             {
                 throw new InvalidOperationException("Utils.GetResourceString(WinForms_RecursiveFormCreate)");
             }
             lock (m_FormBeingCreated)
             {
                 m_FormBeingCreated.Add(typeof(T), null);
             }
             try
             {
                 instance = new T();
                 myForms.Add(type, instance);
             }
             catch (TargetInvocationException ex2)
             {
                 string BetterMessage = "";//"Utils.GetResourceString(""WinForms_SeeInnerException", ex2.InnerException.Message);
                 throw new InvalidOperationException(BetterMessage, ex2.InnerException);
             }
             finally
             {
                 lock (m_FormBeingCreated)
                 {
                     m_FormBeingCreated.Remove(typeof(T));
                 }
             }
         }
         return instance as T;
     }

      public void Form<T>(T form) where T : Mobilize.Web.Form, new()
      {
          var type = typeof(T);
         Mobilize.Web.Form value;
         lock (myForms)
         {
             myForms.TryGetValue(type, out value);
         }
         if (value != form)
         {
             if (value != null)
            {
                throw new ArgumentException("Property can only be set to Nothing");
            }
            value.Dispose();
            lock (myForms)
            {
                myForms.Remove(type);

            }
        }
    }



      public MyForms()
      {
      }
   }

}