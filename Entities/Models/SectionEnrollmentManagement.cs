using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class SectionEnrollmentManagement
    {
        [Column("SectionEnrollmentID")]
        public Guid Id { get; set; }

        public string SectionID { set; get; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy")]
        public DateTime StartDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy")]
        public DateTime EndDate { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }


        [ForeignKey(nameof(User))]
        public Guid UserID { get; set; }
        [Required(ErrorMessage = "User name is a required field.")]
        [MaxLength(30, ErrorMessage = "Maximum length for the Name is 30 characters.")]
        public string UserName { get; set; }

        public User User { get; set; }

        public ICollection<User> Users { get; set; }

    }
}