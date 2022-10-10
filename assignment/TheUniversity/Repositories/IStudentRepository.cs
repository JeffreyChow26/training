using TheUniversity.Models;

namespace TheUniversity.Repositories
{
    public interface IStudentRepository
    {
        Task<IEnumerable<Student>> All();
        Task<IEnumerable<StudentReport>> AllReports();
        Task<Student?> Find(int id);
        Task Update(Student student);
    }
}
