using TNS.Db;
using Framework.Core.Model;
using System.Collections.Generic;
using System.Data;
using System;

namespace TNS.DataService.Interface
{
    public interface IPersonService : IService
    {
        IEnumerable<Person> GetList(PageInfo page);

        Person GetPerson(int id);

        bool UpdatePerson(Person person);
    }
}
