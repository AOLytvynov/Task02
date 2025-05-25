using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainTables
{
    public class Subject
    {
        [Key]
        public int SubjectId { get; set; }

        [Required]
        public string SubjectName { get; set; }

        [Required]
        [Range(1, 999)]
        public int SpecialtyNumber { get; set; }

        [Required]
        [Range(1, 12)]
        public int SemesterNumber { get; set; }

        [Required]
        [Range(1, 50)]
        public int LectureHours { get; set; }

        [Required]
        [Range(1, 50)]
        public int LaboratoryWorkHours { get; set; }

        [Required]
        [Range(1, 50)]
        public int PracticalClassesHours { get; set; }

        public ICollection<TeacherSubject> TeacherSubjects { get; set; } = new List<TeacherSubject>();
    }
}
