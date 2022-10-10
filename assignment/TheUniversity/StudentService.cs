using TheUniversity.Models;
using TheUniversity.Repositories;

namespace TheUniversity
{
    public class StudentService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository students)
        {
            _studentRepository = students;
        }

        public Task<Student?> GetStudent(int id)
        {
            return _studentRepository.Find(id);
        }

        public Task<IEnumerable<Student>> GetStudentList()
        {
            return _studentRepository.All();
        }

        public Task UpdateStudent(Student student)
        {
            if (student == null)
            {
                throw new ArgumentNullException(nameof(student));
            }

            return _studentRepository.Update(student);
        }
    }
}
