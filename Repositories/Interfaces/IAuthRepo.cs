using TodoProject.Dto;

namespace TodoProject.Repositories;

public interface IAuthRepo
{
    void Logout();
    string Login(UserLoginDto userData);
    void Signup(UserSignupDto userData);
}