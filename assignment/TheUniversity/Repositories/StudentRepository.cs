using Dapper;
using System.Data;
using TheUniversity.Models;

namespace TheUniversity.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly IDbConnection _conn;

        public StudentRepository(IDbConnection conn)
        {
            _conn = conn ?? throw new ArgumentNullException(nameof(conn));
        }

        public Task<IEnumerable<Student>> All()
        {
            return _conn.QueryAsync<Student>(@"
                    SELECT Id, FirstName, LastName, Phone, DoB, GuardianId
                    FROM Student");
        }

        public Task<IEnumerable<StudentReport>> AllReports()
        {
            return _conn.QueryAsync<StudentReport>(@"
                 SELECT Id, FirstName, LastName, Grade
                 FROM Student
                    INNER JOIN (SELECT StudentId, SUM(Grade) AS Score FROM SubjectResult GROUP BY StudentId) AS p ON p.StudentId = Student.Id
                 ORDER BY Score");
        }

        public Task<Student?> Find(int id)
        {
            return _conn.QuerySingleOrDefaultAsync<Student?>(@"
                    SELECT Id, FirstName, LastName, Phone, DoB, GuardianId
                    FROM Student
                    WHERE Id = @Id",
                    new { Id = id });
        }

        public Task Update(Student student)
        {
            if (student == null)
            {
                throw new ArgumentNullException(nameof(student));
            }

            return _conn.ExecuteAsync(@"
                    UPDATE Student
                    SET
                        FirstName = @FirstName,
                        LastName = @LastName,
                        Phone = @Phone,
                        DoB = @DoB,
                        GuardianId = @GuardianId
                    WHERE Id = @id",
                    student);
        }
    }
}
