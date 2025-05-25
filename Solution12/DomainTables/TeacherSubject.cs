using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainTables
{
    public class TeacherSubject
    {
        [ForeignKey(nameof(Teacher))]
        public int TeacherId { get; set; }

        [ForeignKey(nameof(Subject))]
        public int SubjectId { get; set; }

        [Required]
        [MaxLength(6)]
        public string GroupNumber { get; set; }

        [Required]
        public ClassType ClassType { get; set; }

        public Teacher Teacher { get; set; }
        public Subject Subject { get; set; }

    }
}
