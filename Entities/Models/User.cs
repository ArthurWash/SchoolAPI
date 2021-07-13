using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{   
    public class User
    {
        [Column("UserId")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "User name is a required field.")]
        [MaxLength(30, ErrorMessage = "Maximum length for the Name is 30 characters.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Email is a required field.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Status is a required field.")]
        public Boolean Status { get; set; }

        [Required(ErrorMessage = "SystemRoleID is a required field.")]
        public string SystemRoleID { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

    }
}