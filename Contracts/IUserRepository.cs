using Entities.Models;
using System;
using System.Collections.Generic;

namespace Contracts
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAllUsers(bool trackChanges);
        User GetUser(Guid UserId, bool trackChanges);
    }
}