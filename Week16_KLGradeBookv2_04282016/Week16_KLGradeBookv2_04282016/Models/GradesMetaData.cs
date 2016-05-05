using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Week16_KLGradeBookv2_04282016.Models
{
    [MetadataType(typeof(GradesMetaData))]
    public partial class Grade
    {

    }

    sealed class GradesMetaData
    {
        [Display(Name = "Points Earned")]
        public int PointsEarned { get; set; }

        [Display(Name ="Letter Grade")]
        public string Grade1 { get; set; }

        [Display(Name = "Student Name")]
        public int StudentID { get; set; }

        [Display(Name = "Assignment Name")]
        public int AssignmentID { get; set; }


    }
}