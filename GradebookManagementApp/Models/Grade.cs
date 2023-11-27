using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GradebookManagementApp.Models
{
    public class Grade
    {
        [Key]
        public int StudentId { get; set; }
        public string CourseCode { get; set; }
        public double Score { get; set; }
    }
}