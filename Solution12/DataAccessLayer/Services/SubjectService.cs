using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainTables;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Services
{
    public class SubjectService
    {
        private readonly AppDbContext _context;

        public SubjectService(AppDbContext context)
        {
            _context = context;
        }

        //CREATE
        public void AddSubject(Subject subject)
        {
            _context.Subjects.Add(subject);
        }

        //READ (ALL)
        public List<Subject> GetAllSubjects()
        {
            return _context.Subjects.ToList();
        }

        //READ (ID)
        public Subject? GetSubjectById(int id)
        {
            return _context.Subjects
                .Include(s => s.TeacherSubjects)
                .FirstOrDefault(s => s.SubjectId == id);
        }

        //UPDATE
        public void UpdateSubject(Subject subject)
        {
            _context.Subjects.Update(subject);
            _context.SaveChanges();
        }

        //DELETE
        public void DeleteSubject(int id)
        {
            Subject? subject = _context.Subjects.Find(id);
            if (subject != null)
            {
                _context.Subjects.Remove(subject);
                _context.SaveChanges();
            }
        }
    }
}
