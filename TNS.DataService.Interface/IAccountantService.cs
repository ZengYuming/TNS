using TNS.Db;
using Framework.Core.Model;
using System.Collections.Generic;

namespace TNS.DataService.Interface
{
    public interface IAccountantService : IService
    {
        IEnumerable<Accountant> GetList(PageInfo page);

        Accountant Get(int id);

        Accountant Get(string account, string passWord);

        bool Update(Accountant accountant);

        bool Add(Accountant accountant);

        bool Delete(string id);
    }
}
