﻿using System.Collections.Generic;
using APISolution.Domain;

namespace APISolution.Data.Interfaces.Data
{
    public interface IUserData 
    {
        Task<IEnumerable<User>> GetAll();
        Task<User> Insert(User entity);
        Task<User> Update(User entity);
        Task <IEnumerable<User>> GetAllWithRoles();
        Task <User> GetUserWithRoles(string username);
        Task <User> GetByUsername(string username);
        Task <User> Login(string username, string password);
        Task <Task> ChangePassword(string username, string newPassword);
    }
}