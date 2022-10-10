using System.Text;
using TheUniversity.Models;
using TheUniversity.Repositories;

namespace TheUniversity
{
    public class StreamService
    {
        private readonly IStudentRepository _studentRepository;

        public StreamService(IStudentRepository students)
        {
            _studentRepository = students ?? throw new NotImplementedException();
        }

        public async Task StreamStudentReports(Stream stream)
        {
            StringBuilder sb = new();
            sb.AppendLine("FirstName, LastName, Phone, Email, Status");

            const int MIN_SCORE = 10;
            const int MAX_SEATS = 15;

            int count = 0;

            foreach (StudentReport report in await _studentRepository.AllReports())
            {
                string status;

                if (report.Score < MIN_SCORE)
                {
                    status = "Rejected";
                }
                else if (count < MAX_SEATS)
                {
                    status = "Accepted";
                    count++;
                }
                else
                {
                    status = "Waiting";
                }

                sb.AppendLine($"{report.FirstName}, {report.LastName}, {status}");
            }

            await stream.WriteAsync(Encoding.UTF8.GetBytes(sb.ToString()));
        }
    }
}
