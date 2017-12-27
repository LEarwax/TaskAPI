using System;
using System.Collections.Generic;
using TaskAPI.Models;


namespace TaskAPI.DataAccess
{
    public interface IUserData
    {
        List<User> GetAll();
        User GetOne(int id);
        User Create(string name, string password);
    }
}
