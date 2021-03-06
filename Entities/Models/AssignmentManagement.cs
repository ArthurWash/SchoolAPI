using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class AssignmentManagement
    {
        [Column("AssignmentID")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Assignment Title is a required field.")]
        public string AssignmentTitle { get; set; }

        [Required(ErrorMessage = "Description is a required field.")]
        public string Description { get; set; }

        public CourseSectionManagement CourseSection { get; set; }
    }
}