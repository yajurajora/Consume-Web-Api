using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CrudAPIWithHttpClient.Models
{
    public class Student
    {
        public int StudentId { get; set; }

        [Required(ErrorMessage = "Student name is required!!")]
        public string StudentName { get; set; }

        [Required(ErrorMessage = "Student roll no is required!!")]
        public string StudentRollNo { get; set; }
    }
}
