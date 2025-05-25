using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainTables;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Services
{
    public class TeacherService
    {
        private readonly AppDbContext _context;

        public TeacherService(AppDbContext context)
        {
            _context = context;
        }

        //CREATE
        public void AddTeacher(Teacher teacher)
        {
            _context.Teachers.Add(teacher);
        }

        //READ (ALL)
        public List<Teacher> GetAllTeachers()
        {
            return _context.Teachers.ToList();
        }

        //READ (ID)
        public Teacher? GetTeacherById(int id)
        {
            return _context.Teachers
                .Include(t => t.TeacherSubjects)
                .FirstOrDefault(t => t.TeacherId == id);
        }

        //UPDATE
        public void UpdateTeacher(Teacher teacher)
        {
            _context.Teachers.Update(teacher);
            _context.SaveChanges();
        }

        //DELETE
        public void DeleteTeacher(int id)
        {
            Teacher? teacher = _context.Teachers.Find(id);
            if (teacher != null)
            {
                _context.Teachers.Remove(teacher);
                _context.SaveChanges();
            }
        }
    }
}
