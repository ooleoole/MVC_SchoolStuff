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
    public interface IRepository<T> where T : IEntity
    {
        UserModel GetById(int id);
        EntityList<T> GetAll();
        void DeleteById(int id);
        void Edit(T entityItem);
        void Add(T entityItem);
    }
}
