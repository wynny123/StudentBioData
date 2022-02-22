using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentBioData.Models
{

    public class CreateStudentDTO
    {
        [Required]
        [StringLength(maximumLength: 20, ErrorMessage = "First Name is Too Long")]
        public string? FirstName { get; set; }

        [Required]
        [StringLength(maximumLength: 20, ErrorMessage = "Last Name is Too Long")]
        public string? LastName { get; set; }
        public string? MiddleName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? Department { get; set; }
        public string? Level { get; set; }
        public string? LGA { get; set; }
        public string? StateOfOrigin { get; set; }

        [Required]
        [StringLength(maximumLength: 50, ErrorMessage = "Country Name is Too Long")]
        public string? Nationality { get; set; }
    }

    public class StudentDTO : CreateStudentDTO
    {
        public int Id { get; set; }
    }

    public class UpdateStudentDTO : CreateStudentDTO
    {


    }
}
