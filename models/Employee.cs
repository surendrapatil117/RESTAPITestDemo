using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RESTAPITestDemo.models
{
    public class Employee
    {
        [Key]
        public Guid Employee_Id { get; set; }
        [Required(ErrorMessage ="Employe Name must be entered")]
        [MaxLength(50,ErrorMessage ="Maximum Lenth is 50 character")]
        public string Name { get;set;}
        [Required(ErrorMessage = "Employe Address must be entered")]
        [MaxLength(500, ErrorMessage = "Maximum Lenth is 500 character")]
        public string Address { get; set; }
    }
}
