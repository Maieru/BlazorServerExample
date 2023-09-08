using Bussiness.Model;
using Bussiness.Repository.StudentRepository;
using Microsoft.AspNetCore.Mvc;

namespace BlazorServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : Controller
    {
        private readonly IStudentRepository _studentRepository;

        public StudentController(IStudentRepository studentRepository) => _studentRepository = studentRepository;

        [HttpGet]        
        public async Task<IActionResult> GetAll() => Ok(await _studentRepository.GetAll());

        [HttpGet("GetNextId")]
        public async Task<IActionResult> GetNextId() => Ok(await _studentRepository.GetNextId());

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var student = await _studentRepository.GetById(id);
            
            if (student == null)
                return NotFound();
            
            return Ok(student);
        }

        [HttpPost]
        public void Post(Student student) => _studentRepository.Insert(student);

        [HttpDelete("{id}")]
        public IActionResult Delete(int id) => Ok(_studentRepository.Delete(id));

        [HttpPut]
        public void Put(Student student) => _studentRepository.Update(student);         
    }
}
