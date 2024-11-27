using System.ComponentModel.DataAnnotations;

namespace StudentCurdUsingAdo.Models
{
    public class Student
    {
        [Key]
        public int Rollno { get; set; }

        [Required]
        [Display(Name = "Student Name")]
        public string? Name { get; set; }

        [Required]

        [Display(Name = "Student Branch")]
        public string? Branch { get; set; }

        [Required]

        [Display(Name = "Percentage")]
        public decimal? Percentage { get; set; }

    }
}
