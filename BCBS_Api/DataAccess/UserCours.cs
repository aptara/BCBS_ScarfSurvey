//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BCBS_Api.DataAccess
{
    using System;
    using System.Collections.Generic;
    
    public partial class UserCours
    {
        public System.Guid Id { get; set; }
        public Nullable<System.Guid> UserId { get; set; }
        public Nullable<System.Guid> CourseId { get; set; }
        public Nullable<int> Score { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string NPI { get; set; }
    
        public virtual Course Course { get; set; }
        public virtual User User { get; set; }
    }
}
