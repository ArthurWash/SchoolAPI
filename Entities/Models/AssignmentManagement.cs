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

        public string AssignmentTitle { get; set; }
        public string Description { get; set; }

        [ForeignKey(nameof(CourseSectionManagement))]
        public Guid CourseSectionID { get; set; }
        public string CourseID { get; set; }

        public CourseSectionManagement CourseSectionManagement { get; set; }

    }
}