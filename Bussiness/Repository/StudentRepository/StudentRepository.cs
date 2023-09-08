using Bussiness.Context;
using Bussiness.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Repository.StudentRepository
{    
    public class StudentRepository : IStudentRepository
    {
        private readonly SchoolContext _context;

        public StudentRepository(SchoolContext context) => _context = context;

        public async Task<IEnumerable<Student>> GetAll() => await _context.Students.ToListAsync();

        public async Task<Student> GetById(int id) => await _context.Students.FindAsync(id);

        public async Task Insert(Student student)
        {
            _context.Students.Add(student);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Student student)
        {
            _context.Students.Update(student);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var student = await GetById(id);
            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
        }

        public async Task<int> GetNextId() => await _context.Students.MaxAsync(x => x.Id) + 1;
    }
}
