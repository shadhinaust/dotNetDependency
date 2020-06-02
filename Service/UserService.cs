using RestApi.Models;
using RestApi.Repository;
using System.Collections.Generic;

namespace RestApi.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void DeleteUser(long id)
        {
            _userRepository.Delete(id);
        }

        public List<User> GetAllUsers()
        {
            return _userRepository.GetAll();
        }

        public User GetUser(long id)
        {
            return _userRepository.GetOne(id);
        }

        public User SaveUser(User user)
        {
            return _userRepository.Save(user);
        }

        public User UpdateUser(User user)
        {
            return _userRepository.Update(user);
        }
    }
}