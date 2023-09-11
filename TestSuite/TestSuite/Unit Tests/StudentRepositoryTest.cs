using Bussiness.Context;
using Bussiness.Model;
using Bussiness.Repository.StudentRepository;
using Microsoft.EntityFrameworkCore;
namespace TestSuite
{
    public class StudentRepositoryTest
    {
        private readonly SchoolContext _context;

        public StudentRepositoryTest()
        {
            var dbOptions = new DbContextOptionsBuilder<SchoolContext>().UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString());
            _context = new SchoolContext(dbOptions.Options);
        }

        [Fact]
        public async Task InsertStudent()
        {
            // Arrange
            var testStudent = new Student() { Id = 1, Name = "John" };
            var studentRepository = new StudentRepository(_context);

            // Act
            var result = await studentRepository.Insert(testStudent);
            var users = await studentRepository.GetAll();

            // Assert
            Assert.True(result == 1);
            Assert.Single(users);
            Assert.Contains(testStudent, users);
        }

        [Fact]
        public async Task GetAllStudents()
        {
            // Arrange
            var studentRepository = new StudentRepository(_context);
            var students = new List<Student>()
            {
                new Student() { Id = 1, Name = "John" },
                new Student() { Id = 2, Name = "Mary" },
                new Student() { Id = 3, Name = "Peter" }
            };
            _context.Students.AddRange(students);
            await _context.SaveChangesAsync();

            // Act
            var users = await studentRepository.GetAll();

            // Assert
            Assert.Equal(students.Count(), users.Count());
            Assert.Equal(students, users);
        }

        [Fact]
        public async Task GetByIdStudent()
        {
            // Arrange
            var studentRepository = new StudentRepository(_context);
            var testStudent = new Student() { Id = 1, Name = "John" };
            _context.Students.Add(testStudent);
            await _context.SaveChangesAsync();

            // Act
            var student = await studentRepository.GetById(testStudent.Id);

            // Assert
            Assert.NotNull(student);
            Assert.Equal(testStudent, student);
        }

        [Fact]
        public async Task UpdateStudent()
        {
            // Arrange
            var testStudent = new Student() { Id = 1, Name = "John" };
            var studentRepository = new StudentRepository(_context);
            await studentRepository.Insert(testStudent);

            // Act
            testStudent.Name = "Peter";
            var result = await studentRepository.Update(testStudent);
            var updatedStudent = await studentRepository.GetById(testStudent.Id);

            // Assert
            Assert.True(result == 1);
            Assert.Equal(testStudent, updatedStudent);
        }

        [Fact]
        public async Task DeletesStudent()
        {
            // Arrange
            var testStudent = new Student() { Id = 1, Name = "John" };
            var studentRepository = new StudentRepository(_context);
            await studentRepository.Insert(testStudent);

            // Act
            var result = await studentRepository.Delete(testStudent.Id);
            var users = await studentRepository.GetAll();

            // Assert
            Assert.True(result == 1);
            Assert.Empty(users);
        }

        [Fact]
        public async Task GetNextId()
        {
            // Arrange
            var studentRepository = new StudentRepository(_context);
            var originalId = 1;
            await studentRepository.Insert(new Student() { Id = originalId, Name = "John" });

            // Act
            var nextId = await studentRepository.GetNextId();

            // Assert
            Assert.True(nextId == originalId + 1);
        }
    }
}