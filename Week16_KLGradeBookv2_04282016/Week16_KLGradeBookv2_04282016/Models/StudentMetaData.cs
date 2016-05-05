using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Web;

namespace Week16_KLGradeBookv2_04282016.Models
{
    //Mel called this class StudentBuddy

    [MetadataType(typeof(StudentMetaData))]
    public partial class Student
    {
        public string FullName
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(FirstName);
                sb.Append(" ");
                sb.Append(LastName);
                return sb.ToString();
            }
        }
    }

    sealed class StudentMetaData //sealed cannot be changed; properties copied from the original partial class
    {
        public int StudentID { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

    }

}