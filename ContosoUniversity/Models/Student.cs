using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContosoUniversity.Models
{
    public class Student
    {
        public int ID { get; set; }

        //Le nom ne doit pas dépasser 50 characteres
        [StringLength(50, ErrorMessage = "Last name cannot be longer than 50 chars.")]
        //Le nom doit commencer pas une majuscule et être suivis de lettre minuscule
        [RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$", ErrorMessage ="The first character must be uppercase. Only letter are allowed.")]
        public string LastName { get; set; }

        //Le prénom ne doit pas dépasser 50 characteres
        [StringLength(50, ErrorMessage = "First name cannot be longer than 50 chars.")]
        //La colonne FirstMidName est renommée en FirstName
        [Column("FirstName")]
        public string FirstMidName { get; set; }

        [DataType(DataType.Date)]
        //Force le format d'affichage de la date.
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime EnrollmentDate { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; }
    }
}