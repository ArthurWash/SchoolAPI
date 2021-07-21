using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.DataTransferObjects
{
    public class CourseForCreationDto
    {
        [Required(ErrorMessage = "Course Title is a required field.")]
        [MaxLength(60, ErrorMessage = "Maximum length for the Course is 60 characters.")]
        [MinLength(5, ErrorMessage = "Minimum length for the Name is 5 characters.")]
        public string CourseTitle { get; set; }

        [Required(ErrorMessage = "Description is a required field.")]
        [MaxLength(1000, ErrorMessage = "Maximum length for the Description is 1000 characters.")]
        [MinLength(1, ErrorMessage = "Minimum length for the Description is 1 characters.")]
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
