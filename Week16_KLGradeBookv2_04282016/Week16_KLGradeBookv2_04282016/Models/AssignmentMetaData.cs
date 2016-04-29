using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Week16_KLGradeBookv2_04282016.Models
{
    public class AssignmentMetaData
    {
        [Display(Name = "Assignment Name")]
        public object Title;

        [Display(Name = "Total Points Possible")]
        public object PossiblePoints;
    }
}