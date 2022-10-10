using Microsoft.Data.SqlClient;
using TheUniversity;
using TheUniversity.Models;
using TheUniversity.Repositories;

SqlConnectionStringBuilder builder = new()
{
    DataSource = "(local)",
    InitialCatalog = "TheUniversity",
    IntegratedSecurity = true,
    Encrypt = false
};

using SqlConnection conn = new(builder.ToString());
UserRepository repo = new(conn);
UserService service = new(repo);

await service.Register("omish@email.com", "thepassword");

User user = await service.Authenticate("omish@email.com", "thepassword");

Console.WriteLine(user.Email);
