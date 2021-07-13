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
        [MaxLength(60, ErrorMessage = "Maximum length for the Name is 60 characters.")]
        public string CourseTitle { get; set; }
        public string Description { get; set; }

        [ForeignKey(nameof(User))]
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

    }
}