﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.DataTransferObjects
{
    public class AssignmentForCreationDto
    {
        [Required(ErrorMessage = "Assignment Title is a required field.")]
        public string AssignmentTitle { get; set; }

        [Required(ErrorMessage = "Description is a required field.")]
        public string Description { get; set; }

        public Guid CourseSectionID { get; set; }
    }
}
