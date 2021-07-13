using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class CourseSectionManagement
    {
        [Column("CourseSectionID")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Section is a required field.")]
        [MaxLength(10, ErrorMessage = "Maximum length is 10 characters.")]
        public string CourseID { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy")]
        public DateTime StartDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy")]
        public DateTime EndDate { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }


    }
}