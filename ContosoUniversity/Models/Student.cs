using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContosoUniversity.Models
{
    public class Student
    {
        public int ID { get; set; }

        //Le champ nom est requis
        [Required]
        //Le nom ne doit être compris entre 2 et 50 characteres
        [StringLength(50, MinimumLength = 2,ErrorMessage = "Last name cannot be longer than 50 chars.")]
        //Le nom doit commencer pas une majuscule et être suivis de lettre minuscule
        [RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$", ErrorMessage ="The first character must be uppercase. Only letter are allowed.")]
        //Définis le nom affiché de la colonne
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        
        [Required]
        [StringLength(50, ErrorMessage = "First name cannot be longer than 50 chars.")]
        //La colonne FirstMidName est renommée en FirstName
        [Column("FirstName")]
        [Display(Name = "First Name")]
        public string FirstMidName { get; set; }

        [DataType(DataType.Date)]
        //Force le format d'affichage de la date.
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name ="Enrollment Name")]
        public DateTime EnrollmentDate { get; set; }

        [Display(Name ="Full Name")]
        public string FullName
        {
            get
            {
                return LastName + ", " + FirstMidName;
            }
        }

        public ICollection<Enrollment> Enrollments { get; set; }
    }
}