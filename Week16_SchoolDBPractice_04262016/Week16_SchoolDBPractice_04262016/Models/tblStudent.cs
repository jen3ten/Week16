//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Week16_SchoolDBPractice_04262016.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblStudent
    {
        public int StudentID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Grade { get; set; }
        public int SchoolID { get; set; }
    
        public virtual tblSchool tblSchool { get; set; }
    }
}
