using Bussiness.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Repository.StudentRepository
{
    public interface IStudentRepository
    {
        Task<IEnumerable<Student>> GetAll();
        Task<Student> GetById(int id);
        Task<int> Insert(Student student);
        Task<int> Update(Student student);
        Task<int> Delete(int id);
        Task<int> GetNextId();
    }
}
