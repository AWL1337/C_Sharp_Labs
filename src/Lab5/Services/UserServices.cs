using Domain.DLA;
using Domain.DomainModels;
using Domain.Exceptions;

namespace Services;

public class UserServices
{
    private IUserRepo _userRepo;

    public UserServices(IUserRepo userRepo)
    {
        _userRepo = userRepo;
    }

    public User Login(int id, string password)
    {
        User? user = _userRepo.FindUserById(id);
        if (user is null) throw new UserException("There is no such user");
        if (user.Password == password) return user;
        throw new UserException("Wrong password");
    }

    public void AddNewUser(User? user, int id, string password)
    {
        if (user is not null && user.Role != UserRole.Admin) throw new UserException("You have no permission to create new users");
        User? usertmp = _userRepo.FindUserById(id);
        if (usertmp is not null) throw new UserException("There is already such account");
        _userRepo.AddNewUser(id, password);
    }
}