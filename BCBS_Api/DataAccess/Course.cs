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
    
    public partial class Course
    {
        public Course()
        {
            this.UserCourses = new HashSet<UserCours>();
        }
    
        public System.Guid Id { get; set; }
        public string CourseTitle { get; set; }
        public string DeliveryMethod { get; set; }
        public string TotalContactHours { get; set; }
    
        public virtual ICollection<UserCours> UserCourses { get; set; }
    }
}
