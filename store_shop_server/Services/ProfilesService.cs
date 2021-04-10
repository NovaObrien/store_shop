using amazen_server.Repositories;
using amazen_server.Models;

namespace amazen_server.Services
{
  public class ProfilesService
  {
    private readonly ProfilesRepository _repo;
    public ProfilesService(ProfilesRepository repo)
    {
      _repo = repo;
    }

    public Profile GetOrCreate(Profile userInfo)
    {
      Profile foundProfile = _repo.GetByEmail(userInfo.Email);
      if (foundProfile == null)
      {
        return _repo.Create(userInfo);
      }
      return foundProfile;
    }

    public Profile GetPublicProfile(string id)
    {
      return _repo.GetById(id);
    }
  }
}