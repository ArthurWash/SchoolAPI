using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DataTransferObjects
{
    public class SectionEnrollmentDto
    {
        public Guid Id { get; set; }
        public string SectionID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public Guid UserID { get; set; }
        public string UserName { get; set; }
    }
}
