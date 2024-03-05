using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WheelyRev.Contacts
{
    public enum ErrorCode
    {
        Success,
        Error
    };
    //T t in parameters is Entity na sya or Table sa database or class
    //object id is the column of the database which is the e.g, (id, userId, roleId)
    public interface IBaseRepository<T>
    {
        T Get(object id);   //Equivalent to Select
        List<T> GetAll();   //Equivalent to Select *
        ErrorCode Create(T t);  //Equivalent to INSERT
        ErrorCode Update(object id, T t);   //Equivalent to Update
        ErrorCode Delete(object id);    //Equivalent to Delete
    }
}
