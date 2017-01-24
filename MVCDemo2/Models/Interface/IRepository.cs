using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using MVCDemo2.Models.Interface;
using MVCDemo2.Models.UserModelFolder;

namespace MVCDemo2.Models
{
    public interface IRepository
    {
        UserModel GetById(int id);
        EntityList<UserModel> GetAll();
        void DeleteById(int id);
        void Edit(IEntity entityItem);
        void Add(IEntity entityItem);
    }
}
