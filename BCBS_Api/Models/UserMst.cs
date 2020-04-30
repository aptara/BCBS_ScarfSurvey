using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace BCBS_Api.Models
{
    public class UserMst
    {
        public int LoginUserId { get; set; }
        public string LoginFirstName { get; set; }
        public string LoginLastName { get; set; }
        public string LoginEmail { get; set; }
        public string LoginUserName { get; set; }
        public string LoginPassword { get; set; }
        public Nullable<bool> LoginIsActive { get; set; }
    }

    public class MyPrincipal : IPrincipal
    {
        public MyPrincipal(IIdentity identity)
        {
            Identity = identity;
        }
        public IIdentity Identity
        {
            get;
            private set;
        }
        public UserMst User { get; set; }

        public bool IsInRole(string role)
        {
            return true;
        }
    }
}
