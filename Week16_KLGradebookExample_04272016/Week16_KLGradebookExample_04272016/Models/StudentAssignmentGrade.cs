//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Week16_KLGradebookExample_04272016.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class StudentAssignmentGrade
    {
        public int StudentID { get; set; }
        public int AssignmentID { get; set; }
        public int PointsAwarded { get; set; }
        public string Grade { get; set; }
    
        public virtual Assignment Assignment { get; set; }
        public virtual Student Student { get; set; }
    }
}
