using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainTables;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Services
{
    public class TeacherSubjectService
    {
        private readonly AppDbContext _context;

        public TeacherSubjectService(AppDbContext context) 
        {
            _context = context;
        }

        public void AddTeacherSubject(TeacherSubject ts)
        {
            _context.TeacherSubjects.Add(ts);
            _context.SaveChanges();
        }

        // READ: (ALL)
        public List<TeacherSubject> GetAllTeacherSubjects()
        {
            return _context.TeacherSubjects
                .Include(ts => ts.Teacher)
                .Include(ts => ts.Subject)
                .ToList();
        }

        // READ (ID)
        public TeacherSubject GetTeacherSubjectById(int teacherId, int subjectId)
        {
            return _context.TeacherSubjects
                .Include(ts => ts.Teacher)
                .Include(ts => ts.Subject)
                .FirstOrDefault(ts => ts.TeacherId == teacherId && ts.SubjectId == subjectId);
        }

        // UPDATE
        public void UpdateTeacherSubject(TeacherSubject ts)
        {
            _context.TeacherSubjects.Update(ts);
            _context.SaveChanges();
        }

        // DELETE
        public void DeleteTeacherSubject(int teacherId, int subjectId)
        {
            var ts = _context.TeacherSubjects
                .FirstOrDefault(t => t.TeacherId == teacherId && t.SubjectId == subjectId);

            if (ts != null)
            {
                _context.TeacherSubjects.Remove(ts);
                _context.SaveChanges();
            }
        }
    }
}
