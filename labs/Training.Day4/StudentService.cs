using System.Collections.Generic;
using Training.Day4.Data;
using Training.Day4.Models;

namespace Training.Day4
{
    public class StudentService
    {
        private readonly IRepository<Student> _studentRepository;

        public StudentService(IRepository<Student> students)
        {
            _studentRepository = students;
        }

        public Student GetStudent(int id)
        {
            return null;
        }

        public IEnumerable<Student[]> GetStudentList()
        {
            return null;
        }

        public void UpdateStudent(Student student)
        {

        }
    }
}
