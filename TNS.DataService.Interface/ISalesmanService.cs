using TNS.Db;
using Framework.Core.Model;
using System.Collections.Generic;

namespace TNS.DataService.Interface
{
    public interface ISalesmanService : IService
    {
        IEnumerable<Salesman> GetList(PageInfo page);

        Salesman Get(string id);

        Salesman Get(string account, string passWord);

        bool Update(Salesman salesman);

        bool Add(Salesman salesman);

        bool Delete(string id);
    }
}
