using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Employee_Management_System.Models
{
    public class Department
    {
        [Key]
        public int Department_Id { get; set; }
        [Required]
        public string Department_Name { get; set; }
        public List<Employee> Employees { get; set; }
    }
}
