using Domain.DomainModels;

namespace Domain.DLA;

public interface IUserRepo
{
    public User? FindUserById(int id);

    public void AddNewUser(int id, string password);
}