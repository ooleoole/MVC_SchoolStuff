﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCDemo2.Models.Interface;
using MVCDemo2.Models.UserModelFolder;

namespace MVCDemo2.Models
{
    public class UserRepository : IRepository
    {
        private EntityList<UserModel> _userModels = new EntityList<UserModel>();

        public EntityList<UserModel> UserModels => _userModels;

        public UserRepository()
        {
            _userModels.Add(new UserModel { FirstName = "Arne", LastName = "Anka", Address = "A-gata1", Email = "arne.anka@jvas.com", Birthdate = DateTime.Now - TimeSpan.FromDays(365), Salary = 3000 });
            _userModels.Add(new UserModel { FirstName = "Test", LastName = "korv", Address = "A-gata1", Email = "arne.anka@jvas.com", Birthdate = DateTime.Now - TimeSpan.FromDays(365), Salary = 3000 });
        }


        public UserModel GetById(int id)
        {
            return _userModels.FirstOrDefault(um => um.Id == id);

        }

        public EntityList<UserModel> GetAll()
        {
            return UserModels;
        }

        public void DeleteById(int id)
        {
            _userModels.Remove(GetById(id));
        }

        public void Edit(IEntity updatedUser)
        {
            foreach (var user in _userModels)
            {
                if (user.Id == updatedUser.Id)
                {
                    var userModel = (UserModel)updatedUser;
                    user.Address = userModel.Address;
                    user.Birthdate = userModel.Birthdate;
                    user.Email = userModel.Email;
                    user.FirstName = user.FirstName;
                    user.LastName = user.LastName;
                    user.Salary = user.Salary;
                }
            }
        }

        public void Add(IEntity userModel)
        {
            _userModels.Add((UserModel)userModel);
        }
    }
}