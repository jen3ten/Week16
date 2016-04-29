using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Week16_KLGradeBookv2_04282016.Models
{
    public class StudentMetaData
    {
        [Display(Name = "First Name")]
        [Required(ErrorMessage = "First Name is required.")]
        public object FirstName;

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Last Name is required.")]
        public object LastName;
    }

}