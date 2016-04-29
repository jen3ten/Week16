using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Week16_KLGradeBookv2_04282016.Models
{
    public class GradesMetaData
    {
        [Display(Name = "Points Earned")]
        public object PointsEarned;

        [Display(Name ="Letter Grade")]
        public object Grade1;

        [Display(Name = "Student Name")]
        public object StudentID;

        [Display(Name = "Assignment Name")]
        public object AssignmentID;

    }
}