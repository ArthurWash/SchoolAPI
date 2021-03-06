using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class CourseManagement
    {
        [Column("CourseManagementID")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "CourseTitle is a required field.")]
        [MaxLength(60, ErrorMessage = "Maximum length for the CourseTitle is 60 characters.")]
        [MinLength(5, ErrorMessage = "Minimum length for the CourseTitle is 5 characters.")]
        public string CourseTitle { get; set; }
        [Required(ErrorMessage = "Description is a required field.")]
        [MaxLength(1000, ErrorMessage = "Maximum length for the Description is 1000 characters.")]
        [MinLength(1, ErrorMessage = "Minimum length for the Description is 1 characters.")]
        public string Description { get; set; }

        [ForeignKey(nameof(User))]
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }


    }
}