using System.IO;
using Training.Day4.Data;
using Training.Day4.Models;

namespace Training.Day4
{
    public class StreamService
    {
        private readonly IRepository<Student> _studentRepository;

        public StreamService(IRepository<Student> students)
        {
            _studentRepository = students;
        }

        public void StreamCsvSummary(Stream stream)
        {

        }
    }
}
