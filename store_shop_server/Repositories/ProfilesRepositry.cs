using System.Data;
using amazen_server.Models;
using Dapper;

namespace amazen_server.Repositories
{
  public class ProfilesRepository
  {
    private readonly IDbConnection _db;

    public ProfilesRepository(IDbConnection db)
    {
      _db = db;
    }

    public Profile GetByEmail(string email)
    {
      string sql = "SELECT * FROM profiles WHERE email = @Email";
      return _db.QueryFirstOrDefault<Profile>(sql, new { email });
    }
    public Profile GetById(string id)
    {
      string sql = "SELECT * FROM profiles WHERE id = @Id";
      return _db.QueryFirstOrDefault<Profile>(sql, new { id });
    }

    public Profile Create(Profile userInfo)
    {
      string sql = @"
            INSERT INTO profiles
            (name, picture, email, id)
            VALUES
            (@Name, @Picture, @Email, @Id)";
      _db.Execute(sql, userInfo);
      return userInfo;
    }
  }
}