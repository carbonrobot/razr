using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Practices.Unity;

namespace Razr.Web
{
    public class SessionLifetimeManager : LifetimeManager
    {
        private string sessionKey = Guid.NewGuid().ToString();

        public SessionLifetimeManager()
        {
        }

        public override object GetValue()
        {
            return HttpContext.Current.Session[this.sessionKey];
        }

        public override void RemoveValue()
        {
            HttpContext.Current.Session.Remove(this.sessionKey);
        }

        public override void SetValue(object newValue)
        {
            HttpContext.Current.Session[this.sessionKey] = newValue;
        }
    }

    public class PerRequestLifetimeManager : LifetimeManager
    {
        private string _key = Guid.NewGuid().ToString();

        public override object GetValue()
        {
            return HttpContext.Current.Items[_key];
        }

        public override void SetValue(object value)
        {
            HttpContext.Current.Items[_key] = value;
        }

        public override void RemoveValue()
        {
            HttpContext.Current.Items.Remove(_key);
        }
    }
}